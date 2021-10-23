using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ItemButton : MonoBehaviour
{

    public ItemsManager itemOnButton;




    [TabGroup("Select Item"), Button]
    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;
        MenuManager.instance.itemImage.sprite = itemOnButton.itemsImage;
        MenuManager.instance.itemValue.text = itemOnButton.valueInCoins.ToString();
        MenuManager.instance.activeItem = itemOnButton;



        //GameObject.FindGameObjectWithTag("Focus").GetComponent<Image>().enabled = true;
    }


}
