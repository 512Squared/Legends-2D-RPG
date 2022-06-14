using System;
using UnityEngine;
using System.Collections;
using CodeMonkey.Utils;

public class Testing2 : SingletonMonobehaviour<Testing2>
{
    private Grid<bool> grid;

    private LevelManager level;
    private int width;
    private int height;
    private Vector3 origin;
    private float cellSize;

    [SerializeField]
    private int fontSize = 10;

    [SerializeField] private HeatMapBool heatMapBool;

    private void Start()
    {
        StartCoroutine(StartCo());
    }

    private IEnumerator StartCo()
    {
        yield return new WaitForSeconds(0.2f);
        level = FindObjectOfType<LevelManager>();
        level.GetTilemapSize(out origin, out width, out height, out cellSize);
        Debug.Log($"Grid specs: {width} | {height} | {cellSize} | {origin}");
        grid = new Grid<bool>(width, height, cellSize, origin, fontSize);
        
        heatMapBool.SetGrid(grid);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            grid.SetValue(position, true);
        }
    }
}