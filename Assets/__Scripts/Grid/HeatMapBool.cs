﻿using System;
using CodeMonkey.Utils;
using UnityEngine;

public class HeatMapBool : MonoBehaviour
{
    private Grid<bool> grid;
    private Mesh mesh;
    private MeshRenderer meshRenderer;
    private float mouseMoveTimer;
    private const float MouseMoveTimerMax = 0.01f;
    private bool updateMesh;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "Test";
        meshRenderer.sortingOrder = -1;
    }

    private void Update()
    {
        //HandleHeatMapMouseMove();
    }

    public void SetGrid(Grid<bool> testGrid)
    {
        grid = testGrid;
        UpdateHeatMapVisual();

        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, EventArgs e)
    {
        updateMesh = true;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateHeatMapVisual();
        }
    }

    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices,
            out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = (x * grid.GetHeight()) + y;
                Vector3 cellSize = new Vector3(1, 1) * grid.GetCellSize();

                bool gridValue = grid.GetGridObject(x, y);
                float gridValueNormalized = gridValue ? 1f : 0f;
                Vector2 gridValueUV = new(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index,
                    grid.GetWorldPosition(x, y) + (cellSize * 0.5f),
                    0f,
                    cellSize, gridValueUV, gridValueUV);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private void HandleHeatMapMouseMove()
    {
        mouseMoveTimer -= Time.deltaTime;
        if (mouseMoveTimer < 0f)
        {
            mouseMoveTimer += MouseMoveTimerMax;
            if (grid != null)
            {
                Vector3 position = UtilsClass.GetMouseWorldPosition();
                grid.SetGridObject(position, true);
            }
        }
    }
}