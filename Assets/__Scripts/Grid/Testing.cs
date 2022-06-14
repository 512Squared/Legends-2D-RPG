using UnityEngine;
using System.Collections;
using CodeMonkey.Utils;


public class Testing : SingletonMonobehaviour<Testing>
{
    private Grid<int> grid;

    private LevelManager level;
    private int width;
    private int height;
    private Vector3 origin;
    private float cellSize;

    [SerializeField] private HeatMapVisual heatMapVisual;

    private void OnEnable()
    {
        //Actions.OnSceneChange += SetUpGridCo;
    }

    private void SetUpGridCo(string arg1, int arg2, int arg3)
    {
        StartCoroutine(SetUpGridCo());
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= UpdateGrid;
    }

    private void Start()
    {
        //StartCoroutine(StartCo());
    }

    private IEnumerator StartCo()
    {
        yield return new WaitForSeconds(0.2f);
        level = FindObjectOfType<LevelManager>();
        level.GetTilemapSize(out origin, out width, out height, out cellSize);
        Debug.Log($"Grid specs: {width} | {height} | {cellSize} | {origin}");
        grid = new Grid<int>(100, 100, 4, origin, 10);
        heatMapVisual.SetGrid(grid);
    }

    private void UpdateGrid(string arg1, int arg2, int arg3)
    {
        StartCoroutine(SetUpGridCo());
        Debug.Log($"Scene grid update called: {arg1}");
    }

    private IEnumerator SetUpGridCo()
    {
        yield return new WaitForSeconds(0.5f);
        SetUpGrid();
    }

    private void SetUpGrid()
    {
        level = FindObjectOfType<LevelManager>();
        level.GetTilemapSize(out origin, out width, out height, out cellSize);
        grid = new Grid<int>(width, height, cellSize, origin, 10);
        Debug.Log($"Grid: {grid?.GetWidth()} | {grid?.GetHeight()}");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 2nd slot: 'value' is the highest value given per 'click' 
            // 3rd slot: full-range is how many adjacent squares receive the 'value'
            // 4th slot: total-range is how many squares from centre are affected

            Vector3 position = UtilsClass.GetMouseWorldPosition();
            heatMapVisual.AddValue(position, 1, 1, 7);
        }
    }
}