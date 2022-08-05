using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ZombieController : MonoBehaviour
{
    #region Fields

    public float speed = 1f;

    public float chaseRange;

    [SerializeField]
    private float attackRange;

    [Space]
    public float attackRadius;

    private int updateCount;
    private int randomRange;

    [SerializeField]
    private int damageAmount;

    private IAstarAI aiPath;

    private Vector3 dir;

    [Header("Bools")]
    public bool isInChaseRange;

    public bool isInAttackRange;
    private bool increasedChaseRadius;
    public bool debuggingOn;

    [Header("Components")]
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform crossHairs;

    [Space]
    public LayerMask playerLayer;

    public LayerMask enemyLayer;


    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int InAttackRange = Animator.StringToHash("inAttackRange");
    private static readonly int InChaseRange = Animator.StringToHash("inChaseRange");
    private static readonly int AttackY = Animator.StringToHash("attackY");
    private static readonly int AttackX = Animator.StringToHash("attackX");

    public double offset;
    private static readonly int IdleX = Animator.StringToHash("idleX");
    private static readonly int IdleY = Animator.StringToHash("idleY");

    private bool isSeekingPath;

    [SerializeField]
    private int hitBonus;

    [SerializeField]
    private List<Transform> positions;

    [SerializeField]
    private List<PlayerStats> playerList;

    [SerializeField]
    private List<Vector3> positionList;

    #endregion


    private void Start()
    {
        speed = 2.0f;
        aiPath = GetComponent<IAstarAI>();
        aiPath.maxSpeed = speed;
        playerList = GameManager.Instance.GetPlayerStats().ToList();
        positions = new List<Transform>();
        Wandering();
    }

    private void Update()
    {
        Foregrounding();
    }

    private void FixedUpdate()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, chaseRange, playerLayer.value);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer.value);

        anim.SetBool(InChaseRange, isInChaseRange);
        anim.SetBool(InAttackRange, isInAttackRange);

        if (!isInAttackRange && !isInChaseRange)
        {
            Wandering();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            aiPath.maxSpeed = 2f;
            anim.SetFloat(MoveX, dir.x);
            anim.SetFloat(MoveY, dir.y);
            if (debuggingOn) { Debug.Log("Is Wandering"); }
        }

        if (isInChaseRange && !isInAttackRange)
        {
            Chasing();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(MoveX, dir.x);
            anim.SetFloat(MoveY, dir.y);
            aiPath.maxSpeed = 3f;
            if (debuggingOn) { Debug.Log("Is Chasing"); }
        }

        if (isInAttackRange)
        {
            //collider.enabled = isInAttackRange;
            Attacking();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(AttackX, dir.x);
            anim.SetFloat(AttackY, dir.y);
            if (debuggingOn) { Debug.Log("Is Attacking"); }
        }

        if (!isInAttackRange && aiPath.reachedEndOfPath)
        {
            anim.SetBool(IsWalking, false);
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(IdleX, dir.x);
            anim.SetFloat(IdleY, dir.y);
        }
    }


    private void Wandering()
    {
        aiPath.canMove = true;
        anim.SetBool(IsWalking, true);
        if (updateCount == randomRange) // find random path
        {
            updateCount = 0;
            randomRange = Random.Range(800, 1000);
            int randomInt = Random.Range(0, 1);
            if (randomInt != 0) { }
            else
            {
                if (!aiPath.pathPending && (aiPath.reachedEndOfPath || !aiPath.hasPath))
                {
                    aiPath.destination = PickRandomPoint();
                    aiPath.SearchPath();
                }
            }
        }


        updateCount++;
    }

    private void Chasing()
    {
        anim.SetBool(IsWalking, true);
        switch (isSeekingPath)
        {
            case false:
                isSeekingPath = true;
                aiPath.destination = GetClosestTarget();
                aiPath.SearchPath();
                aiPath.maxSpeed = speed;
                Debug.Log(
                    $"Target path found: {target.name} | AI Destination: {aiPath.destination}");
                break;
            case true:
                {
                    if (!aiPath.pathPending && (aiPath.reachedEndOfPath || !aiPath.hasPath)) { isSeekingPath = false; }

                    break;
                }
        }
    }

    private void Attacking()
    {
        anim.SetBool(IsWalking, false);

        if (!increasedChaseRadius)
        {
            chaseRange += 10;
            increasedChaseRadius = true;
        }

        aiPath.maxSpeed = 0f;
    }

    private void Foregrounding()
    {
        if (transform.position.y < target.transform.position.y * offset)
        {
            SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
            SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

            if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder + 1; }

            if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder = +1; }
        }
        else
        {
            SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
            SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

            if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder - 1; }

            if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder = -1; }
        }
    }

    private Vector3 GetClosestTarget()
    {
        Debug.Log("GetClosestTarget called");
        playerList.Clear();
        positions.Clear();
        positionList.Clear();

        playerList = GameManager.Instance.GetPlayerStats().ToList();

        foreach (Transform position in from player in playerList
                 where player.isTeamMember
                 select player.GetComponent<Transform>()
                 into position
                 where position != null
                 select position) { positions.Add(position); }

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        if (debuggingOn) { Debug.Log($":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"); }

        int count = 0;
        foreach (Transform potentialTarget in positions)
        {
            if (debuggingOn) { Debug.Log($"Player: {potentialTarget.transform.name}"); }

            Vector2 directionToTarget = (Vector2)potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (debuggingOn) { Debug.Log($"Distance: {dSqrToTarget} -- Previous Best: {closestDistanceSqr}"); }

            positionList.Add(directionToTarget);
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }

            if (bestTarget && debuggingOn) { Debug.Log($"Best target: {bestTarget.name}"); }

            if (count <= positions.Count - 2)
            {
                if (debuggingOn) { Debug.Log($"·········································"); }

                count++;
            }
        }

        switch (playerList.Count)
        {
            case 1:
                target = PlayerGlobalData.Instance.transform.gameObject.GetComponent<AITarget>().transform;
                crossHairs.position = target.position;
                return target.position;
            case > 1:
                target = bestTarget;
                if (target)
                {
                    AITarget aiTarget = target.GetComponentInChildren<AITarget>();
                    if (aiTarget != null)
                    {
                        crossHairs.position = aiTarget.transform.position;
                    }

                    return aiTarget.transform.position;
                }

                return Vector3.zero;
        }

        return Vector3.zero;
    }

    private static Vector2 PickRandomPoint()
    {
        GridGraph gg = AstarPath.active.data.gridGraph;

        for (int i = 0; i < 1000; i++)
        {
            GridNode node = gg.nodes[Random.Range(0, gg.nodes.Length)];
            if (node.Walkable)
            {
                Vector3 pos = (Vector3)node.position;
                Debug.Log($"New random point found: {pos} | Scene: {GameManager.Instance.objectInt}");
                return pos;
            }
        }

        // Could not find a point after 1000 tries, is the whole graph unwalkable perhaps?
        Debug.Log($"Random points not found");
        return Vector2.zero;
    }

    public void Attack(string direction)
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

        Debug.Log($"Attack method called | Colliders found: {objs.Length}");

        {
            foreach (Collider2D obj in objs)
            {
                if (obj.GetComponent<PlayerStats>().characterHp > 1)
                {
                    if (obj.TryGetComponent(out IDamageable hit))
                    {
                        int critical = Random.Range(0, hitBonus);
                        bool criticalHit = critical > hitBonus / 2;
                        DamagePopup.Create(hit.GetPositionOfHead(), damageAmount + critical, criticalHit);
                        hit.Damage(damageAmount + critical);
                        Debug.Log($"Target has been hit: {hit.Combatant}");
                    }
                }
            }
        }
    }
}