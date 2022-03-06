using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class DialogueHandler : MonoBehaviour
{

    [Title("Quest related stuff",horizontalLine: true)]
    [Space]
    [SerializeField] bool activatesQuest;
    [SerializeField] string questToActivate;
    [Space]
    [SerializeField] bool completesQuest;
    [SerializeField] string questToComplete;
    [Space]
    [SerializeField] bool activateDialogueOnEnter;
    [SerializeField] string message;
    [SerializeField] float fadeTime;
    [SerializeField] Sprite messageSprite;

    private bool canActivateBox = false;

    public int runCount = 0;

    [Space]
    [Title("Sentences", horizontalLine: true)]
    public string[] sentences;


    //Input.GetButtonDown("Fire1")

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && runCount < 1 && activateDialogueOnEnter && !DialogueController.instance.isDialogueBoxActive())
        {
            DialogueController.instance.activatedOnEnter = activateDialogueOnEnter;

            if (activatesQuest) // passes dialogue-specific data to the controller
            {
                DialogueController.instance.activatesQuest = activatesQuest;
                DialogueController.instance.questToActivate = questToActivate;
                Debug.Log($"Activate data passed: {gameObject.name}");
            }
            if (completesQuest)

            {
                DialogueController.instance.completesQuest = completesQuest;
                DialogueController.instance.questYouHaveJustCompleted = questToComplete;
                Debug.Log($"Complete data passed {gameObject.name}");
            }

            DialogueController.instance.ActivateDialogue(sentences);
            runCount++;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canActivateBox = true;
            Debug.Log($"Dialogue activated: {gameObject.name}");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
            if(!activatesQuest && !completesQuest) runCount = 0;
        }
    }

}
