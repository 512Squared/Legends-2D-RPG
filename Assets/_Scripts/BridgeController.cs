using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

#pragma warning disable 0649


public class BridgeController : MonoBehaviour
{

    [Header("BRIDGES & LEVELS")]
    [Space]
    [InfoBox("The collider arrays below will take any number and type of collider: polygon, edge, box etc. Use colliders to match your needs. This prefab gives a complete switching system that allows your player to move above or below tilemap elements")]
    [Space]
    [Tooltip("Add colliders here that you want ON at start")]
    [SerializeField] GameObject[] startTheseCollidersOn;  
    [Space]
    [Tooltip("Add colliders here that you want OFF at start")]
    [SerializeField] GameObject[] startTheseCollidersOff;  
    [Space]
    [Tooltip("tilemap for top layer (e.g. bridge) tilemap parts")]
    [Space]
    [SerializeField] Tilemap[] bridgeTilemap;
    [Space]

    [Space]
    [SerializeField] Mainside mainside; 
    [SerializeField] Otherside otherside;

    [Space]
    public string playerName;

    private void Start()
    {
        // ON
        for (int i = 0; i < startTheseCollidersOn.Length; i++)
        {
            if (startTheseCollidersOn[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = true;
            if (startTheseCollidersOn[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = true;
            if (startTheseCollidersOn[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = true;
        }

        // OFF
        for (int i = 0; i < startTheseCollidersOff.Length; i++)
        {
            if (startTheseCollidersOff[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = false;
            if (startTheseCollidersOff[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = false;
            if (startTheseCollidersOff[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = false;
        }


    }


    public void Failsafe(string tag)
    {
        for (int i = 0; i < bridgeTilemap.Length; i++)
        {
            bridgeTilemap[i].GetComponent<Renderer>().sortingOrder = +3;
        }
        // ON
        for (int i = 0; i < startTheseCollidersOn.Length; i++)
        {
            if (startTheseCollidersOn[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = true;
            if (startTheseCollidersOn[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = true;
            if (startTheseCollidersOn[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = true;
        }

        // OFF
        for (int i = 0; i < startTheseCollidersOff.Length; i++)
        {
            if (startTheseCollidersOff[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = false;
            if (startTheseCollidersOff[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = false;
            if (startTheseCollidersOff[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = false;
        }    

        Debug.Log("Bridge reset to start state");
    }

    public void BridgeActivation(string tag)
    {
        mainside.isOnBridge = !mainside.isOnBridge;
        otherside.isOnBridge = !otherside.isOnBridge;

        // ON
        for (int i = 0; i < startTheseCollidersOn.Length; i++)
        {
            if (startTheseCollidersOn[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = !edge.enabled;
            if (startTheseCollidersOn[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = !box.enabled;
            if (startTheseCollidersOn[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = !poly.enabled;
            
        }

        // OFF
        for (int i = 0; i < startTheseCollidersOff.Length; i++)
        {
            if (startTheseCollidersOff[i].TryGetComponent<EdgeCollider2D>(out EdgeCollider2D edge)) edge.enabled = !edge.enabled;
            if (startTheseCollidersOff[i].TryGetComponent<BoxCollider2D>(out BoxCollider2D box)) box.enabled = !box.enabled;
            if (startTheseCollidersOff[i].TryGetComponent<PolygonCollider2D>(out PolygonCollider2D poly)) poly.enabled = !poly.enabled;
        }

        // OTHER STUFF
        for (int i = 0; i < bridgeTilemap.Length; i++)
        {
            if (mainside.isOnBridge == false) bridgeTilemap[i].GetComponent<Renderer>().sortingOrder = +3;

            else if (mainside.isOnBridge == true) bridgeTilemap[i].GetComponent<Renderer>().sortingOrder = -3;
        }
    }

}




