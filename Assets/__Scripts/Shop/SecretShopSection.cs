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
    public static SecretShopSection Instance;

    [Header("UI Tweening")] [GUIColor(1f, 1f, 0.215f)]
    public RectTransform leftShopPanel, rightShopPanel;

    [GUIColor(1f, 1f, 0.215f)] public bool isSecretPanelOpen;
    [GUIColor(1f, 1f, 0.215f)] public GameObject definedButton;
    [GUIColor(1f, 1f, 0.215f)] public UnityEvent OnClick = new();
    private int hitNumber = 0;
    private bool isImageSpriteOn = false;
    public SpriteRenderer bell;
    public Sprite bellImageOn, bellImageOff;

    public Shop shopType;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        definedButton = gameObject;
        bell.sprite = bellImageOff;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //put your point to ray function here

        Vector2 rayPos = new(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("brass_bell"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.transform.name + " has been hit with a raycast");
                if (hitNumber < 1)
                {
                    OnClick.Invoke();
                    AudioManager.Instance.PlaySfxClip(9);
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
                        AudioManager.Instance.PlaySfxClip(9);
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

    private IEnumerator ResetBell()
    {
        yield return new WaitForSeconds(1f);
        hitNumber = 0;
    }

    public void OpenSecretPanel()
    {
        StartCoroutine(OpenPanels());
    }

    private IEnumerator OpenPanels()
    {
        yield return new WaitForSeconds(5.2f);

        if (!isSecretPanelOpen)
        {
            AudioManager.Instance.PlayClipDirect(AudioManager.Instance.sfxSource, AudioManager.Instance.shelfWhoosh);
            leftShopPanel.DOAnchorPos(new Vector2(-18.45f, -1.84f), 4f);
            rightShopPanel.DOAnchorPos(new Vector2(5.72f, -1.84f), 4f);
            isSecretPanelOpen = true;
        }
        else if (isSecretPanelOpen)
        {
            AudioManager.Instance.PlayClipDirect(AudioManager.Instance.sfxSource, AudioManager.Instance.shelfWhoosh);
            leftShopPanel.DOAnchorPos(new Vector2(-10.59f, -1.84f), 4f);
            rightShopPanel.DOAnchorPos(new Vector2(-2.27f, -1.84f), 4f);
            isSecretPanelOpen = false;
        }
    }

    public void ShopOpenArmoury(string shoptype) // called inside shop
    {
        SetShopType(shoptype);
        ShopManager.Instance.ShopArmouryBool();
    }

    public void ShopId(string scene)
    {
        ShopManager.Instance.ShopType(scene);
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

    public void SetShopType(string scene)
    {
        Debug.Log($"SetShopType called: {scene}");
        Shop enumShopType = (Shop)Enum.Parse(typeof(Shop), scene);
        shopType = enumShopType;
        ShopId(scene);
        ShopManager.Instance.shopType = enumShopType;
        Debug.Log("Shop type now set: " + shopType); // don't forget to change onclick string
    }
}