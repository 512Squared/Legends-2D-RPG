using UnityEngine;
using System.Collections;




public class Pathfinding
{
    private LevelManager level;
    private int width;
    private int height;
    private Vector3 origin;
    private float cellSize;

    private float mouseMoveTimer;
    private const float MouseMoveTimerMax = 0.01f;

    [SerializeField]
    private int fontSize = 10;
    


    private IEnumerator StartCo()
    {
        yield return new WaitForSeconds(0.2f);
        //level = FindObjectOfType<LevelManager>();
        level.GetTilemapSize(out origin, out width, out height, out cellSize);
        Debug.Log($"Grid specs: {width} | {height} | {cellSize} | {origin}");

        //grid = new Grid<HeatMapGridObject>(width, height, cellSize, origin, fontSize, (Grid<HeatMapGridObject> g,int objectWidth, int objectHeight) => new HeatMapGridObject(g, objectWidth, objectHeight));
        //
        // stringGrid = new Grid<StringGridObject>(width, height, cellSize, origin, fontSize, (Grid<StringGridObject> g,
        //     int objectWidth, int objectHeight) => new StringGridObject(g, objectWidth, objectHeight));


        //heatMapGenericVisual.SetGrid(grid);
    }
    
    
    public Pathfinding(int width, int height)
    {
        
    }

    
}