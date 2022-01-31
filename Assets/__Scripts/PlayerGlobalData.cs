using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PlayerGlobalData : MonoBehaviour
{
    public static PlayerGlobalData instance;

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] int moveSpeed = 1;
    [SerializeField] Animator playerAnimator;

    public string arrivingAt;

    public bool deactivedMovement = false;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public bool controllerSwitch = false;

    float horizontalMovement;
    float verticalMovement;


    // Start is called before the first frame update


    void Start()
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

    void Update()
    {

        controllerSwitch = MenuManager.instance.controlSwitch;

        AndroidController();

        if (deactivedMovement == true)
        {
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        playerAnimator.SetFloat("movementX", playerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.velocity.y);

        if(horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            
            if(!deactivedMovement)
            {
                playerAnimator.SetFloat("lastX", horizontalMovement);
                playerAnimator.SetFloat("lastY", verticalMovement);
            }

        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),            
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)         
        );

        MenuManager.instance.HomeScreenStats();

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
                MenuManager.instance.UpdateItemsInventory();
                NotificationFader.instance.CallFadeInOut(collision.gameObject.GetComponent<PlayerStats>().playerName + " is now available to add to your character party!",
                collision.gameObject.GetComponent<PlayerStats>().characterPlain,
                3.4f,
                1000);
            }
        }
    }

}


