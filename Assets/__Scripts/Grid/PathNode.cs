using System.Collections;
using UnityEngine;

public class PathNode
{
    private Grid<PathNode> pathGrid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    public bool isWalkable;

    public bool isBridge;
    public bool isBridgeStart;
    public bool isBridgeMiddle;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        pathGrid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public override string ToString()
    {
        return x + "," + y;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        pathGrid.TriggerGridObjectChanged(x, y);
    }

    public void SetIsBridge(bool isKey)
    {
        isBridge = isKey;
        pathGrid.TriggerGridObjectChanged(x, y);
    }

    public void SetIsBridgeStart(bool isBridgeStart)
    {
        this.isBridgeStart = isBridgeStart;
        pathGrid.TriggerGridObjectChanged(x, y);
    }

    public void SetIsBridgeMiddle(bool isBridgeMiddle)
    {
        this.isBridgeMiddle = isBridgeMiddle;
        pathGrid.TriggerGridObjectChanged(x, y);
    }


    public void SwitchNodeLock()
    {
        isWalkable = !isWalkable;
        pathGrid.TriggerGridObjectChanged(x, y);
    }
}