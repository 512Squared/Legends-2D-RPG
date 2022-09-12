using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

// ReSharper disable InconsistentNaming

public class NPCMovement : MonoBehaviour, ISetLimits
{
    #region Fields

    [Space]
    [ShowInInspector]
    public bool debugOn;

    [Title("Components")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Character4D character;
    [SerializeField] private AudioSource audioSrc;
    public GameObject activeBase;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Transform player;
    [SerializeField] private Transform home;

    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private PlayerStats stats;

    [SerializeField] private LayerMask enemyLayer;
    private IAstarAI aiPath;

    [SerializeField] public AIPath pathfinder;


    [SerializeField] private List<Transform> enemies;

    [SerializeField] private List<Collider2D> enemyList;

    [SerializeField] private List<Vector3> positionList;

    [Space]
    [Title("Fields")]
    [SerializeField] private int moveSpeed;

    [SerializeField] private int coolDown;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform target;
    [SerializeField] private bool isMakingAttack;
    [SerializeField] private float attackOffset;
    [SerializeField] private int hitBonus;
    [SerializeField] private int playerSlot;
    private float timeStamp;
    private string guid;

    [HideInInspector]
    public Vector3 bottomLeftEdge;

    [HideInInspector]
    public Vector3 topRightEdge;

    [Space] [Title("Bools")] [FoldoutGroup("Bools")]
    public bool deactivedMovement;

    [FoldoutGroup("Bools")]
    public bool isAlive;

    [FoldoutGroup("Bools")]
    public bool isAttacking;

    [FoldoutGroup("Bools")]
    public bool isLoaded;

    [FoldoutGroup("Bools")]
    public bool isPaused;

    [FoldoutGroup("Bools")]
    public bool hasTarget;

    [FoldoutGroup("Bools")]
    public bool peaceInOurTime;

    [FoldoutGroup("Bools")]
    [SerializeField] private bool isChasing;

    private int randomRange;
    private int updateCount;
    private Transform possibleTarget;

    #endregion

    private void Start()
    {
        character.AnimationManager.SetState(CharacterState.Idle);
        aiPath = GetComponent<IAstarAI>();
        pathfinder = GetComponent<AIPath>();
        isAlive = true;
        peaceInOurTime = true;
        guid = GetComponent<GenerateGUID>().GUID;
    }

    private void OnEnable()
    {
        Actions.OnSceneChange += SetLimitBool;
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= SetLimitBool;
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            deactivedMovement = true;
        }

        //Foregrounding();

        isAttacking = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
        isChasing = Physics2D.OverlapCircle(transform.position, chaseRange, enemyLayer);

        if (deactivedMovement || !isAlive) { return; }

        // Follow team
        if (stats.isTeamMember && Vector2.Distance(transform.position, player.position) > distanceToPlayer)
        {
            aiPath.destination = NpcController.Instance.GetFormationPosition(player.position, guid, transform.position);
            aiPath.SearchPath();
            // alternatively, pass formation position to pathfinder to avoid objects in scene
            Vector2 v = player.position - transform.position;
            character.AnimationManager.SetState(CharacterState.Run);
            if (!hasTarget) { SetDirection(v); }
        }

        else { character.AnimationManager.SetState(CharacterState.Idle); }

        CheckForEnemies();
    }


    private void RandomDirection()
    {
        if (updateCount == randomRange) // find random path
        {
            updateCount = 0;
            randomRange = Random.Range(20, 100);
            int randomInt = Random.Range(0, 1);
            if (randomInt != 0) { }
            else
            {
                int random = Random.Range(1, 4);
                int randomAdjustment = Random.Range(1, 10);
                int randomAdjustment2 = Random.Range(1, 10);
                Vector2 newPosition = new(transform.position.x + randomAdjustment, transform.position.y + randomAdjustment2);
                switch (random)
                {
                    case 1:
                        distanceToPlayer += randomAdjustment;
                        Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                        character.SetDirection(Vector2.up);
                        distanceToPlayer -= randomAdjustment;
                        break;
                    case 2:
                        distanceToPlayer += randomAdjustment;
                        Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                        character.SetDirection(Vector2.down);
                        distanceToPlayer -= randomAdjustment;
                        break;
                    case 3:
                        distanceToPlayer += randomAdjustment;
                        Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                        character.SetDirection(Vector2.right);
                        distanceToPlayer -= randomAdjustment;
                        break;
                    case 4:
                        distanceToPlayer += randomAdjustment;
                        Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                        character.SetDirection(Vector2.left);
                        distanceToPlayer -= randomAdjustment;
                        break;
                }
            }
        }

        updateCount++;
    }

    private void Update()
    {
        if (isPaused) { return; }


        if (isLoaded)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
                Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
                Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
            );
        }
    }

    private void CheckForEnemies()
    {
        possibleTarget = GetClosestEnemy(isChasing);

        switch (hasTarget)
        {
            case true when isChasing && !isAttacking:
                ChaseTarget(possibleTarget.position, false);
                break;
            case true when isAttacking:
                StartAttack();
                break;
        }
    }


    private Transform GetClosestEnemy(bool peace)
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, chaseRange, enemyLayer);
        positionList.Clear();
        enemyList = enemy.ToList();

        foreach (Collider2D position in enemyList)
        {
            // gets only targets that are not being attacked
            if (!position.GetComponent<EnemyStats>().isBeingAttacked)
            {
                enemies.Add(position.transform);
            }
        }

        if (enemies.Count == 0)
        {
            hasTarget = false;
            peaceInOurTime = true;
            return null;
        }

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        if (debugOn) { Debug.Log($":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"); }

        int count = 0;
        foreach (Transform potentialTarget in enemies)
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

            if (bestTarget)
            {
                //Debug.Log($"Best target: {bestTarget.name}");
            }

            if (count <= enemies.Count - 1)
            {
                if (debugOn) { Debug.Log($"·········································"); }

                count++;
            }
        }

        if (bestTarget != null)
        {
            bestTarget.GetComponent<EnemyStats>().isBeingAttacked = true;
            target = bestTarget;
        }

        hasTarget = true;
        peaceInOurTime = false;
        return target;
    }

    private void ChaseTarget(Vector3 enemyPosition, bool home)
    {
        Vector3 adjustedPosition = !home ? new Vector3(enemyPosition.x, enemyPosition.y + attackOffset, 0) : enemyPosition;
        aiPath.destination = adjustedPosition;
        aiPath.SearchPath();
        aiPath.maxSpeed = moveSpeed;
        Vector2 v = adjustedPosition - transform.position;
        SetDirection(v);
        if ((hasTarget && !isAttacking) || !aiPath.reachedDestination)
        {
            character.AnimationManager.SetState(CharacterState.Run);
        }
        else { character.AnimationManager.SetState(CharacterState.Idle); }
    }

    private void StartAttack()
    {
        character.AnimationManager.SetState(CharacterState.Idle);
        if (peaceInOurTime) { return; }

        if (timeStamp <= Time.time) { AttackAnimation(); }
    }

    public void AttackAnimation()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
        if (enemy != null && enemy.GetComponent<EnemyStats>().HitPoints < 1) { return; }

        // has a cool down so that number of attacks can be controlled
        if (!isMakingAttack)
        {
            timeStamp = Time.time + coolDown;
            character.AnimationManager.Slash1H();
            AttackTarget(enemy);
        }

        if (GameManager.Instance.battle) { Debug.Log($"Attack animation called"); }
    }

    public void IsMakingAnAttack()
    {
        // this looks like it isn't being called anywhere, but it's activated by an animation event
        isMakingAttack = !isMakingAttack;
    }

    public void AttackTarget(Collider2D enemy)
    {
        if (enemy == null) { return; }

        if (enemy.GetComponent<EnemyStats>().HitPoints < 1) { return; }

        int totalDamage;

        enemy.TryGetComponent(out IDamageable hit);
        int critical = Random.Range(0, hitBonus);
        bool criticalHit = critical > hitBonus / 2;
        if (criticalHit) { totalDamage = stats.characterAttackTotal + critical; }
        else { totalDamage = stats.characterAttackTotal; }

        if (totalDamage > 0) { hit.Damage(totalDamage); }

        if (enemy.GetComponent<EnemyStats>().HitPoints < 1)
        {
            hasTarget = false;
            peaceInOurTime = true;
            enemyList.Clear();
            enemies.Clear();
            positionList.Clear();
            Debug.Log($"::::::::::::::::::::::Zombie has died::::::::::::::::::::::::::::");
        }

        if (debugOn) { Debug.Log($"Target has been hit: {hit.Combatant}"); }
    }

    private void Foregrounding()
    {
        if (player != null)
        {
            SortingGroup targetSortingGroup = player.GetComponent<SortingGroup>();
            if (transform.position.y * offsetX < player.transform.position.y * offsetY)
            {
                if (targetSortingGroup) { sortingGroup.sortingOrder = targetSortingGroup.sortingOrder + 1; }
            }
            else
            {
                if (targetSortingGroup) { sortingGroup.sortingOrder = targetSortingGroup.sortingOrder - 1; }
            }
        }
    }

    private void SetDirection(Vector2 v)
    {
        float a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        int index = (int)((Mathf.Round(a / 90f) + 4) % 4);

        switch (index)
        {
            case 0:
                character.SetDirection(Vector2.right);
                break;
            case 1:
                character.SetDirection(Vector2.up);
                break;
            case 2:
                character.SetDirection(Vector2.left);
                break;
            case 3:
                character.SetDirection(Vector2.down);
                break;
        }
    }

    public void SetLimits(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
        isLoaded = true;
    }

    public void SetPhotoBoothLimit()
    {
        bottomLeftEdge = Vector3.positiveInfinity;
        topRightEdge = Vector3.positiveInfinity;
    }

    private void SetLimitBool(string arg1, string arg4, int arg2, int arg3)
    {
        isLoaded = true;
        if (debugOn) { Debug.Log($"isLoaded set to true: {isLoaded}"); }
    }

    public void Death()
    {
        isAlive = false;
        deactivedMovement = true;
        character.AnimationManager.SetState(CharacterState.Death);
        Debug.Log($"Death animation called");
        MenuManager.Instance.DeathScene();
        PlayerStats playerStats = GetComponent<PlayerStats>();
        playerStats.isTeamMember = false;
        playerStats.isAvailable = false;
        deactivedMovement = true;
        GetComponent<ShadowCaster2D>().enabled = false;
        activeBase.SetActive(false);
        capsuleCollider.enabled = false;
    }
}