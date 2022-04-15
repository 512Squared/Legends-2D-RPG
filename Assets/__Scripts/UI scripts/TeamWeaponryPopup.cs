using UnityEngine;

public class TeamWeaponryPopup : MonoBehaviour
{
    private string weaponryType;
    public CanvasGroup fadeImage;
    public CanvasGroup fadeImage2;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void SetWeaponryType(string type)
    {
        weaponryType = type;
    }

    public void Open(int chosenPlayer)
    {
        fadeImage.alpha = 0;
        fadeImage.LeanAlpha(1, 0.3f);
        fadeImage2.LeanAlpha(0.1f, 0.3f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;

        MenuManager.Instance.TeamWeaponryPopup(chosenPlayer, weaponryType);
        transform.LeanScale(Vector3.one, 0.6f).setEaseOutBack();
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 0.4f).setEaseInBack();
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage2.LeanAlpha(1f, 0.5f);
        fadeImage.blocksRaycasts = false;
        fadeImage.interactable = false;
    }

    public void Change()
    {
        MenuManager.Instance.SortByItemType(weaponryType);
        transform.LeanScale(Vector3.zero, 0.4f).setEaseInBack();
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage2.LeanAlpha(0f, 0.5f);
    }

    public void OpenRelicInfo(string relicName)
    {
        Debug.Log($"Popup called: {relicName}");
        fadeImage.alpha = 0;
        fadeImage.LeanAlpha(1, 0.3f);
        fadeImage2.LeanAlpha(0.1f, 0.3f);
        fadeImage.blocksRaycasts = true;
        fadeImage.interactable = true;
        transform.LeanScale(Vector3.one, 0.6f).setEaseOutBack();
        MenuManager.Instance.OpenRelicInfo(relicName);
    }


    public void ChangeSimple()
    {
        transform.LeanScale(Vector3.zero, 0.4f).setEaseInBack();
        fadeImage.LeanAlpha(0, 0.5f);
        fadeImage2.LeanAlpha(0f, 0.5f);
    }
}