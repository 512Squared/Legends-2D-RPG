using UnityEngine;
using Pathfinding;

public class ZombieController : MonoBehaviour
{
    public float speed = 1f;

    public float chaseRadius;
    public float attackRadius;

    [SerializeField] private AIPath aiPath;

    public bool shouldRotate;

    private Animator anim;
    public Vector3 dir;

    private float lastX;
    private float lastY;

    public bool isInChaseRange;
    public bool isInAttackRange;

    private bool increasedChaseRadius;

    [SerializeField]
    private Transform target;

    public LayerMask playerLayer;

    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int InAttackRange = Animator.StringToHash("inAttackRange");
    private static readonly int InChaseRange = Animator.StringToHash("inChaseRange");

    private void Start()
    {
        speed = 3.0f;
        aiPath.maxSpeed = speed;
        anim = GetComponent<Animator>();
        anim.SetFloat(MoveY, -1);
        anim.SetBool(IsWalking, false);
        //transform.localScale = new Vector3(transform.localScale.x, -1, 0);
    }


    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, chaseRadius, playerLayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayer);

        if (isInChaseRange && !isInAttackRange)
        { 
            dir = aiPath.desiredVelocity; // desired velocity points in the direction of movement
        }
        else if (isInAttackRange) { dir = target.position - transform.position; }

        dir.Normalize();
        if (shouldRotate)
        {
            anim.SetFloat(MoveX, dir.x);
            anim.SetFloat(MoveY, dir.y);
        }

        anim.SetBool(InChaseRange, isInChaseRange);
        anim.SetBool(InAttackRange, isInAttackRange);

        aiPath.canMove = isInChaseRange;
    }

    private void FixedUpdate()
    {
        aiPath.maxSpeed = speed;
        if (isInAttackRange)
        {
            aiPath.canMove = false;
            if (!increasedChaseRadius)
            {
                chaseRadius += 10;
                increasedChaseRadius = true;
            }

            aiPath.maxSpeed = 0f;
        }
    }
}