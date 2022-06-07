using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Linq;
using __Scripts.Characters;

public class LevelManager : MonoBehaviour
{
    private Vector3 _bottomLeftEdge;
    private Vector3 _topRightEdge;

    public NPCPhysics[] npcCharacters;


    [SerializeField] private Tilemap tilemap;

    // Start is called before the first frame update
    private void Start()
    {
        Bounds localBounds = tilemap.localBounds;
        _topRightEdge = localBounds.max + new Vector3(-0.2f, -1.1f, 0f);
        _bottomLeftEdge = localBounds.min + new Vector3(1.5f, 1f, 0f);
        PlayerGlobalData.Instance.SetLimit(_bottomLeftEdge, _topRightEdge);
        npcCharacters = FindObjectsOfType<NPCPhysics>(true).ToArray();
        Debug.Log($"NPCs added to NPC Physics array");

        foreach (NPCPhysics npc in npcCharacters)
        {
            npc.SetLimit(_bottomLeftEdge, _topRightEdge);
        }
    }
}