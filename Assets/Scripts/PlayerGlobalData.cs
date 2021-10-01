using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGlobalData : MonoBehaviour
{
    public static PlayerGlobalData instance;

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] int moveSpeed = 1;
    [SerializeField] Animator playerAnimator;

    public string arrivedAt;

    public bool deactivedMovement = false;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else 
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = UltimateJoystick.GetHorizontalAxis("Joy");
        float verticalMovement = UltimateJoystick.GetVerticalAxis("Joy");

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


                       
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }

}


