using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class OnBridge : MonoBehaviour
{

    [SerializeField] EdgeCollider2D edge1;
    [SerializeField] EdgeCollider2D edge2;

    [SerializeField] Tilemap bridgeTilemap;

    // Start is called before the first frame update
    void Start()
    {
        //bridgeTilemap = GameObject.FindGameObjectWithTag("HomestreadBridge").GetComponent<Tilemap>();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        bridgeTilemap = GameObject.FindGameObjectWithTag("HomestreadBridge").GetComponent<Tilemap>();

        if (col.gameObject.tag == "Player")
        {
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = -3;
            edge1.enabled = true;
            edge2.enabled = true;

            Debug.Log("OnCollision for bridge triggered - ON bridge" + bridgeTilemap.GetComponent<Renderer>().sortingOrder);
        }

    }

}
