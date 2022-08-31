using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor4D.Common.CommonScripts;
using UnityEngine;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine.Rendering;
using static GameAssets;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(GenerateGUID))]
public class ZombieController : MonoBehaviour, IDamageable, ISaveable
{
    #region Fields

    [Space]
    [ShowInInspector]
    public bool debugOn;

    [Title("Fields")]
    public float speed = 1f;

    public float chaseRange;

    public int hitPoints;

    public string guid;

    public SceneObjectsLoad homeScene;

    [Space]
    [SerializeField] private float attackAnimationsRange;

    [Space] public float attackDamageRadius;

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

    private bool isAlive;
    public bool crosshairsOn;


    // ReSharper disable once InconsistentNaming


    [Header("Components")]
    [SerializeField] private Animator anim;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Transform target;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private DissolveEffect dissolveEffect;


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

    public double offsetY;
    public double offsetX;
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
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    [SerializeField] private bool isPaused;
    private static readonly int IsDead = Animator.StringToHash("isDead");
    [SerializeField] private float dissolveSpeed;

    #endregion


    private void Start()
    {
        guid = GetComponent<GenerateGUID>().GUID;
        speed = 2.0f;
        IsAlive = true;
        aiPath = GetComponent<IAstarAI>();
        aiPath.maxSpeed = speed;
        playerList = GameManager.Instance.GetPlayerStats().ToList();
        positions = new List<Transform>();
        healthBar.SetMaxHealth(hitPoints);
        crosshairs = Instantiate(Fetch.crosshairs, transform.position, Quaternion.identity);
        crosshairs.transform.SetParent(transform, true);
        Wandering();
    }

    private void Update()
    {
        Foregrounding();
        crosshairsOn = GameManager.Instance.crosshairsOn;
    }

    private void FixedUpdate()
    {
        if (hitPoints == 0)
        {
            anim.SetBool(IsAttacking, false);
            anim.SetBool(IsWalking, false);
            isPaused = true;
        }

        if (GameManager.Instance.isPaused)
        {
            aiPath.canMove = false;
            return;
        }

        aiPath.canMove = true;

        isInChaseRange = Physics2D.OverlapCircle(transform.position, chaseRange, playerLayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackAnimationsRange, playerLayer);

        anim.SetBool(InChaseRange, isInChaseRange);
        anim.SetBool(InAttackRange, isInAttackRange);

        if (!isInAttackRange && !isInChaseRange && isAlive)
        {
            Wandering();
        }

        else if (isInChaseRange && !isInAttackRange && isAlive)
        {
            Chasing();
        }

        else if (isInAttackRange && isAlive)
        {
            Attacking();
        }

        capsuleCollider.enabled = isInAttackRange;
        crosshairs.GetComponent<SpriteRenderer>().enabled = crosshairsOn;
    }

    private void Attacking()
    {
        aiPath.maxSpeed = speed;
        dir = target.transform.position - transform.position;
        anim.SetBool(IsWalking, false);
        anim.SetBool(IsAttacking, true);
        anim.SetFloat(AttackX, dir.x);
        anim.SetFloat(AttackY, dir.y);
        IncreaseAttackRadius();
        if (!IsAlive)
        {
            aiPath.canMove = false;
        }
    }

    private void Wandering()
    {
        if (updateCount == randomRange) // find random path
        {
            updateCount = 0;
            randomRange = Random.Range(800, 1000);
            int randomInt = Random.Range(0, 1);
            if (randomInt != 0) { }
            else
            {
                if (!isAttacking && !aiPath.pathPending && (aiPath.reachedDestination || !aiPath.hasPath))
                {
                    aiPath.destination = PickRandomPoint();
                    aiPath.SearchPath();
                    Debug.Log(
                        $"Random Path called. PathPending: {aiPath.pathPending} | Reached end of path: {aiPath.reachedEndOfPath}| Reached destination: {aiPath.reachedDestination} | Has path:{aiPath.hasPath}");
                }
            }
        }

        updateCount++; // this is a clock tick for random destination calculations

        dir = aiPath.desiredVelocity;
        dir.Normalize();
        aiPath.maxSpeed = 2f;
        anim.SetBool(IsWalking, true);
        anim.SetBool(IsAttacking, false);
        anim.SetFloat(MoveX, dir.x);
        anim.SetFloat(MoveY, dir.y);

        aiPath.canMove = true;
        if (debugOn) { Debug.Log("Is Wandering"); }
    }

    private void Chasing()
    {
        aiPath.destination = GetClosestTarget();
        aiPath.SearchPath();
        aiPath.maxSpeed = speed;
        dir = aiPath.desiredVelocity;
        dir.Normalize();
        anim.SetBool(IsWalking, true);
        anim.SetBool(IsAttacking, false);
        anim.SetFloat(MoveX, dir.x);
        anim.SetFloat(MoveY, dir.y);
        aiPath.maxSpeed = 1f;
        if (!IsAlive) { aiPath.canMove = false; }

        if (debugOn) { Debug.Log("Is Chasing"); }
    }

    private void IncreaseAttackRadius()
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
            if (transform.position.y * offsetX < target.transform.position.y * offsetY)
            {
                SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
                SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

                if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder + 1; }

                if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder + 1; }
            }
            else
            {
                SpriteRenderer sortGroup = target.GetComponent<SpriteRenderer>();
                SortingGroup sortingGroup = target.GetComponent<SortingGroup>();

                if (sortGroup) { spriteRenderer.sortingOrder = sortGroup.sortingOrder - 1; }

                if (sortingGroup) { spriteRenderer.sortingOrder = sortingGroup.sortingOrder - 1; }
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

        if (positions.Count == 0)
        {
            Wandering();
            return Vector3.zero;
        }

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

        switch (playerList.Count)
        {
            case 1:
                target = PlayerGlobalData.Instance.GetComponentInChildren<AITarget>().transform;
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
        spriteRenderer.sortingOrder = position switch
        {
            "over" => 3,
            "under" => -1,
            _ => spriteRenderer.sortingOrder
        };
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
                Debug.Log($"New random point found: {pos} | Scene: {GameManager.Instance.sceneIndex}");
                return pos;
            }
        }

        // Could not find a point after 1000 tries, is the whole graph unwalkable perhaps?
        Debug.Log($"Random points not found");

        return Vector2.zero;
    }

    public void AttackTarget()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, attackDamageRadius, enemyLayer);

        foreach (Collider2D obj in objs)
        {
            if (obj.TryGetComponent(out PlayerStats player) && isAlive && player.characterHp > 1 &&
                obj.TryGetComponent(out IDamageable hit))
            {
                int critical = Random.Range(0, hitBonus);
                bool criticalHit = critical > hitBonus / 2;
                DamagePopup.Create(hit.GetPositionOfHead(), damageAmount + critical, criticalHit);
                hit.Damage(damageAmount + critical);
                isAttacking = false;
                if (debugOn) { Debug.Log($"Target has been hit: {hit.Combatant}"); }
            }
        }
    }


    #region Implementation of IDamageable

    public void Damage(int damage)
    {
        if (hitPoints > 0 && IsAlive)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                hitPoints = 0;
                anim.SetBool(IsDead, true);
                SpawnEnemies.Instance.SpawnZombie(25.5f, 100);
                IsAlive = false;
                isPaused = true;
                DeathDissolve();
                GameObject potion = Instantiate(Fetch.healingPotion,
                    GameManager.Instance.itemsForPickup[GameManager.Instance.sceneIndex], true);
                potion.transform.position = transform.position;
                Debug.Log($"Potion home: {potion.name}");
            }

            healthBar.SetHealth(hitPoints);
        }
    }

    public void DeathDissolve()
    {
        StartCoroutine(DissolveBody());
    }

    private IEnumerator DissolveBody()
    {
        yield return null;
        dissolveEffect.StartDissolve(dissolveSpeed);
        yield return new WaitForSeconds(3f);
        this.SetActive(false);
        Destroy(this);
    }

    public Vector3 GetPositionOfHead()
    {
        return transform.position;
    }

    public string Combatant => "Zombie";


    [ShowInInspector]
    public bool IsAlive
    {
        get => isAlive;
        set => isAlive = value;
    }

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