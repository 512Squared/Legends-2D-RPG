using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class LightController : MonoBehaviour
{

    [SerializeField] Light2DE[] nearbyLights;
    public bool isShadowWanted = true;
    public bool isShadowOn = true;
    public bool isEastWest;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nearbyLights.Length; i++)
        {
            nearbyLights[i].shadowsEnabled = true;
        }

        

    }

    public void EnableShadows()
    {
        for (int i = 0; i < nearbyLights.Length; i++)
        {
            nearbyLights[i].shadowsEnabled = true;
        }
    }

    public void DisableShadows()
    {
        for (int i = 0; i < nearbyLights.Length; i++)
        {
            nearbyLights[i].shadowsEnabled = false;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isShadowWanted == false && isShadowOn == true)
        {
            DisableShadows();
            isShadowOn = !isShadowOn;
            isShadowWanted = !isShadowWanted;
            this.transform.position = new Vector3(transform.position.x+1.5f, transform.position.y); 
        }

        else if (collision.tag == "Player" && isShadowWanted == true && isShadowOn == false)
        {
            EnableShadows();
            isShadowOn = !isShadowOn;
            isShadowWanted = !isShadowWanted;
            this.transform.position = new Vector3(transform.position.x-1.5f, transform.position.y); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
