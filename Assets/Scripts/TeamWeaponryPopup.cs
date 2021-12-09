using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamWeaponryPopup : MonoBehaviour
{

    private string weaponryType;
    public CanvasGroup fadeImage;
    public CanvasGroup fadeImage2;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeaponryType(string type)
    {
        weaponryType = type;
    }

    public void Open(int chosenPlayer)
    {
        fadeImage.alpha = 0;
        fadeImage.LeanAlpha(1, 0.5f);
        fadeImage2.LeanAlpha(0.5f, 0.5f);
        MenuManager.instance.TeamWeaponryPopup(chosenPlayer, weaponryType);
        transform.LeanScale(Vector3.one, 0.6f);
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 0.4f).setEaseInBack();
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage2.LeanAlpha(1f, 0.5f);
    }
}
