using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;


public class LightController : MonoBehaviour
{
    [Header("LIGHT CONTROLS")]
    [Space]
    [Space]
    [SerializeField]
    private Light2D[] nearbyLights;

    [Space]
    [SerializeField]
    private Light2D thulgranLight;

    public bool isShadowOn = true;

    private enum DoorwayType
    {
        EastWest,
        NorthSouth,
        WestEast,
        SouthNorth
    }

    [Space]
    [SerializeField]
    private DoorwayType doorwayType;

    [Space]
    [SerializeField]
    private Tilemap shadowTileEbony;

    [SerializeField] private Tilemap shadowTileIvory;

    [Space]
    public bool isEbonyOn = false;


    // Start is called before the first frame update
    private void Start()
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

        thulgranLight = FindObjectOfType<ThulgranLight>(true).GetComponent<Light2D>();
        thulgranLight.gameObject.SetActive(true);
    }

    public void DisableShadows()
    {
        for (int i = 0; i < nearbyLights.Length; i++)
        {
            nearbyLights[i].shadowsEnabled = false;
        }

        thulgranLight = FindObjectOfType<ThulgranLight>(true).GetComponent<Light2D>();
        thulgranLight.gameObject.SetActive(false);
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
                transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y);
            }
        }

        else if (doorwayType == DoorwayType.NorthSouth)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f);
            }
        }

        else if (doorwayType == DoorwayType.WestEast)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y);
            }
        }

        else if (doorwayType == DoorwayType.SouthNorth)
        {
            if (col.CompareTag("Player") && isShadowOn)
            {
                DisableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f);
            }

            else if (col.CompareTag("Player") && !isShadowOn)
            {
                EnableShadows();
                isShadowOn = !isShadowOn;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f);
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
                //shadowTileEbony.GetComponent<TilemapBlack>().gameObject.SetActive(true);
            }

            if (isEbonyOn == true)
            {
                //shadowTileIvory.GetComponent<TilemapWhite>().gameObject.SetActive(false);
            }

            isEbonyOn = !isEbonyOn;
        }
    }
}