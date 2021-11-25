using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class levelManager : MonoBehaviour
{

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        topRightEdge = tilemap.localBounds.max + new Vector3(-0.2f, -1.1f, 0f);
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(1.5f, 1f, 0f);
        PlayerGlobalData.instance.SetLimit(bottomLeftEdge, topRightEdge);
    }


}
