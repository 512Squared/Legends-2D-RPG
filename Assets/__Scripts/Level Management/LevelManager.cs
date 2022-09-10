using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;


public class LevelManager : MonoBehaviour
{
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public NpcController[] npcCharacters;

    public SceneObjectsLoad scene;

    [SerializeField] private Tilemap tilemap;


    // Start is called before the first frame update
    private void Start()
    {
        Bounds localBounds = tilemap.localBounds;
        topRightEdge = localBounds.max + new Vector3(-0.4f, 0f, 0f);
        bottomLeftEdge = localBounds.min + new Vector3(0.7f, 0.1f, 0f);
        IEnumerable<ISetLimits> sl = FindObjectsOfType<MonoBehaviour>().OfType<ISetLimits>();
        foreach (ISetLimits s in sl) { s.SetLimits(bottomLeftEdge, topRightEdge); }
    }

    public void GetTilemapSize(out Vector3 origin, out int x, out int y, out float cellSize, string scene)
    {
        origin = tilemap.localBounds.min;
        x = tilemap.size.x;
        y = tilemap.size.y;
        cellSize = 2.56f;
        Debug.Log($"GetTilemapSize: {scene} | {x} | {y}");
    }
}

public partial interface ISetLimits
{
}