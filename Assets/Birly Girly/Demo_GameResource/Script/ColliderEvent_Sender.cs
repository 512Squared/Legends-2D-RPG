using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent_Sender : MonoBehaviour {
    private CharacterController_2D m_parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        //if (m_parent.Once_Attack)
        //    return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController_2D>().Hitted();
            Debug.Log("hit::" + other.name);

        }
        else if (other.CompareTag("Monster"))
        {


            other.GetComponent<WoodDoll_Mgr>().Hitted();
            Debug.Log("hit::" + other.name);


        }

    
    }


}
