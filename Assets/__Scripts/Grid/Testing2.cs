using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using JetBrains.Annotations;
using StansAssets.Foundation.Extensions;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateGUID))]
public class Testing2 : SingletonMonobehaviour<Testing2>, ISaveable
{
    #region Fields

    public LevelManager level;
    private int width;
    private int height;
    private Vector3 origin;
    private float cellSize;

    private string[] oneDimensional;

    private string guid;

    [SerializeField] private Transform[] gridParent = new Transform[12];

    private float mouseMoveTimer;
    private const float MouseMoveTimerMax = 0.01f;

    [SerializeField]
    private int fontSize = 10;

    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBool heatMapBool;
    [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;


    [SerializeField] private Grid<ComplexGridObject>[] stringGrid;
    [SerializeField] private int sceneNumber;

    [SerializeField] private bool listSaved;
    [SerializeField] private bool isLoaded;
    private static string activeScene;

    #endregion


    private void OnEnable()
    {
        Actions.OnSceneChange += SetSceneName;
    }

    private static void SetSceneName(string scene, int arg2, int arg3)
    {
        activeScene = scene;
        Debug.Log($"Active scene: {activeScene}");
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= SetSceneName;
    }

    private void Start()
    {
        guid = GetComponent<GenerateGUID>().GUID;
        stringGrid = new Grid<ComplexGridObject>[12];
        oneDimensional = new string[12];
        Debug.Log($"String grid size: {stringGrid.Length}");
    }


    private IEnumerator LoadArrayAtStart()
    {
        yield return new WaitUntil(() => isLoaded);
        level = FindObjectOfType<LevelManager>();
        level.GetTilemapSize(out origin, out width, out height, out cellSize);
        gridParent[sceneNumber].gameObject.SetActive(true);
        for (int i = 0; i < stringGrid.Length; i++)
        {
            stringGrid[i] = new Grid<ComplexGridObject>(width, height, cellSize, origin, fontSize,
                (g, objectWidth, objectHeight) => new ComplexGridObject(g, objectWidth, objectHeight), gridParent[i]);
            StringToGrid(stringGrid[i], oneDimensional[i], width, height);
        }

        UpdateGridParents();
    }

    private void Update()
    {
        Vector3 position = UtilsClass.GetMouseWorldPosition();

        if (Input.GetKeyDown(KeyCode.R)) { stringGrid[sceneNumber].GetGridObject(position).AddLetter("A"); }

        if (Input.GetKeyDown(KeyCode.T)) { stringGrid[sceneNumber].GetGridObject(position).AddLetter("B"); }

        if (Input.GetKeyDown(KeyCode.Y)) { stringGrid[sceneNumber].GetGridObject(position).AddLetter("C"); }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { stringGrid[sceneNumber].GetGridObject(position).AddNumber("1"); }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { stringGrid[sceneNumber].GetGridObject(position).AddNumber("2"); }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { stringGrid[sceneNumber].GetGridObject(position).AddNumber("3"); }
    }


    public void UpdateLevelManager(LevelManager newScene)
    {
        level = newScene;
        isLoaded = true;
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
        Debug.Log($"Scene number: {sceneNumber}");
        UpdateGridParents();
    }

    private void UpdateGridParents()
    {
        for (int i = 0; i < gridParent.Length; i++)
        {
            if (i == sceneNumber) { gridParent[sceneNumber].gameObject.SetActive(true); }
            else { gridParent[i].gameObject.SetActive(false); }
        }
    }

    public static void StringToGrid(Grid<ComplexGridObject> inputGrid, string oneD, int width, int height)
    {
        string[] separator = {"_,"};
        string[] newArray = oneD.Split(separator, StringSplitOptions.None);
        int index = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                inputGrid.gridArray[i, j].AddLetter(newArray[index]);
                inputGrid.gridArray[i, j].AddNumber(newArray[index + 1]);
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
            oneDimensional[i] = Helpers.FlattenMultiToString(stringGrid[i].gridArray, false);
        }

        SaveData.GridData gd = new(oneDimensional, listSaved);
        a_SaveData.gridData = gd;
        a_SaveData.gridData.isSaved = listSaved;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        listSaved = a_SaveData.gridData.isSaved;
        if (listSaved)
        {
            for (int i = 0; i < oneDimensional.Length; i++)
            {
                oneDimensional[i] = a_SaveData.gridData.oneDim[i];
            }
        }

        StartCoroutine(LoadArrayAtStart());
    }

    #endregion
}