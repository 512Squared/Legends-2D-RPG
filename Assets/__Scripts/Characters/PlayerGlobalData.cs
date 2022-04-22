using UnityEngine;


public class PlayerGlobalData : MonoBehaviour
{
    public static PlayerGlobalData Instance;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private Animator playerAnimator;

    public string arrivingAt;

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

    private void Update()
    {
        controllerSwitch = MenuManager.Instance.controlSwitch;

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

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        _bottomLeftEdge = bottomEdgeToSet;
        _topRightEdge = topEdgeToSet;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Character")) { return; }

        if (collision.gameObject.GetComponent<PlayerStats>().isAvailable != false) { return; }

        Debug.Log(collision.gameObject.GetComponent<PlayerStats>().playerName + " is now available");
        collision.gameObject.GetComponentInChildren<PlayerStats>().isAvailable = true;
        MenuManager.Instance.UpdateItemsInventory();
        NotificationFader.instance.CallFadeInOut(
            collision.gameObject.GetComponent<PlayerStats>().playerName +
            " is now available to add to your character party!",
            collision.gameObject.GetComponent<PlayerStats>().characterPlain,
            3.4f,
            1000, 30);
        if (_characterParty < 3)
        {
            _characterParty++;
        }

        if (_characterParty == 2)
        {
            Actions.MarkQuestCompleted?.Invoke("Add two people to your character party");
        }
    }
}