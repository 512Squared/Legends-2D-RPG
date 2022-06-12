using System;
using CodeMonkey.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using Sirenix.OdinInspector;

    public class Testing : SingletonMonobehaviour<Testing>
    {
        private Grid grid;
        private float mouseMoveTimer;
        private const float MouseMoveTimerMax = 0.01f;
        private LevelManager level;
        private int width;
        private int height;
        private Vector3 origin;
        private float cellSize;

        private void OnEnable()
        {
            // Actions.OnSceneChange += UpdateGrid;
        }

        private void OnDisable()
        {
            // Actions.OnSceneChange -= UpdateGrid;
        }

        private void Start()
        {
            //StartCoroutine(SetUpGridCo());
            StartCoroutine(StartCo());
            Grid grid = new(width, height, cellSize, origin);
        }

        private IEnumerator StartCo()
        {
            yield return new WaitForSeconds(0.2f);
            level = FindObjectOfType<LevelManager>();
            level.GetTilemapSize(out origin, out width, out height, out cellSize);
            
        }

        private void UpdateGrid(string arg1, int arg2, int arg3)
        {
            // StartCoroutine(SetUpGridCo());
            // Debug.Log($"Scene grid update called: {arg1}");
        }

        private IEnumerator SetUpGridCo()
        {
            yield return new WaitForSeconds(0.5f);
            // SetUpGrid();
        }

        private void SetUpGrid()
        {
            // level = FindObjectOfType<LevelManager>();
            // level.GetTilemapSize(out origin, out width, out height, out cellSize);
            // grid = new Grid(width, height, cellSize, origin); 
            //
            // Debug.Log($"Grid: {grid?.GetWidth()} | {grid?.GetHeight()}");
            //
            // HeatMapVisual heatMapVisual = new HeatMapVisual(grid, GetComponent<MeshFilter>());
        }

        private void Update()
        {
            //HandleClickToModifyGrid();
            //HandleHeatMapMouseMove();

        }

        private void HandleClickToModifyGrid()
        {
            if (Input.GetMouseButtonDown(0))
            {
                grid.SetValue(UtilsClass.GetMouseWorldPosition(), 22);
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 position = UtilsClass.GetMouseWorldPosition();
                if (grid != null)
                {
                    int value = grid.GetValue(position);
                    grid.SetValue(position, value + 5);
                    Debug.Log($"Grid Value set: {value}");
                }
                         
                //grid.AddValue(position, 100, 2, 25);
            }
        }

        private void HandleHeatMapMouseMove()
        {
            mouseMoveTimer -= Time.deltaTime;
            if (mouseMoveTimer < 0f)
            {
                mouseMoveTimer += MouseMoveTimerMax;
                int gridValue = grid.GetValue(UtilsClass.GetMouseWorldPosition());
                grid.SetValue(UtilsClass.GetMouseWorldPosition(), gridValue + 1);
            }
        }

        private class HeatMapVisual
        {
            private Grid grid;

            public HeatMapVisual(Grid grid, MeshFilter meshFilter)
            {
                this.grid = grid;

                Mesh mesh = new();
                meshFilter.mesh = mesh;
                
                UpdateHeatMapVisual();

                grid.OnGridValueChanged += Grid_OnGridValueChanged;
            }
            
            
            private void Grid_OnGridValueChanged(object sender, System.EventArgs e)
            {
                UpdateHeatMapVisual();
            }

            private void UpdateHeatMapVisual()
            {
                MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);
                
                for (int x = 0; x < grid.GetWidth(); x++)
                {
                    for (int y = 0; y < grid.GetHeight(); y++)
                    {
                        int index = x * grid.GetHeight() + y;
                        Vector3 baseSize = new Vector3(1,1) * grid.GetCellSize();
                        MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y), 0f, 
                        baseSize, Vector2.zero, Vector2.zero);
                    }
                }

                Mesh mesh1 = new() {vertices = vertices, uv = uv, triangles = triangles};
            }
            

        }
    }
