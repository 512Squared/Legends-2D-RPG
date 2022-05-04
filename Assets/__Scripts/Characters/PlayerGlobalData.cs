using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGlobalData : MonoBehaviour, ISaveable
{
    public static PlayerGlobalData Instance;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private Animator playerAnimator;

    public int currentSceneIndex;

    public string arrivingAt;

    private Toggle _toggle;

    public bool deactivedMovement;

    private Vector3 _bottomLeftEdge;
    private Vector3 _topRightEdge;

    public bool controllerSwitch;

    private float _horizontalMovement;
    private float _verticalMovement;

    private int _characterParty;

    private static readonly int LastX = Animator.StringToHash("lastX");
    private static readonly int LastY = Animator.StringToHash("lastY");
    private static readonly int MovementX = Animator.StringToHash("movementX");
    private static readonly int MovementY = Animator.StringToHash("movementY");


    // Start is called before the first frame update


    private void Start()
    {
        Instance = this;
        _toggle = GameObject.FindGameObjectWithTag("controllerToggle").GetComponent<Toggle>();
    }


    private void Update()
    {
        AndroidController();

        if (deactivedMovement)
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            playerRigidBody.velocity = new Vector2(_horizontalMovement, _verticalMovement) * moveSpeed;
        }

        playerAnimator.SetFloat(MovementX, playerRigidBody.velocity.x);
        playerAnimator.SetFloat(MovementY, playerRigidBody.velocity.y);

        if (_horizontalMovement is 1 or -1 || _verticalMovement is 1 or -1)
        {
            if (!deactivedMovement)
            {
                playerAnimator.SetFloat(LastX, _horizontalMovement);
                playerAnimator.SetFloat(LastY, _verticalMovement);
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _bottomLeftEdge.x, _topRightEdge.x),
            Mathf.Clamp(transform.position.y, _bottomLeftEdge.y, _topRightEdge.y),
            Mathf.Clamp(transform.position.z, _bottomLeftEdge.z, _topRightEdge.z)
        );

        MenuManager.Instance.HomeScreenStats();
    }

    private void AndroidController()
    {
        switch (controllerSwitch)
        {
            case false:
                _horizontalMovement = Input.GetAxisRaw("Horizontal");
                _verticalMovement = Input.GetAxisRaw("Vertical");
                break;
            case true:
                _horizontalMovement = UltimateJoystick.GetHorizontalAxis("Joy");
                _verticalMovement = UltimateJoystick.GetVerticalAxis("Joy");
                break;
        }
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        _bottomLeftEdge = bottomEdgeToSet;
        _topRightEdge = topEdgeToSet;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Character")) { return; }

        AddTwoToPartyQuest();

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
        if (_characterParty < 3)
        {
            _characterParty++;
            Debug.Log($"Player added to character party: {_characterParty}");
        }

        if (_characterParty == 2)
        {
            Actions.MarkQuestCompleted?.Invoke("e32408e2-2d2f-4413-a6a9-75eb6e9a4331");
        }
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        a_SaveData.thulgranData.controllerSwitch = controllerSwitch;
        a_SaveData.thulgranData.moveSpeed = moveSpeed;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        _toggle.isOn = a_SaveData.thulgranData.controllerSwitch;
        moveSpeed = a_SaveData.thulgranData.moveSpeed;
    }

    #endregion
}