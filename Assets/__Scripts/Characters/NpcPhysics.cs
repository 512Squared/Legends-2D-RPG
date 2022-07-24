using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class NpcPhysics : MonoBehaviour
{
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public float speed;

    public float changeTime;

    private float timer;
    private int direction = 1;
    public bool startLeft;


    [SerializeField] private bool vertical;

    [SerializeField]
    private Transform characterTransform;

    private new Rigidbody2D rigidbody2D;


    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField]
    private GameObject teamBase;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        changeTime = 5.0f;
        timer = changeTime;
        speed = 1.0f;
        if (startLeft) { direction = -direction; }

        teamBase.SetActive(playerStats.isTeamMember);
    }

    public void IsTeamMember(bool isTeamMember)
    {
        playerStats.isTeamMember = isTeamMember;
        teamBase.SetActive(playerStats.isTeamMember);
    }


    private void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }
}