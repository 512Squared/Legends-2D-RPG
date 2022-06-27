using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;


[Serializable]
public class Grid<TGridObject>
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public int HEAT_MAP_MAX_VALUE = 100;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public int HEAT_MAP_MIN_VALUE = 0;

    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;

    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }


    private int width;
    private int height;
    private float cellSize;
    public TGridObject[,] GridArray;
    private Vector3 originPosition;
    private Transform gridParent;
    private int debugFontSize;

    private TextMeshPro[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, int debugFontSize,
        Func<Grid<TGridObject>, int, int, TGridObject> createGridObject, Transform gridParent)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.debugFontSize = debugFontSize;
        this.gridParent = gridParent;


        GridArray = new TGridObject[width, height];

        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                GridArray[x, y] = createGridObject(this, x, y);
            }
        }

        const bool showDebug = false;
        if (showDebug)
        {
            debugTextArray = new TextMeshPro[width, height];

            for (int x = 0; x < GridArray.GetLength(0); x++)
            {
                for (int y = 0; y < GridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = UtilsClass.CreateWorldText(gridParent, GridArray[x, y]?.ToString(),
                        sortingOrder: debugFontSize, color: Color.white,
                        localPosition: GetWorldPosition(x, y) + (new Vector3(cellSize, cellSize) * 0.5f));
                    debugTextArray[x, y].GetComponent<MeshRenderer>().sortingLayerName = "Test";
                    debugTextArray[x, y].horizontalAlignment = HorizontalAlignmentOptions.Center;
                    debugTextArray[x, y].verticalAlignment = VerticalAlignmentOptions.Middle;
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 120f, false);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 120f, false);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 120f, false);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 120f, false);

            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.x, eventArgs.y].text = GridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return (new Vector3(x, y) * cellSize) + originPosition;
    }

    public Vector3 GetWorldPositionCentered(int x, int y)
    {
        return (new Vector3(x, y) * cellSize) + originPosition + new Vector3(cellSize / 2, cellSize / 2);
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            GridArray[x, y] = value;
            OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs {x = x, y = y});
        }
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs {x = x, y = y});
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }


    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return GridArray[x, y];
        }

        return default;
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
}