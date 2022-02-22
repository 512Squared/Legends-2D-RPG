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

    private string questToMark;
    private bool markQuestComplete;
    private bool shouldMarkQuest;

    private string message;
    private Sprite sprite;
    private float fadeTime;
    private string questName;


    [SerializeField] string[] dialogueSentences;
    [SerializeField] int currentSentence;

    public bool dialogueJustStarted;



    private void OnEnable()
    {
        Actions.OnActivateQuest += ActivateQuestAtEnd;
    }

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

                        if (shouldMarkQuest)
                        {
                            Debug.Log($"Should Mark Quest triggered");
                            shouldMarkQuest = false;
                            if (markQuestComplete)
                            {
                                Actions.OnMarkQuestComplete?.Invoke(questToMark);
                                Notification(message, questName, fadeTime, sprite);                        
                            }
                            else
                            {
                                Actions.OnMarkQuestInComplete?.Invoke(questToMark);
                            }
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
        GameManager.instance.dialogueBoxOpened = true;


    }


    void CheckForName()
    {
        if (dialogueSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogueSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    public bool isDialogueBoxActive()
    {
        return dialogueBox.activeInHierarchy;
    }

    public void ActivateQuestAtEnd(string questName, bool markComplete, string message, float fadeTime, Sprite sprite)
    {
        Debug.Log($"Activate quest at end of dialogue: {message}");
        questToMark = questName;
        markQuestComplete = markComplete;
        shouldMarkQuest = true;
        this.message = message;
        this.fadeTime = fadeTime;
        this.sprite = sprite;
        this.questName = questName;  
    }

    public void Notification(string message, string questName, float fadeTime, Sprite sprite)
    {
        NotificationFader.instance.CallFadeInOut($"You have activated a new quest: <color=#E0A515>{questName}</color>. {message}", sprite, fadeTime, 1000);
    }

}
