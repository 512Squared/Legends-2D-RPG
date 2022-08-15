using System.Numerics;
using Assets.HeroEditor4D.Common.CharacterScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerGlobalData : MonoBehaviour, ISaveable, IDamageable
{
    #region Fields

    public static PlayerGlobalData Instance;

    [Title("Components")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Character4D character;
    [SerializeField] private AnimationManager anim;
    [SerializeField] private AudioSource audioSrc;

    [Space]
    [Title("Fields")]
    public Vector3 playerTrans;

    [SerializeField] private int moveSpeed;

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

    private bool isMoving;
    public bool isWalking;
    public bool isRunning;
    public bool isLoaded;


    private float xMove;
    private float yMove;

    private int characterParty;

    #endregion

    private static readonly int moveX = Animator.StringToHash("moveX");
    private static readonly int moveY = Animator.StringToHash("moveY");

    private void Start()
    {
        Instance = this;
        toggle = GameObject.FindGameObjectWithTag("controllerToggle").GetComponent<Toggle>();
        currentSceneIndex = 1;
        audioSrc = GetComponent<AudioSource>();
        character.SetDirection(Vector2.down);
        anim.SetState(CharacterState.Idle);
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
        AndroidController();

        switch (xMove)
        {
            case > 0:
                character.SetDirection(Vector2.right);
                break;
            case < 0:
                character.SetDirection(Vector2.left);
                break;
        }

        switch (yMove)
        {
            case > 0:
                character.SetDirection(Vector2.up);
                break;
            case < 0:
                character.SetDirection(Vector2.down);
                break;
        }

        if (deactivedMovement)
        {
            rb.velocity = Vector2.zero;
            anim.SetState(CharacterState.Idle);
        }
        else
        {
            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 8 : 4;
            rb.velocity = new Vector2(xMove, yMove) * moveSpeed;
            anim.Animator.SetFloat(moveX, rb.velocity.x);
            anim.Animator.SetFloat(moveY, rb.velocity.y);
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            isMoving = isWalking = true;
            anim.SetState(CharacterState.Walk);
            //Debug.Log($"Character state: Walk");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetState(CharacterState.Run);
                isRunning = true;
                isWalking = false;
                //Debug.Log($"Character state: Run");
            }
        }
        else
        {
            isMoving = isRunning = isWalking = false;
            anim.SetState(CharacterState.Idle);
            //Debug.Log($"Character state: Idle");
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
        Debug.Log($"isLoaded set to true: {isLoaded}");
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

    public void DeathAnimation()
    {
        character.AnimationManager.Die();
        MenuManager.Instance.DeathScene();
        //Time.timeScale = 0;
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetHeadPosition()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float height = sr.sprite.bounds.size.y + 0.2f;
        Vector3 headPosition = new(transform.position.x, transform.position.y + height, 0);
        return headPosition;
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

    #region Implementation of IDamageable

    public void Damage(int damage)
    {
        character.AnimationManager.Hit(); // hit animation
    }

    public Vector3 GetPositionOfHead()
    {
        return default;
    }

    public string Combatant => GetComponent<PlayerStats>().playerName;

    #endregion
}