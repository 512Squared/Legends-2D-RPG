using Assets.HeroEditor4D.Common.CharacterScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using HeroEditor4D.Common.Enums;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using DG.Tweening;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

// ReSharper disable InconsistentNaming

public class PlayerGlobalData : MonoBehaviour, ISaveable
{
    #region Fields

    public static PlayerGlobalData Instance;

    [Space]
    [ShowInInspector]
    public bool debugOn;


    [Title("Components")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Character4D character;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject activeBase;
    [SerializeField] private CapsuleCollider2D capsuleCollider;


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

    private Toggle toggle;

    private int accelerate;


    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [Space]
    [Title("Bools")]
    public bool deactivedMovement;

    public bool controllerSwitch;

    public bool isAlive;
    private bool isMoving;
    public bool isWalking;
    public bool isRunning;
    public bool isAttacking;
    public bool isLoaded;


    private float xMove;
    private float yMove;

    private int characterParty;

    #endregion

    private static readonly int moveX = Animator.StringToHash("moveX");
    private static readonly int moveY = Animator.StringToHash("moveY");
    private bool isJumping;

    private void Start()
    {
        Instance = this;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        toggle = GameObject.FindGameObjectWithTag("controllerToggle").GetComponent<Toggle>();
        currentSceneIndex = 1;
        character.SetDirection(Vector2.down);
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
        if (deactivedMovement && !isAlive) { return; }

        AndroidController();

        switch (yMove)
        {
            case > 0:
                if (yMove > xMove) { character.SetDirection(Vector2.up); }

                break;
            case < 0:
                if (yMove < xMove) { character.SetDirection(Vector2.down); }

                break;
        }

        switch (xMove)
        {
            case > 0:
                if (xMove > yMove) { character.SetDirection(Vector2.right); }

                break;
            case < 0:
                if (xMove < yMove) { character.SetDirection(Vector2.left); }

                break;
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

        if (Input.GetMouseButtonDown(0)) { AttackAnimation(); }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            character.AnimationManager.SetState(CharacterState.Jump);
            float yPos = transform.position.y;
            if (character.Direction == Vector2.left)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(rb.DOJump(new Vector3(transform.position.x - jumpDistance, transform.position.y, 0),
                        jumpPower, 1,
                        jumpTime))
                    .SetEase(Ease.Linear);
                sequence.Insert(0,
                    activeBase.transform.DOMove(new Vector3(transform.position.x - jumpDistance, yPos, 0), jumpTime));
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            deactivedMovement = true;
            return;
        }

        if (deactivedMovement)
        {
            rb.velocity = Vector2.zero;
            if (isAlive) { character.AnimationManager.SetState(CharacterState.Idle); }
        }
        else
        {
            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 8 : 4;
            rb.velocity = new Vector2(xMove, yMove) * moveSpeed;
            character.AnimationManager.Animator.SetFloat(moveX, rb.velocity.x);
            character.AnimationManager.Animator.SetFloat(moveY, rb.velocity.y);
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

    private void AndroidController()
    {
        switch (controllerSwitch)
        {
            case false:
                xMove = Input.GetAxisRaw("Horizontal");
                yMove = Input.GetAxisRaw("Vertical");
                break;
            case true:
                xMove = UltimateJoystick.GetHorizontalAxis("Joy");
                yMove = UltimateJoystick.GetVerticalAxis("Joy");
                break;
        }
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
        isLoaded = true;
    }

    private void SetLimitBool(string arg1, string arg4, int arg2, int arg3)
    {
        isLoaded = true;
        if (debugOn) { Debug.Log($"isLoaded set to true: {isLoaded}"); }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Character")) { return; }

        if (!collision.gameObject.GetComponent<PlayerStats>().isAvailable) { AddTwoToPartyQuest(); }

        if (collision.gameObject.GetComponent<PlayerStats>().isAvailable) { return; }

        AddToParty(collision);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Player attack started");
        }
    }

    private static void AddToParty(Collision2D collision)
    {
        Debug.Log(collision.gameObject.GetComponent<PlayerStats>().playerName + " is now available");
        collision.gameObject.GetComponentInChildren<PlayerStats>().isAvailable = true;
        MenuManager.Instance.UpdateItemsInventory();
        NotificationFader.instance.CallFadeInOut(
            collision.gameObject.GetComponent<PlayerStats>().playerName +
            " is now available to add to your character party!",
            collision.gameObject.GetComponent<PlayerStats>().characterPlain,
            3.4f,
            1000, 30);
    }

    private void AddTwoToPartyQuest()
    {
        if (characterParty < 3)
        {
            characterParty++;
            Debug.Log($"Player added to character party: {characterParty}");
        }

        if (characterParty == 2)
        {
            Actions.MarkQuestCompleted?.Invoke("e32408e2-2d2f-4413-a6a9-75eb6e9a4331");
        }
    }

    public void Death()
    {
        isAlive = false;
        deactivedMovement = true;
        character.AnimationManager.SetState(CharacterState.Death);
        foreach (Transform child in transform) { child.gameObject.layer = 0; }

        transform.gameObject.layer = 0;
        Debug.Log("Death animation called");
        MenuManager.Instance.DeathScene();
        PlayerStats player = GetComponent<PlayerStats>();
        player.isTeamMember = false;
        player.isAvailable = false;
        deactivedMovement = true;
        GetComponent<ShadowCaster2D>().enabled = false;
        activeBase.SetActive(false);
        capsuleCollider.enabled = false;
        Debug.Log("Death method completed");
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        playerTrans = transform.position;
        a_SaveData.thulgranData.controllerSwitch = controllerSwitch;
        //a_SaveData.thulgranData.moveSpeed = moveSpeed;
        a_SaveData.thulgranData.position = playerTrans;
        Debug.Log($"Thulgran's save position: {playerTrans}");
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        toggle.isOn = a_SaveData.thulgranData.controllerSwitch;
        //moveSpeed = a_SaveData.thulgranData.moveSpeed;
        playerTrans = a_SaveData.thulgranData.position;
        transform.position = playerTrans;
    }

    #endregion
}