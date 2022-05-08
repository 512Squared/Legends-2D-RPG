using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DropdownHandler : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    private int _select;

    [SerializeField] private PlayerStats[] characters;

    public static DropdownHandler Instance;


    private bool _isTeamMember;


    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;

        TMP_Dropdown dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> dropdownListOfPlayers = new();
        characters = FindObjectsOfType<PlayerStats>(true).OrderBy(m => m.transform.position.z).ToArray();

        for (int i = 0; i < characters.Length; i++)
        {
            _isTeamMember = characters[i].isTeamMember;
            if (_isTeamMember == true)
            {
                dropdownListOfPlayers.Add(characters[i].playerName);
            }
        }

        foreach (string dropDownListOfPlayer in dropdownListOfPlayers)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() {text = dropDownListOfPlayer});
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