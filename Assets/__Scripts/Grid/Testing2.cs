using System;
using UnityEngine;
using System.Collections;
using CodeMonkey.Utils;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class Testing2 : SingletonMonobehaviour<Testing2>, ISaveable
{
    #region Fields

    [SerializeField] private int[] width = new int[13];
    [SerializeField] private int[] height = new int[13];
    [SerializeField] private Vector3[] origin = new Vector3[13];
    private float cellSize;

    [SerializeField] private string[] oneDimensional = new string[13];

    [SerializeField] private Transform[] gridParent = new Transform[13];

    public Grid<ComplexGridObject>[] stringGrid = new Grid<ComplexGridObject>[13];

    private float mouseMoveTimer;
    private const float MouseMoveTimerMax = 0.01f;

    [SerializeField]
    private int fontSize = 10;

    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBool heatMapBool;
    [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;


    [SerializeField] private int sceneNumber;
    [SerializeField] private string activeScene;

    [SerializeField] private bool listSaved;

    private string[] scenes =
    {
        "Homestead", "Mountains", "Dungeon", "shop1", "shop2", "shop3", "House_h_north", "House_h_south",
        "House_h_west", "House_m_north", "House_m_south", "House_m_west", "Town"
    };

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
        //InitializeGrid(); Run this when game is complete to find the new tilemap values
        Debug.Log($"Start called in Testing2");
        SetUpGrid();
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


    private void Update()
    {
        Vector3 position = UtilsClass.GetMouseWorldPosition();

        if (Input.GetKeyDown(KeyCode.R))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddLetter("A");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddLetter("B");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddLetter("C");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddNumber("1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddNumber("2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stringGrid[sceneNumber]
                .GetGridObject(position)
                .AddNumber("3");
        }
    }

    [Button(ButtonSizes.Large)]
    [GUIColor(0.282f, 0.286f, 0.556f)]
    private void GetFinalTilemapValues()
    {
        StartCoroutine(UpdateTilemaps());
    }

    private void SetUpGrid()
    {
        for (int i = 0; i < stringGrid.Length; i++)
        {
            stringGrid[i] = new Grid<ComplexGridObject>(width[i], height[i], cellSize, origin[i], fontSize,
                (g, objectWidth, objectHeight) => new ComplexGridObject(g, objectWidth, objectHeight), gridParent[i]);
            if (listSaved)
            {
                StringToGrid(stringGrid[i], oneDimensional[i], width[i], height[i]);
            }
        }

        SetSceneName("Homestead", 0, 0);
        Debug.Log($"Grids Initialised | {stringGrid.Length}");
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

    public static void StringToGrid(Grid<ComplexGridObject> inputGrid, string oneD, int width, int
        height)
    {
        string[] separator = {"_,"};
        string[] newArray = oneD.Split(separator, StringSplitOptions.None);
        int index = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                inputGrid.GridArray[i, j].AddLetter(newArray[index]);
                inputGrid.GridArray[i, j].AddNumber(newArray[index + 1]);
                index += 2;
            }
        }
    }


    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        listSaved = true;

        for (int i = 0; i < oneDimensional.Length; i++)
        {
            oneDimensional[i] = Helpers.FlattenMultiToString(stringGrid[i].GridArray, false);
        }

        SaveData.GridData gd = new(oneDimensional, listSaved, activeScene, sceneNumber);
        a_SaveData.gridData = gd;
        a_SaveData.gridData.isSaved = listSaved;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        listSaved = a_SaveData.gridData.isSaved;

        if (listSaved)
        {
            activeScene = a_SaveData.gridData.activeScene;
            sceneNumber = a_SaveData.gridData.sceneNumber;
            UpdateSceneNumber();

            for (int i = 0; i < oneDimensional.Length; i++)
            {
                oneDimensional[i] = a_SaveData.gridData.oneDim[i];
                StringToGrid(stringGrid[i], oneDimensional[i], width[i], height[i]);
            }
        }
    }

    #endregion
}