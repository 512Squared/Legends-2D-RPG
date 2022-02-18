using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DropdownHandler : MonoBehaviour
{



    public TextMeshProUGUI TextBox;
    
    private int select;

    [SerializeField] PlayerStats[] characters;

    public static DropdownHandler instance;

     

    private bool isTeamMember;


    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        var dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> dropdownListOfPlayers = new List<string>();
        characters = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

        for (int i = 0; i < characters.Length; i++)
        {
            isTeamMember = characters[i].isTeamMember;
            if (isTeamMember == true)
            {
                dropdownListOfPlayers.Add(characters[i].playerName);
            }
        }

        foreach (var dropDownListOfPlayer in dropdownListOfPlayers)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = dropDownListOfPlayer });
        }

  

        dropdown.onValueChanged.AddListener(delegate 
        {
            //var dropdown = transform.GetComponent<TMP_Dropdown>();
            //select = dropdown.value;
            //Debug.Log("The lottery number is: " + select);

            
        }
        
        );


    }

  



}
