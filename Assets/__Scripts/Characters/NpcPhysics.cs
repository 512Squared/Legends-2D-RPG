using UnityEngine;

public class NpcPhysics : MonoBehaviour
{
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public float speed;

    public float changeTime;

    private int direction = 1;
    public bool startLeft;

    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField]
    private GameObject teamBase;


    private void Start()
    {
        if (startLeft) { direction = -direction; }

        teamBase.SetActive(playerStats.isTeamMember);
    }

    public void IsTeamMember(bool isTeamMember)
    {
        playerStats.isTeamMember = isTeamMember;
        teamBase.SetActive(playerStats.isTeamMember);
    }


    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }
}