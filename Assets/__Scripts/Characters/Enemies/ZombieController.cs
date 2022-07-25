using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CodeMonkey.Utils;
using UnityEngine;
using Pathfinding;
using Sirenix.Utilities;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

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

    private bool isUpdated;

    public bool isInChaseRange;
    public bool isInAttackRange;

    private bool increasedChaseRadius;

    [SerializeField]
    private AIDestinationSetter aiDestinationSetter;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Transform target;

    [SerializeField]
    private List<Transform> positions;

    [SerializeField]
    private List<PlayerStats> playerList;


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
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat(MoveY, -1);
        anim.SetBool(IsWalking, false);
        playerList = GameManager.Instance.GetPlayerStats().ToList();
        positions = new List<Transform>();
        GetClosestTarget();
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

        if (Input.GetMouseButtonDown(1))
        {
            bool boolean = Random.Range(0, 100) < 30;
            DamagePopup.Create(PlayerGlobalData.Instance.GetPositionOfHead(), 10, boolean);
        }
    }

    private void GetClosestTarget()
    {
        playerList.Clear();
        positions.Clear();
        playerList = GameManager.Instance.GetPlayerStats().ToList();

        foreach (PlayerStats player in playerList)
        {
            if (player.isTeamMember)
            {
                Transform position = player.GetComponent<Transform>();
                if (position != null) { positions.Add(position); }
            }
        }

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in positions)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        if (playerList.Count == 1)
        {
            target = PlayerGlobalData.Instance.transform;
            aiDestinationSetter.target = target;
        }
        else if (playerList.Count > 1)
        {
            target = bestTarget;
            aiDestinationSetter.target = bestTarget;
        }
    }

    private void FixedUpdate()
    {
        GetClosestTarget();

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

        if (transform.position.y < target.transform.position.y)
        {
            spriteRenderer.sortingOrder = target.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else
        {
            spriteRenderer.sortingOrder = target.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }
}