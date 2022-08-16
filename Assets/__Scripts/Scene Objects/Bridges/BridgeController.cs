using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

#pragma warning disable 0649


public class BridgeController : MonoBehaviour
{
    [Header("BRIDGES & LEVELS")]
    [Space]
    [InfoBox(
        "The collider arrays below will take any number and type of collider: polygon, edge, box etc. Use colliders to match your needs. This prefab gives a complete switching system that allows your player to move above or below tilemap elements")]
    [Space]
    [Tooltip("Add colliders here that you want ON at start")]
    [SerializeField]
    private GameObject[] startTheseCollidersOn;

    [Space]
    [Tooltip("Add colliders here that you want OFF at start")]
    [SerializeField]
    private GameObject[] startTheseCollidersOff;

    [Space]
    [Tooltip("tilemap for top layer (e.g. bridge) tilemap parts")]
    [Space]
    [SerializeField]
    private Tilemap[] bridgeTilemap;

    [Space]
    [Space]
    [SerializeField]
    private Mainside mainside;

    [SerializeField] private Otherside otherside;

    [Space]
    public string playerName;

    private void Start()
    {
        // ON
        foreach (GameObject t in startTheseCollidersOn)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = true; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = true; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = true; }
        }

        // OFF
        foreach (GameObject t in startTheseCollidersOff)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = false; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = false; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = false; }
        }
    }


    public void Failsafe(Renderer player)
    {
        foreach (Tilemap t in bridgeTilemap)
        {
            t.GetComponent<TilemapRenderer>().sortingLayerName = "LitObjects";
        }

        // ON
        foreach (GameObject t in startTheseCollidersOn)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = true; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = true; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = true; }
        }

        // OFF
        foreach (GameObject t in startTheseCollidersOff)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = false; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = false; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = false; }
        }

        Debug.Log("Bridge reset to start state");
    }

    public void BridgeActivation()
    {
        mainside.isOnBridge = !mainside.isOnBridge;
        otherside.isOnBridge = !otherside.isOnBridge;

        // ON
        foreach (GameObject t in startTheseCollidersOn)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = !edge.enabled; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = !box.enabled; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = !poly.enabled; }
        }

        // OFF
        foreach (GameObject t in startTheseCollidersOff)
        {
            if (t.TryGetComponent(out EdgeCollider2D edge)) { edge.enabled = !edge.enabled; }

            if (t.TryGetComponent(out BoxCollider2D box)) { box.enabled = !box.enabled; }

            if (t.TryGetComponent(out PolygonCollider2D poly)) { poly.enabled = !poly.enabled; }
        }

        // OTHER STUFF
        foreach (Tilemap t in bridgeTilemap)
        {
            t.GetComponent<Renderer>().sortingLayerName = mainside.isOnBridge switch
            {
                false => "LitObjects",
                true => "Player"
            };
        }
    }
}