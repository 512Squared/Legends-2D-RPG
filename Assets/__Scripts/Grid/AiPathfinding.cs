using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

public class AiPathfinding

{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const int MOVE_STRAIGHT_COST = 10;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const int MOVE_DIAGONAL_COST = 14;

    public static AiPathfinding Instance { get; private set; }


    public Grid<PathNode> grid;

    private const float CellSize = 2.56f;
    public Vector3 originPosition = new(-33.28f, -10.24f, 0);
    private const int DebugFontSize = 5;


    private List<PathNode> openList;
    private List<PathNode> closedList;


    public AiPathfinding(int width, int height, Vector3 originPosition, Transform gridParent)
    {
        Instance = this;
        grid = new Grid<PathNode>(width, height, CellSize, originPosition, DebugFontSize, (Grid<PathNode> g, int
            x, int y) => new PathNode(g, x, y), gridParent);
    }

    public Grid<PathNode> GetGrid()
    {
        return grid;
    }

    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        grid.GetXY(startWorldPosition, out int startX, out int startY);
        grid.GetXY(endWorldPosition, out int endX, out int endY);
        Debug.Log($"FindPath data - start (zombie): {startX}, {startY} | end (Thulgran): {endX}, {endY}");
        List<PathNode> path = FindPath(startX, startY, endX, endY);

        if (path != null)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(GetGrid().GetWorldPositionCentered(path[i].x, path[i].y),
                    GetGrid().GetWorldPositionCentered(path[i + 1].x, path[i + 1].y), Color.green,
                    10f,
                    false);
            }
        }

        if (path == null)
        {
            return null;
        }

        List<Vector3> vectorPath = new();

        foreach (PathNode pathNode in path)
        {
            vectorPath.Add((new Vector3(pathNode.x, pathNode.y) * 2.56f) + originPosition +
                           new Vector3(2.56f / 2, 2.56f / 2));
            //vectorPath.Add((new Vector3(pathNode.x, pathNode.y) * grid.GetCellSize()) + (Vector3.one * grid.GetCellSize() * 0.5f));
        }

        foreach (Vector3 position in vectorPath)
        {
            Debug.Log($"vectorPath entries: {position}");
        }

        return vectorPath;
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);

        openList = new List<PathNode> {startNode};
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();
        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode)) { continue; }

                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        TestPathFinding.Instance.SwitchAllLocks();
        return RedoPathFind(startNode, endNode);
    }

    private List<PathNode> RedoPathFind(PathNode startNode, PathNode endNode)
    {
        openList = new List<PathNode> {startNode};
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();
        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode)) { continue; }

                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        Debug.Log($"Path not found");
        return null;
    }


    private List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new();

        if (currentNode.x - 1 >= 0)
        {
            // Left
            neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));

            // Left Down
            if (currentNode.y - 1 >= 0) { neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1)); }

            // Left up

            if (currentNode.y + 1 < grid.GetHeight())
            {
                neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
            }
        }

        if (currentNode.x + 1 < grid.GetWidth())
        {
            // Right
            neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));

            // Right Down
            if (currentNode.y - 1 >= 0) { neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1)); }

            // Right up
            if (currentNode.y + 1 < grid.GetHeight())
            {
                neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
            }
        }

        // Down
        if (currentNode.y - 1 >= 0) { neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1)); }

        // Up
        if (currentNode.y + 1 < grid.GetHeight()) { neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1)); }

        return neighbourList;
    }


    public PathNode GetNode(int x, int y)
    {
        return grid.GetGridObject(x, y);
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new() {endNode};
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }

        // debug info
        Vector3 playerPosition = PlayerGlobalData.Instance.transform.position;
        grid.GetXY(playerPosition, out int sX, out int sY);

        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return (MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance)) + (MOVE_STRAIGHT_COST * remaining);
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];
        foreach (PathNode t in pathNodeList.Where(t => t.fCost < lowestFCostNode.fCost))
        {
            lowestFCostNode = t;
        }

        return lowestFCostNode;
    }
}