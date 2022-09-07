using Assets.HeroEditor4D.Common.CharacterScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

// ReSharper disable InconsistentNaming

public class NPCMovement : MonoBehaviour, ISaveable, ISetLimits
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
    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private PlayerStats stats;


    [Space]
    [Title("Fields")]
    public Vector3 playerTrans;

    [SerializeField] private int moveSpeed;
    [SerializeField] private float uiDamageOffset;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpDistance;


    public int currentSceneIndex;

    public string arrivingAt;

    public Vector3 bottomLeftEdge;
    public Vector3 topRightEdge;

    [Space]
    [Title("Bools")]
    public bool deactivedMovement;

    public bool isAlive;

    [SerializeField] private bool isMoving;
    public bool isWalking;
    public bool isRunning;
    public bool isAttacking;
    public bool isLoaded;
    public bool isPaused;

    public bool isJumping;

    private static readonly int moveX = Animator.StringToHash("moveX");
    private static readonly int moveY = Animator.StringToHash("moveY");
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float playerRadiusRange;

    #endregion

    private void Start()
    {
        character.AnimationManager.SetState(CharacterState.Idle);
        isAlive = true;
    }

    private void OnEnable()
    {
        Actions.OnSceneChange += SetLimitBool;
    }

    private void OnDisable()
    {
        Actions.OnSceneChange -= SetLimitBool;
    }

    private void Update()
    {
        Foregrounding();

        if (deactivedMovement && !isAlive) { return; }

        if (stats.isTeamMember && Vector2.Distance(transform.position, player.position) > distanceToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Vector2 v = player.position - transform.position;
            SetDirection(v);
        }


        void SetDirection(Vector2 v)
        {
            float a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            int index = (int)((Mathf.Round(a / 90f) + 4) % 4);

            character.AnimationManager.SetState(CharacterState.Walk);

            switch (index)
            {
                case 1:
                    character.SetDirection(Vector2.up);
                    break;
                case 3:
                    character.SetDirection(Vector2.down);
                    break;
                case 0:
                    character.SetDirection(Vector2.right);
                    break;
                case 2:
                    character.SetDirection(Vector2.left);
                    break;
            }
        }

        Collider nearestCollider = GetNearestEnemy();

        if (nearestCollider != null && nearestCollider.CompareTag("Enemy"))
        {
            AttackEnemy();
        }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
                if (isWalking) { AudioManager.Instance.mixerWalking.audioMixer.SetFloat("SFXWalking", 1.56f); }
                else if (isRunning) { AudioManager.Instance.mixerWalking.audioMixer.SetFloat("SFXWalking", 2.50f); }
            }
        }
        else { audioSrc.Stop(); }

        if (isLoaded)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
                Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
                Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
            );
        }
    }

    private Collider GetNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(player.position, playerRadiusRange);
        Collider nearestCollider = null;
        float minSqrDistance = Mathf.Infinity;
        for (int i = 0; i < colliders.Length; i++)
        {
            float sqrDistanceToCenter = (player.position - colliders[i].transform.position).sqrMagnitude;
            if (sqrDistanceToCenter < minSqrDistance)
            {
                minSqrDistance = sqrDistanceToCenter;
                nearestCollider = colliders[i];
            }
        }

        return nearestCollider;
    }

    private void AttackEnemy()
    {
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            deactivedMovement = true;
            return;
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            isMoving = isWalking = true;
            if (isAlive) { character.AnimationManager.SetState(CharacterState.Walk); }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (isAlive)
                {
                    character.AnimationManager.SetState(CharacterState.Run);
                    isRunning = true;
                    isWalking = false;
                }
            }
        }
        else
        {
            isMoving = isRunning = isWalking = false;
            if (isAlive) { character.AnimationManager.SetState(CharacterState.Idle); }
        }
    }

    private void AttackAnimation()
    {
        character.AnimationManager.Slash1H();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"NPC attack started");
        }
    }


    public void Death()
    {
        isAlive = false;
        deactivedMovement = true;
        character.AnimationManager.SetState(CharacterState.Death);
        Debug.Log($"Death animation called");
        MenuManager.Instance.DeathScene();
        PlayerStats player = GetComponent<PlayerStats>();
        player.isTeamMember = false;
        player.isAvailable = false;
        deactivedMovement = true;
        GetComponent<ShadowCaster2D>().enabled = false;
        activeBase.SetActive(false);
        capsuleCollider.enabled = false;
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        // playerTrans = transform.position;
        // a_SaveData.thulgranData.controllerSwitch = controllerSwitch;
        // //a_SaveData.thulgranData.moveSpeed = moveSpeed;
        // a_SaveData.thulgranData.position = playerTrans;
        // Debug.Log($"Thulgran's save position: {playerTrans}");
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        // toggle.isOn = a_SaveData.thulgranData.controllerSwitch;
        // //moveSpeed = a_SaveData.thulgranData.moveSpeed;
        // playerTrans = a_SaveData.thulgranData.position;
        // transform.position = playerTrans;
    }

    #endregion
}