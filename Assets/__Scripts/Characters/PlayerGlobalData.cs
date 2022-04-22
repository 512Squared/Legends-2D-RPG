using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerGlobalData : MonoBehaviour
{
    public static PlayerGlobalData instance;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private Animator playerAnimator;

    public string arrivingAt;

    public bool deactivedMovement = false;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public bool controllerSwitch = false;

    private float horizontalMovement;
    private float verticalMovement;

    private _DateTime date;
    private Continental cont;

    private int characterParty = 0;
    private static readonly int LastX = Animator.StringToHash("lastX");
    private static readonly int LastY = Animator.StringToHash("lastY");
    private static readonly int MovementX = Animator.StringToHash("movementX");
    private static readonly int MovementY = Animator.StringToHash("movementY");


    // Start is called before the first frame update


    private void Start()
    {
        instance = this;
    }

    public void AndroidController()
    {
        if (controllerSwitch == false)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        if (controllerSwitch == true)
        {
            horizontalMovement = UltimateJoystick.GetHorizontalAxis("Joy");
            verticalMovement = UltimateJoystick.GetVerticalAxis("Joy");
        }
    }

    private void Update()
    {
        controllerSwitch = MenuManager.Instance.controlSwitch;

        AndroidController();

        if (deactivedMovement == true)
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        playerAnimator.SetFloat(MovementX, playerRigidBody.velocity.x);
        playerAnimator.SetFloat(MovementY, playerRigidBody.velocity.y);

        if (horizontalMovement is 1 or -1 || verticalMovement is 1 or -1)
        {
            if (!deactivedMovement)
            {
                playerAnimator.SetFloat(LastX, horizontalMovement);
                playerAnimator.SetFloat(LastY, verticalMovement);
            }
        }

        Vector3 position = transform.position;
        position = new Vector3(
            Mathf.Clamp(position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(position.z, bottomLeftEdge.z, topRightEdge.z)
        );
        transform.position = position;

        MenuManager.Instance.HomeScreenStats();

        PlayerTestInput(date, cont);

        Thulgran.ThulgranPosition = position;
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (collision.gameObject.GetComponent<PlayerStats>().isAvailable == false)
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
                if (characterParty < 3)
                {
                    characterParty++;
                }

                if (characterParty == 2)
                {
                    Actions.MarkQuestCompleted?.Invoke("Add two people to your character party");
                }
            }
        }
    }

    private void PlayerTestInput(_DateTime dateTime, Continental railwayTime)
    {
        // Trigger Advance Time
        if (Input.GetKey(KeyCode.T))
        {
            dateTime.AdvanceHourKey();
        }

        // Trigger Advance Day
        if (Input.GetKeyDown(KeyCode.G))
        {
            dateTime.AdvanceDayKey();
        }
    }
}