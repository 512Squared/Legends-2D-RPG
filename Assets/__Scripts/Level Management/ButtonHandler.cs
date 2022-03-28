using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class ButtonHandler : MonoBehaviour
{

    public static ButtonHandler instance;
    private GameObject useButton, sellButton;


    void Awake()
    {
        instance = this;
        useButton = GameObject.FindGameObjectWithTag("buttonUse");
        sellButton = GameObject.FindGameObjectWithTag("button_sell");
    }

     public void UseButtonIsOn()
    {
        useButton.GetComponent<Button>().interactable = true;
        sellButton.GetComponent<Button>().interactable = true;
    }

    
    // this is to turn Inventory tab buttons into toggles, where when selected, tab is interactable
    
    [SerializeField]
    private Button[] buttons;

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
            return;

        SetAllButtonsInteractable();

        clickedButton.interactable = false;

    }

    public void OnButtonCalled(string calledTab)
    {

        SetAllButtonsInteractable();

        if (calledTab == "weapon") buttons[1].interactable = false;
        else if (calledTab == "armour" || calledTab == "helmet" || calledTab == "shield") buttons[2].interactable = false;
    }

    public void ChangeButtonColorToGrayscale()
    {
        var button = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button.color = new Color32(75,75,75,255);
    }

    public void ChangeButtonColorToWhite()
    {
        var button = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button.color = new Color32(255, 255, 255, 255);
    }

    public void UpdateNofify()
    {
        StartCoroutine(UpdateNotifications());
    }

    IEnumerator UpdateNotifications()
    {
        yield return null; 
        MenuManager.instance.UpdateQuestNotifications();
    }
}
