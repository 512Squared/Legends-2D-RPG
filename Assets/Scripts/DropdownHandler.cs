using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{


    public TextMeshProUGUI TextBox;

    [SerializeField] PlayerStats[] characters;
    private bool isTeamMember;

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> dropdownListOfPlayers = new List<string>();




        for (int i = 0; i < characters.Length; i++)
        {


            Debug.Log("Dropdown loop started");

            isTeamMember = characters[i].isTeamMember;
            if (isTeamMember == true)
            {
                dropdownListOfPlayers.Add(characters[i].playerName);
            }
        }
        
        foreach (var dropDownListOfPlayer in dropdownListOfPlayers)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = dropDownListOfPlayer });
            Debug.Log("Text found: " + dropDownListOfPlayer);
        }



        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });

    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        Debug.Log("DropdownItemSelected function accessed");
        int index = dropdown.value;

        TextBox.text = dropdown.options[index].text;
    }



}
