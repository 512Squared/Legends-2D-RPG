using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGlobalData : MonoBehaviour
{
    public static PlayerGlobalData instance;

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] int moveSpeed = 1;
    [SerializeField] Animator playerAnimator;

    public string arrivedAt;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;



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

        //topRightEdge = tilemap.localBounds.max + new Vector3(-0.7f,-2f,0f); 
        //bottomLeftEdge = tilemap.localBounds.min + new Vector3(1f,0.1f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
                
        playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        playerAnimator.SetFloat("movementX", playerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.velocity.y);

        if(horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }

        //transform.position = new Vector3(
        //    Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
        //    Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),            
        //    Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)         
        //);

    }



}


