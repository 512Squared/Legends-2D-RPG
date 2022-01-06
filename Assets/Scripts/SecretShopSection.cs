using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using Cinemachine;

public class SecretShopSection : MonoBehaviour
{

    [Header("UI Tweening")]
    [GUIColor(1f, 1f, 0.215f)]
    public RectTransform leftShopPanel, rightShopPanel;
    [GUIColor(1f, 1f, 0.215f)]
    public bool isSecretPanelOpen;
    [GUIColor(1f, 1f, 0.215f)]
    public GameObject definedButton;
    [GUIColor(1f, 1f, 0.215f)]
    public UnityEvent OnClick = new UnityEvent();
    private int hitNumber = 0;
    private bool isImageSpriteOn = false;
    public SpriteRenderer bell;
    public Sprite bellImageOn, bellImageOff;

    public ItemsManager.Shop shop;




    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
        bell.sprite = bellImageOff;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            //put your point to ray function here

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("brass_bell"))
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(hit.transform.name + " has been hit with a raycast");
                    if (hitNumber < 1)
                    {
                        OnClick.Invoke();
                        StartCoroutine(ResetBell());
                        SetImageBool();
                        hitNumber++;
                    }
                }

                else if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        Debug.Log(hit.transform.name);
                        if (hitNumber < 1)
                        {
                            OnClick.Invoke();
                            StartCoroutine(ResetBell());
                            SetImageBool();
                            hitNumber++;
                        }
                    }
                }

                else
                {
                    return;
                }

            }

            else if (hit.collider != null && hit.collider.gameObject.CompareTag("settingsButton") && hitNumber < 1)
            {
                StartCoroutine(ResetBell());
                hitNumber++;
            }
     
    }

    IEnumerator ResetBell()
    {
        yield return new WaitForSeconds(1f);
        hitNumber = 0;

    }

    public void OpenSecretPanel()
    {
        StartCoroutine(OpenPanels());
    }
    IEnumerator OpenPanels()
    {
        if (!isSecretPanelOpen)
        {
            yield return null;
            leftShopPanel.DOAnchorPos(new Vector2(-18.45f, -1.84f), 1.5f);
            rightShopPanel.DOAnchorPos(new Vector2(5.72f, -1.84f), 1.5f);
            isSecretPanelOpen = true;
        }
        else if (isSecretPanelOpen)
        {
            leftShopPanel.DOAnchorPos(new Vector2(-10.59f, -1.84f), 1.5f);
            rightShopPanel.DOAnchorPos(new Vector2(-2.27f, -1.84f), 1.5f);
            isSecretPanelOpen = false;
        }
    }
    public void ShopOpenArmoury(string shoptype) // called inside shop
    {
        ItemsManager.Shop _enum_shopType = (ItemsManager.Shop)System.Enum.Parse(typeof(ItemsManager.Shop), shoptype);
        shop = _enum_shopType;
        ShopManager.instance.shopType = _enum_shopType;
        ShopManager.instance.ShopArmouryBool();
        ShopId(_enum_shopType);
        Debug.Log("Shop Armoury is now open: " + ShopManager.instance.isShopArmouryOpen + " | Parsed enum is: " + _enum_shopType + " = " + shop);
    }

    public void ShopId(ItemsManager.Shop parsed_shopType_enum)
    {
        ShopManager.instance.ShopType(parsed_shopType_enum);
    }

    public void SetImageBool()
    {
        isImageSpriteOn = !isImageSpriteOn;
        if (isImageSpriteOn == true)
        {
            bell.sprite = bellImageOn;
        }
        else if (isImageSpriteOn == false)
        {
            bell.sprite = bellImageOff;
        }
    }



}
