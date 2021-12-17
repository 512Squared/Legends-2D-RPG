using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class OnBridge : MonoBehaviour
{

    public PlayerGlobalData player;

    [SerializeField] EdgeCollider2D edge1;
    [SerializeField] EdgeCollider2D edge2;
    [SerializeField] EdgeCollider2D edge3;
    [SerializeField] EdgeCollider2D edge4;
    private Tilemap bridgeTilemap;

    // Start is called before the first frame update
    void Start()
    {
        bridgeTilemap = GameObject.FindGameObjectWithTag("HomestreadBridge").GetComponent<Tilemap>();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "onBridge")
        {
            //player.gameObject.layer = 8;
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = -3;
            edge1.enabled = true;
            edge2.enabled = true;
            edge3.enabled = true;
            edge4.enabled = true;

            Debug.Log("OnCollision for bridge triggered - ON bridge" + bridgeTilemap.GetComponent<Renderer>().sortingOrder);
        }
        else if (col.gameObject.tag == "offBridge")
        {
            //player.gameObject.layer = 3;
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = +3;
            edge1.enabled = false;
            edge2.enabled = false;
            edge3.enabled = false;
            edge4.enabled = false;

            Debug.Log("OnCollision for bridge triggered - OFF bridge" + bridgeTilemap.GetComponent<Renderer>().sortingOrder);
        }

    }

}
