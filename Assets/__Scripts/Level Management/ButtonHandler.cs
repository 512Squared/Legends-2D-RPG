using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class ButtonHandler : MonoBehaviour
{
    public static ButtonHandler Instance;

    [SerializeField]
    private GameObject cancelButton;

    private GameObject _useButton, _sellButton, _dropButton, _sellGold, _valueInCoins;
    private Image _goldImage;
    private TextMeshProUGUI _valueText;


    private void Awake()
    {
        Instance = this;
        _useButton = GameObject.FindGameObjectWithTag("buttonUse");
        _sellButton = GameObject.FindGameObjectWithTag("button_sell");
        _dropButton = GameObject.FindGameObjectWithTag("buttonDrop");
        _sellGold = GameObject.FindGameObjectWithTag("sellGold");
        _valueInCoins = GameObject.FindGameObjectWithTag("valueInCoins");
        _goldImage = _sellGold.GetComponent<Image>();
        _valueText = _valueInCoins.GetComponent<TextMeshProUGUI>();
    }

    public void UseButtonIsOn()
    {
        _useButton.GetComponent<Button>().interactable = true;
        _sellButton.GetComponent<Button>().interactable = true;
        _dropButton.GetComponent<Button>().interactable = true;
        _goldImage.color = new Color32(255, 255, 255, 255);
        _valueText.color = new Color32(255, 255, 255, 255);
    }

    public void InventoryButtonsDisabled()
    {
        _useButton.GetComponent<Button>().interactable = false;
        _sellButton.GetComponent<Button>().interactable = false;
        _dropButton.GetComponent<Button>().interactable = false;
        _goldImage.color = new Color32(255, 255, 255, 100);
        _valueText.color = new Color32(255, 255, 255, 100);
    }

    public void UseEquipGiveButtonPress()
    {
        _useButton.GetComponent<Button>().interactable = false;
        _sellButton.GetComponent<Button>().interactable = false;
        _dropButton.SetActive(false);
        cancelButton.SetActive(true);
        _goldImage.color = new Color32(255, 255, 255, 100);
        _valueText.color = new Color32(255, 255, 255, 100);
    }

    public void CancelButtonInventory()
    {
        _useButton.GetComponent<Button>().interactable = true;
        _sellButton.GetComponent<Button>().interactable = true;
        _dropButton.SetActive(true);
        cancelButton.SetActive(false);
        _goldImage.color = new Color32(255, 255, 255, 255);
        _valueText.color = new Color32(255, 255, 255, 255);
    }

    // this is to turn Inventory tab buttons into toggles, where when selected, tab is interactable

    [SerializeField] private Button[] buttons;

    public void SetAllButtonsInteractable()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }


    public void SetAllButtonsUninteractable()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
        {
            return;
        }

        SetAllButtonsInteractable();

        clickedButton.interactable = false;
    }

    public void OnButtonCalled(string calledTab)
    {
        SetAllButtonsInteractable();

        if (calledTab == "weapon")
        {
            buttons[1].interactable = false;
        }
        else if (calledTab is "armour" or "helmet" or "shield")
        {
            buttons[2].interactable = false;
        }
    }

    public void ChangeButtonColorToGrayscale()
    {
        TextMeshProUGUI button = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button.color = new Color32(75, 75, 75, 255);
    }

    public void ChangeButtonColorToWhite()
    {
        TextMeshProUGUI button = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button.color = new Color32(255, 255, 255, 255);
    }

    public void UpdateNofify()
    {
        StartCoroutine(UpdateNotifications());
    }

    private IEnumerator UpdateNotifications()
    {
        yield return null;
        MenuManager.Instance.UpdateQuestNotifications();
    }
}