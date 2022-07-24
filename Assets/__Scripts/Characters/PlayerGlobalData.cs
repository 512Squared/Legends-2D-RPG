using UnityEngine;
using UnityEngine.UI;

public class PlayerGlobalData : MonoBehaviour, ISaveable
{
    public static PlayerGlobalData Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private Animator playerAnimator;
    public Vector3 playerTrans;

    [SerializeField]
    private AudioSource audioSrc;

    public int currentSceneIndex;

    public string arrivingAt;

    private Toggle toggle;

    public bool deactivedMovement;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public bool controllerSwitch;
    public bool isMoving;
    public bool isLoaded;

    private float horizontalMovement;
    private float verticalMovement;

    private int characterParty;

    private static readonly int LastX = Animator.StringToHash("lastX");
    private static readonly int LastY = Animator.StringToHash("lastY");
    private static readonly int MovementX = Animator.StringToHash("movementX");
    private static readonly int MovementY = Animator.StringToHash("movementY");

    private void Start()
    {
        Instance = this;
        toggle = GameObject.FindGameObjectWithTag("controllerToggle").GetComponent<Toggle>();
        currentSceneIndex = 1;
        audioSrc = GetComponent<AudioSource>();
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
        if (deactivedMovement)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0) { isMoving = true; }
        else { isMoving = false; }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else { audioSrc.Stop(); }

        playerAnimator.SetFloat(MovementX, rb.velocity.x);
        playerAnimator.SetFloat(MovementY, rb.velocity.y);

        if (horizontalMovement is 1 or -1 || verticalMovement is 1 or -1)
        {
            if (!deactivedMovement)
            {
                playerAnimator.SetFloat(LastX, horizontalMovement);
                playerAnimator.SetFloat(LastY, verticalMovement);
            }
        }

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
                horizontalMovement = Input.GetAxisRaw("Horizontal");
                verticalMovement = Input.GetAxisRaw("Vertical");
                break;
            case true:
                horizontalMovement = UltimateJoystick.GetHorizontalAxis("Joy");
                verticalMovement = UltimateJoystick.GetVerticalAxis("Joy");
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


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetPositionOfHead()
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
        a_SaveData.thulgranData.moveSpeed = moveSpeed;
        a_SaveData.thulgranData.position = playerTrans;
        Debug.Log($"Thulgran's save position: {playerTrans}");
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        toggle.isOn = a_SaveData.thulgranData.controllerSwitch;
        moveSpeed = a_SaveData.thulgranData.moveSpeed;
        playerTrans = a_SaveData.thulgranData.position;
        transform.position = playerTrans;
    }

    #endregion
}