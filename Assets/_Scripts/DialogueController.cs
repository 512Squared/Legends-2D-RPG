using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{

    public static DialogueController instance;

    [SerializeField] TextMeshProUGUI dialogueText, nameText;
    [SerializeField] GameObject dialogueBox, nameBox;

    [SerializeField] string[] dialogueSentences;
    [SerializeField] int currentSentence;

    public bool dialogueJustStarted;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = dialogueSentences[currentSentence];
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {

                if (!dialogueJustStarted)
                {
                    currentSentence++;

                    if (currentSentence >= dialogueSentences.Length)
                    {
                        dialogueBox.SetActive(false);
                        GameManager.instance.dialogueBoxOpened = false;

                        // disable trigger after dialogue
                        

                    }
                    else
                    {
                        CheckForName();
                        dialogueText.text = dialogueSentences[currentSentence];
                    }
                }
                else
                {
                    dialogueJustStarted = false;
                }

            }
        }
    }


    public void ActivateDialogue(string[] newSentencesToUse)
    {
        dialogueSentences = newSentencesToUse;
        currentSentence = 0;

        CheckForName();
        dialogueText.text = dialogueSentences[currentSentence];
        dialogueBox.SetActive(true);

        dialogueJustStarted = true;
        GameManager.instance.dialogueBoxOpened = true;


    }


    void CheckForName()
    {
        if(dialogueSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogueSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    public bool isDialogueBoxActive()
    {
        return dialogueBox.activeInHierarchy;
    }

}
