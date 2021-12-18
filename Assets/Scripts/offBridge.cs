using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class offBridge : MonoBehaviour
{

    [SerializeField] EdgeCollider2D edge1;
    [SerializeField] EdgeCollider2D edge2;
    [SerializeField] Tilemap bridgeTilemap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = +3;
            edge1.enabled = false;
            edge2.enabled = false;

            Debug.Log("OnCollision for bridge triggered - OFF bridge" + bridgeTilemap.GetComponent<Renderer>().sortingOrder);
        }

    }
}
