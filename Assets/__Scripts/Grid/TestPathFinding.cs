﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
using UnityEngine.Tilemaps;


public class TestPathFinding : SingletonMonobehaviour<TestPathFinding>
{
    // TODO Create a method to set the obstacle tilemaps to unwalkable.

    #region Fields

    private Grid<PathNode>[] pathGrids = new Grid<PathNode>[13];

    [SerializeField] private Grid tilemapGrid;
    [SerializeField] private Tilemap tilemap;

    [SerializeField]
    private ZombieController zombie;


    private AiPathfinding pathFinding;

    [SerializeField] private PathfindingVisual pathfindingVisual;

    [SerializeField] private int[] width = new int[13];
    [SerializeField] private int[] height = new int[13];
    [SerializeField] private Vector3[] origin = new Vector3[13];
    private float cellSize;

    [SerializeField] private string[] oneDimensional = new string[13];

    [SerializeField] private Transform[] gridParent = new Transform[13];

    [SerializeField]
    private int fontSize = 10;

    [SerializeField] private HeatMapBool heatMapBool;
    [SerializeField] private HeatMapGenericVisual heatMapVisual;


    [SerializeField] private int sceneNumber;
    [SerializeField] private string activeScene;

    [SerializeField] private bool listSaved;

    private string[] scenes =
    {
        "Homestead", "Mountains", "Dungeon", "shop1", "shop2", "shop3", "House_h_north", "House_h_south",
        "House_h_west", "House_m_north", "House_m_south", "House_m_west", "Town"
    };

    public bool showPath;

    #endregion


    private void OnEnable()
    {
        Actions.OnSceneChange += SetSceneName;
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= SetSceneName;
    }


    protected override void Awake()
    {
        base.Awake();
        activeScene = "Homestead";
        origin[0] = new Vector3(-33.28f, -10.24f, 0f);
        origin[1] = new Vector3(-33.28f, -33.28f, 0f);
        origin[2] = new Vector3(0, -38.4f, 0f);
        origin[3] = new Vector3(-33.28f, -10.24f, 0f);
        origin[4] = new Vector3(-33.28f, -10.24f, 0f);
        origin[5] = new Vector3(-33.28f, -10.24f, 0f);
        origin[6] = new Vector3(-5.12f, -46.07999f, 0f);
        origin[7] = new Vector3(-7.88f, -53.76f, 0f);
        origin[8] = new Vector3(0, -46.08f, 0f);
        origin[9] = new Vector3(-7.88f, -51.2f, 0f);
        origin[10] = new Vector3(-7.88f, -51.2f, 0f);
        origin[11] = new Vector3(0f, -46.07999f, 0f);
        origin[12] = new Vector3(-38.4f, -12.8f, 0f);

        width[0] = 21;
        width[1] = 18;
        width[2] = 150;
        width[3] = 21;
        width[4] = 21;
        width[5] = 21;
        width[6] = 11;
        width[7] = 14;
        width[8] = 9;
        width[9] = 8;
        width[10] = 13;
        width[11] = 7;
        width[12] = 23;

        height[0] = 26;
        height[1] = 22;
        height[2] = 56;
        height[3] = 26;
        height[4] = 26;
        height[5] = 26;
        height[6] = 8;
        height[7] = 11;
        height[8] = 10;
        height[9] = 12;
        height[10] = 12;
        height[11] = 8;
        height[12] = 27;

        cellSize = 2.56f;
    }

    private void Start()
    {
        SetSceneName("Homestead", 0, 0);
        pathFinding = new AiPathfinding(21, 26, new Vector3(-33.28f, -10.24f, 0f), gridParent[0]);
        pathfindingVisual.SetGrid(pathFinding.GetGrid());
        StartCoroutine(SetupIsWalkable());
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            Vector3 thulgranPosition = new(PlayerGlobalData.Instance.transform.position.x, PlayerGlobalData
                .Instance.transform.position.y + (2.56f / 2), 0);

            if (showPath)
            {
                pathFinding.GetGrid().GetXY(thulgranPosition, out int startX, out int startY);
                pathFinding.GetGrid().GetXY(position, out int x, out int y);
                List<PathNode> path = pathFinding.FindPath(startX, startY, x, y);
                if (GameManager.Instance.gridDebug)
                {
                    //Debug.Log($"Update called {position} | Grid X,Y: {startX}, {startY} | End X,Y:{x},{y}");
                }

                if (path != null)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Debug.DrawLine(pathFinding.GetGrid().GetWorldPositionCentered(path[i].x, path[i].y),
                            pathFinding.GetGrid().GetWorldPositionCentered(path[i + 1].x, path[i + 1].y), Color.green,
                            10f,
                            false);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathFinding.GetNode(x, y).SetIsWalkable(!pathFinding.GetNode(x, y).isWalkable);
        }
    }


    public IEnumerator SetupIsWalkable()
    {
        yield return new WaitForSeconds(0.5f);

        tilemap = GameObject.FindWithTag("Pathfinding").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SetIsWalkable(false);
            }
        }

        SetupBridges();
    }

    public void SetupBridges()
    {
        Tilemap isBridgeMap = GameObject.FindWithTag("isBridge").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (isBridgeMap.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SetIsBridge(true);
            }
        }

        Tilemap locks1Map = GameObject.FindWithTag("locks").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (locks1Map.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SetIsWalkable(true);
            }
        }

        Tilemap locks2Map = GameObject.FindWithTag("locks2").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (locks2Map.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SetIsWalkable(false);
            }
        }
    }


    public void SwitchAllLocks()
    {
        Tilemap locks1 = GameObject.FindWithTag("locks").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (locks1.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SwitchNodeLock();
            }
        }

        Tilemap locks2 = GameObject.FindWithTag("locks2").GetComponent<Tilemap>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (locks2.HasTile(pos))
            {
                pathFinding.GetNode(pos.x + (tilemap.origin.x * -1), pos.y + (tilemap.origin.y * -1))
                    .SwitchNodeLock();
            }
        }
    }


    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.556f)]
    private void GetFinalTilemapValues()
    {
        StartCoroutine(UpdateTilemaps());
    }

    private IEnumerator UpdateTilemaps()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(scenes[i], LoadSceneMode.Additive);

            while (!asyncLoadLevel.isDone) { yield return null; }

            FindObjectOfType<LevelManager>()
                .GetTilemapSize(out origin[i], out width[i], out
                    height[i],
                    out
                    cellSize, scenes[i]);
            AsyncOperation asyncUnloadLevel = SceneManager.UnloadSceneAsync(scenes[i]);
            while (asyncUnloadLevel is {isDone: false}) { yield return null; }
        }
    }

    private void SetSceneName(string scene, int arg2, int arg3)
    {
        activeScene = scene;
        sceneNumber = UpdateSceneNumber();
    }

    public int UpdateSceneNumber()
    {
        sceneNumber = activeScene switch
        {
            "NeverUnload" => 0,
            "Homestead" => 0,
            "Mountains" => 1,
            "Dungeon" => 2,
            "shop1" => 3,
            "shop2" => 4,
            "shop3" => 5,
            "House_h_north" => 6,
            "House_h_south" => 7,
            "House_h_west" => 8,
            "House_m_north" => 9,
            "House_m_south" => 10,
            "House_m_west" => 11,
            "Town" => 12,
            _ => sceneNumber
        };
        UpdateGridParents();
        return sceneNumber;
    }

    private void UpdateGridParents()
    {
        for (int i = 0; i < gridParent.Length; i++)
        {
            if (i == sceneNumber) { gridParent[sceneNumber].gameObject.SetActive(true); }
            else { gridParent[i].gameObject.SetActive(false); }
        }
    }
}