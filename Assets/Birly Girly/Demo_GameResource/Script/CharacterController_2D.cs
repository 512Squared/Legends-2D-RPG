using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_2D : MonoBehaviour {

  


    
    Rigidbody2D m_rigidbody;
    Animator m_Animator;
    Transform m_tran;

    private float h = 0;
    private float v = 0;

    public float MoveSpeed = 40;

    public SpriteRenderer[] m_SpriteGroup;



    public CharacterID characterID = CharacterID.NONE; 

    // Use this for initialization
    void Start () {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        m_Animator = this.transform.Find("model").GetComponent<Animator>();
        m_tran = this.transform;
        m_SpriteGroup = this.transform.Find("model").GetComponentsInChildren<SpriteRenderer>(true);

  
    }

    private float UpdateTic = 0;

   
	// Update is called once per frame
	void Update () {

        UpdateTic += Time.deltaTime;
       
   


        if (UpdateTic > 0.01f)
        {

          
            spriteOrder_Controller();

            if (characterID != Demo_GM.Gm.characterid)
            {
                if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
                {
                    m_Animator.Play("Idle");
                    return;
                }
                return;
            }
          

           

            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(new Vector3 (this.transform.position.x, this.transform.position.y+3f, this.transform.position.z));
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * Demo_GM.Gm.CanvasUIRect.sizeDelta.x) - (Demo_GM.Gm.CanvasUIRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * Demo_GM.Gm.CanvasUIRect.sizeDelta.y) - (Demo_GM.Gm.CanvasUIRect.sizeDelta.y * 0.5f)));

            Debug.Log(Demo_GM.Gm.CanvasUIRect);

            Demo_GM.Gm.Pointer.anchoredPosition = WorldObject_ScreenPosition;
            // Input Key
            Keypad_Controller();




            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") ||
                m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") ||
                m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") ||
                m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                return;

            Move_Fuc();


            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            m_Animator.SetFloat("MoveSpeed", Mathf.Abs(h) + Mathf.Abs(v));




            UpdateTic = 0;

        }

      

 
    }

    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            //Debug.Log("y::" + this.transform.position.y);
            //  Debug.Log("sortingOrder::" + sortingOrder);
            for (int i = 0; i < m_SpriteGroup.Length; i++)
            {

                m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

            }

            Update_Tic = 0;
        }

     

    }

    //Input Keypad
    void Keypad_Controller()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Debug.Log("Lclick");
            m_Animator.SetTrigger("Attack");

            m_rigidbody.velocity = new Vector3(0, 0, 0);



        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Debug.Log("Rclick");
            m_Animator.SetTrigger("Attack2");

            m_rigidbody.velocity = new Vector3(0, 0, 0);

          
      

        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("1");
            m_Animator.Play("Hit");
     

        }

        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("2");
            m_Animator.Play("Die");

          

        }


  



    }
    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A))
        {
          //  Debug.Log("Left");
            m_rigidbody.AddForce(Vector2.left * MoveSpeed);
            if (B_FacingRight)
                Filp();



        }
        else if (Input.GetKey(KeyCode.D))
        {
          //  Debug.Log("Right");
            m_rigidbody.AddForce(Vector2.right * MoveSpeed);
            if (!B_FacingRight)
                Filp();


        }

        if (Input.GetKey(KeyCode.W))
        {
           // Debug.Log("up");
            m_rigidbody.AddForce(Vector2.up * MoveSpeed);

      

        }
        else if (Input.GetKey(KeyCode.S))
        {
           // Debug.Log("Down");
            m_rigidbody.AddForce(Vector2.down * MoveSpeed);


        }



    }


    // character Filp 
    bool B_Attack = false;
    bool B_FacingRight = true;

    void Filp()
    {
        B_FacingRight = !B_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        m_tran.localScale = theScale;
    }

    public void Hitted()
    {
        m_Animator.Play("Hit");

    }


  




}
