using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Tilemaps;


public class LightController : MonoBehaviour
{
    [Header ("LIGHT CONTROLS")]
    [Space]
    [Space]
    [SerializeField] Light2D[] nearbyLights;
    [Space]
    public bool isShadowOn = true;

    enum DoorwayType
    {
        EastWest,
        NorthSouth,
        WestEast,
        SouthNorth
    }
    [Space]
    [SerializeField] DoorwayType doorwayType;
    
    [Space]
    [SerializeField] Tilemap shadowTileEbony;
    [SerializeField] Tilemap shadowTileIvory;
    
    [Space]
    public bool isEbonyOn = false;


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
        ShadowControls(collision);
    }


    public void ShadowControls(Collider2D col)
    {
        if (doorwayType == DoorwayType.EastWest)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y);
            }
        }

        else if (doorwayType == DoorwayType.NorthSouth)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f);
            }
        }

        else if (doorwayType == DoorwayType.WestEast)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y);
            }
        }

        else if (doorwayType == DoorwayType.SouthNorth)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                this.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f);
            }
        }
        ShadowBinary(col);
    }

    public void ShadowBinary(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            if (isEbonyOn == false)
            {
                shadowTileEbony.GetComponent<TilemapBlack>().gameObject.SetActive(true);
                
            }

            if (isEbonyOn == true)
            {
                shadowTileIvory.GetComponent<TilemapWhite>().gameObject.SetActive(false);
                
            }
            isEbonyOn = !isEbonyOn;
        }


    }

}
