using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class OnBridge : MonoBehaviour
{
    [SerializeField] EdgeCollider2D top_right_edge;  // to stop going off bridge - link in inspector, same for both sides
    [SerializeField] EdgeCollider2D bottom_left_edge;

    [SerializeField] Tilemap bridgeTilemap; // tilemap with under and over parts of bridge, on sorting layer above player

    [SerializeField] OnBridge otherSide; // two sides - link in inspector

    [SerializeField] GameObject buffer; //entry from under

    bool isOnBridge = false;

    private void Start()
    {
        top_right_edge.enabled = false;
        bottom_left_edge.enabled = false;
    }


    public void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log($"This tag: {this.gameObject.tag} | Other's tag: {col.tag}");

        if (col.tag == "Player" && this.gameObject.tag != "failsafe")
        {
            BridgeActivation();
        }

        if (col.tag == "Player" && this.gameObject.tag == "failsafe")
        {
            Debug.Log("Failsafe - is OFF Bridge");
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = +3;
            buffer.GetComponent<BoxCollider2D>().enabled = true;
            otherSide.buffer.GetComponent<BoxCollider2D>().enabled = true;
            top_right_edge.enabled = false;
            bottom_left_edge.enabled = false;
        }
    }

    public void BridgeActivation()
    {
        isOnBridge = !isOnBridge;
        otherSide.isOnBridge = !otherSide.isOnBridge;

        top_right_edge.enabled = !top_right_edge.enabled;
        //otherSide.top_right_edge.enabled = !otherSide.top_right_edge.enabled;

        bottom_left_edge.enabled = !bottom_left_edge.enabled;
        //otherSide.bottom_left_edge.enabled = !otherSide.bottom_left_edge.enabled;

        if (isOnBridge == false)
        {
            Debug.Log("Is OFF Bridge");
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = +3;
            buffer.GetComponent<BoxCollider2D>().enabled = true;
            otherSide.buffer.GetComponent<BoxCollider2D>().enabled = true;

        }

        else if (isOnBridge == true)
        {
            Debug.Log("Is ON Bridge");
            bridgeTilemap.GetComponent<Renderer>().sortingOrder = -3;
            buffer.GetComponent<BoxCollider2D>().enabled = false;
            otherSide.buffer.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}



