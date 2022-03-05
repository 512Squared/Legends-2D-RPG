using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueHandler : MonoBehaviour
{

    [SerializeField] bool activatesQuest;
    [SerializeField] string questToActivate;
    [SerializeField] bool completesQuest;
    [SerializeField] string questToComplete;  
    [SerializeField] string message;
    [SerializeField] float fadeTime;
    [SerializeField] Sprite messageSprite;

    public string[] sentences;
    private bool canActivateBox;

    public int runCount = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && runCount < 1 && Input.GetButtonDown("Fire1") && !DialogueController.instance.isDialogueBoxActive())
        {
            DialogueController.instance.ActivateDialogue(sentences);
            runCount++;
            if (activatesQuest)
            {
                Notification(message, questToActivate, fadeTime, messageSprite, "activate");
                Actions.OnActivateQuest?.Invoke(questToActivate);
            }
            if (completesQuest)
            {
                Notification(message, questToComplete, fadeTime, messageSprite, "complete");
                Actions.MarkQuestCompleted?.Invoke(questToComplete);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Player"))
            {
                canActivateBox = true;
                Debug.Log("Dialogue activated.");

            }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
            runCount = 0;
        }
    }

    public void Notification(string message, string questName, float fadeTime, Sprite sprite, string trigger)
    {
        if(trigger == "activate")
            NotificationFader.instance.CallFadeInOut($"You have activated a new quest: <color=#E0A515>{questName}</color>.{message}", sprite, fadeTime, 1000, 30);
        
        if (trigger == "complete")
            NotificationFader.instance.CallFadeInOut($"You have completed the quest: <color=#E0A515>{questName}</color>.{message}", sprite, fadeTime, 1000, 252);
    }


}
