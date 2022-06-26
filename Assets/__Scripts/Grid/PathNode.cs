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
        
        public PathNode(Grid<PathNode> grid, int x, int y)
        {
            pathGrid = grid;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return x + "," + y;
        }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
