using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] float moveSpeed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        
        playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

    }
}
