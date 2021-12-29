using System.Collections;
using System.Collections.Generic;
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



    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float laserLength = 5f;
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.WorldToScreenPoint(Input.mousePosition), Vector2.zero, laserLength);

        Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);

        if (hit.collider != null)

        {
            if (Input.GetMouseButtonDown(0))
            {
                    Debug.Log("Button Clicked");
                    OnClick.Invoke();
            }
        }

        else
        {
            return;
        }
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



}
