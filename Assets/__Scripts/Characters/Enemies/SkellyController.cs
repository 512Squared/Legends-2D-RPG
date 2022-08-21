using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Assets.HeroEditor4D.Common.CommonScripts;
using UnityEngine;
using Pathfinding;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine.Rendering;
using static GameAssets;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(GenerateGUID))]
public class SkellyController : MonoBehaviour, IDamageable, ISaveable
{
    #region Fields

    [Space]
    [ShowInInspector]
    public bool debugOn;

    [Title("Fields")]
    public float speed = 1f;

    public float chaseRange;

    public int hitPoints;

    public SceneObjectsLoad homeScene;

    public string guid;

    [Space]
    [SerializeField] private float attackRange;

    [Space] public float attackRadius;

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

    [SerializeField] private bool isAlive = true;

    // ReSharper disable once InconsistentNaming


    [Header("Components")]
    [SerializeField] private Animator anim;
    [SerializeField] private LayerManager layerManager;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Transform target;
    [SerializeField] private HealthBar healthBar;

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


    [SerializeField]
    private int hitBonus;

    [SerializeField]
    private List<Transform> positions;

    [SerializeField]
    private List<PlayerStats> playerList;

    [SerializeField]
    private List<Vector3> positionList;

    private bool isAttacking;

    private GameObject crosshairs;

    #endregion


    private void Start()
    {
        guid = GetComponent<GenerateGUID>().GUID;
        speed = 2.0f;
        aiPath = GetComponent<IAstarAI>();
        aiPath.maxSpeed = speed;
        playerList = GameManager.Instance.GetPlayerStats().ToList();
        positions = new List<Transform>();
        healthBar.SetMaxHealth(hitPoints);
        isAlive = true;
        crosshairs = Instantiate(Fetch.crosshairs, transform.position, quaternion.identity);
        crosshairs.transform.SetParent(transform, true);
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

        if (!isInAttackRange && !isInChaseRange && isAlive)
        {
            Wandering();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            aiPath.maxSpeed = 2f;
            anim.SetFloat(MoveX, dir.x);
            anim.SetFloat(MoveY, dir.y);
            if (debugOn) { Debug.Log("Is Wandering"); }
        }

        if (isInChaseRange && !isInAttackRange && isAlive)
        {
            Chasing();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(MoveX, dir.x);
            anim.SetFloat(MoveY, dir.y);
            aiPath.maxSpeed = 3f;
            if (debugOn) { Debug.Log("Is Chasing"); }
        }

        if (isInAttackRange && isAlive)
        {
            isAttacking = true;
            Attacking();
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(AttackX, dir.x);
            anim.SetFloat(AttackY, dir.y);
            if (debugOn) { Debug.Log("Is Attacking"); }
        }

        if (!isInAttackRange && isAlive)
        {
            anim.SetBool(IsWalking, false);
            dir = aiPath.desiredVelocity;
            dir.Normalize();
            anim.SetFloat(IdleX, dir.x);
            anim.SetFloat(IdleY, dir.y);
        }

        capsuleCollider.enabled = isInAttackRange;
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
                if (!isAttacking && !aiPath.pathPending && (aiPath.reachedEndOfPath || !aiPath.hasPath))
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
        aiPath.destination = GetClosestTarget();
        aiPath.SearchPath();
        aiPath.maxSpeed = speed;
        if (IsDead) { aiPath.canMove = false; }
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
        if (target != null)
        {
            if (transform.position.y < target.transform.position.y * offset)
            {
                SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
                SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

                //if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder + 1; }

                //if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder + 1; }
            }
            else
            {
                SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
                SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

                //if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder - 1; }

                //if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder - 1; }
            }
        }
    }

    private Vector3 GetClosestTarget()
    {
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

        if (debugOn) { Debug.Log($":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"); }

        int count = 0;
        foreach (Transform potentialTarget in positions)
        {
            if (debugOn) { Debug.Log($"Player: {potentialTarget.transform.name}"); }

            Vector2 directionToTarget = (Vector2)potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (debugOn) { Debug.Log($"Distance: {dSqrToTarget} -- Previous Best: {closestDistanceSqr}"); }

            positionList.Add(directionToTarget);
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }

            if (bestTarget && debugOn) { Debug.Log($"Best target: {bestTarget.name}"); }

            if (count <= positions.Count - 2)
            {
                if (debugOn) { Debug.Log($"·········································"); }

                count++;
            }
        }

        if (positions.Count == 0)
        {
            Wandering();
        }

        switch (playerList.Count)
        {
            case 1:
                target = PlayerGlobalData.Instance.transform.gameObject.GetComponent<AITarget>().transform;
                crosshairs.transform.position = target.position;
                return target.position;
            case > 1:
                target = bestTarget;
                if (target)
                {
                    AITarget aiTarget = target.GetComponentInChildren<AITarget>();
                    if (aiTarget != null)
                    {
                        crosshairs.transform.position = target.position;
                    }
                    return aiTarget.transform.position;
                }

                return Vector3.zero;
        }

        return Vector3.zero;
    }

    public void ChangeBridgeSortingLayer(string position)
    {
        // spriteRenderer.sortingOrder = position switch
        // {
        //     "over" => 3,
        //     "under" => -1,
        //     _ => spriteRenderer.sortingOrder
        // };
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

    public void Attack()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

        foreach (Collider2D obj in objs)
        {
            if (obj.TryGetComponent(out PlayerStats player))
            {
                if (player.characterHp > 1 && obj.TryGetComponent(out IDamageable hit))
                {
                    int critical = Random.Range(0, hitBonus);
                    bool criticalHit = critical > hitBonus / 2;
                    DamagePopup.Create(hit.GetPositionOfHead(), damageAmount + critical, criticalHit);
                    hit.Damage(damageAmount + critical);
                    if (debugOn) { Debug.Log($"Target has been hit: {hit.Combatant}"); }
                }
            }
        }
    }

    public void DeathDissolve()
    {
        Debug.Log($"Death dissolve called");
        StartCoroutine(DissolveBody());
    }

    private IEnumerator DissolveBody()
    {
        GetComponent<DissolveEffect>().StartDissolve(0.2f);
        yield return new WaitForSeconds(3f);
        this.SetActive(false);
        transform.position = Vector3.zero;
    }

    #region Implementation of IDamageable

    public void Damage(int damage)
    {
        if (hitPoints > 0)
        {
            hitPoints -= damage;
            if (hitPoints < 0) { hitPoints = 0; }
            healthBar.SetHealth(hitPoints);
        }

        if (hitPoints <= 0 && isAlive)
        {
            isAlive = false;
            IsDead = true;
            SpawnEnemies.Instance.SpawnSkelly();
            DeathDissolve();
        }
    }

    public Vector3 GetPositionOfHead()
    {
        return transform.position;
    }

    public string Combatant => "Zombie";


    public bool IsDead { get; set; }

    #endregion

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.EnemyData ed = new(guid, homeScene);

        a_SaveData.enemies.Add(ed);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
    }

    #endregion
}