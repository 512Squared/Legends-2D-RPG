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

    public bool activatesQuest;
    public string questToActivate;
    public bool completesQuest;
    public string questYouHaveJustCompleted;
    public string emptyArg = string.Empty;
    private int turn = 0;

    [SerializeField] string[] dialogueSentences;
    [SerializeField] int currentSentence;

    public bool dialogueJustStarted;
    public bool activatedOnEnter = false;

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
                        GameManager.Instance.dialogueBoxOpened = false;

                        if (activatesQuest && !completesQuest)
                        {
                            Actions.OnDoQuestStuffAfterDialogue?.Invoke("activate", questToActivate, emptyArg);
                            Actions.OnActivateQuest?.Invoke(questToActivate);
                            Debug.Log($"Dialogue complete. 'Activate' quest: {questToActivate}");
                            activatesQuest = false; 
                        }

                        else if (completesQuest && !activatesQuest)
                        {
                            Actions.OnDoQuestStuffAfterDialogue?.Invoke("complete", emptyArg, questYouHaveJustCompleted);
                            Debug.Log($"Dialogue complete. 'Complete' event called {questYouHaveJustCompleted}");
                            completesQuest = false;
                        }
                        else if (completesQuest && activatesQuest)
                        {
                            Actions.OnDoQuestStuffAfterDialogue?.Invoke("both", questToActivate, questYouHaveJustCompleted);
                            Debug.Log($"Dialogue complete. 'Both' event called: {questYouHaveJustCompleted} | {questToActivate}");
                            completesQuest = false;
                            activatesQuest = false;
                        }
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
        GameManager.Instance.dialogueBoxOpened = true;
    }


    void CheckForName()
    {   
        if (dialogueSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogueSentences[currentSentence].Replace("#", "");
            currentSentence++;
            if (turn == 1)
            {
                nameText.color = new Color32(209, 206, 66, 255);
                turn = 0;
                return;
            }
            else if (turn == 0)
            {
                nameText.color = new Color32(89, 198, 200, 255);
                turn = 1;
            }
        }
    }

    public bool isDialogueBoxActive()
    {
        return dialogueBox.activeInHierarchy;
    }

}
