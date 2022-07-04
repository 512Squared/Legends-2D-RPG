using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

public class Pathfinding

{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const int MOVE_STRAIGHT_COST = 10;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private const int MOVE_DIAGONAL_COST = 14;


    public Grid<PathNode> grid;

    private const float CellSize = 2.56f;
    private Vector3 originPosition = new(-33.28f, -10.24f, 0);
    private const int DebugFontSize = 5;
    private Transform gridParent;


    private List<PathNode> openList;
    private List<PathNode> closedList;


    public Pathfinding(int width, int height, Vector3 originPosition, Transform gridParent)
    {
        grid = new Grid<PathNode>(width, height, CellSize, originPosition, DebugFontSize, (Grid<PathNode> g, int
            x, int y) => new PathNode(g, x, y), gridParent);
    }

    public Grid<PathNode> GetGrid()
    {
        return grid;
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

        // out of nodes on the open list. No path
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