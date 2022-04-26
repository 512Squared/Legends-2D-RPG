using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;


public class DialogueHandler : MonoBehaviour, ISaveable
{
    [Title("Quest related stuff", horizontalLine: true)]
    [Space]
    [SerializeField]
    private bool activatesQuest;

    [SerializeField] private string questToActivate;

    [Space]
    [SerializeField]
    private bool completesQuest;

    [SerializeField] private string questToComplete;

    [Space]
    [SerializeField]
    private bool activateDialogueOnEnter;

    [SerializeField] private string message;
    [SerializeField] private float fadeTime;
    [SerializeField] private Sprite messageSprite;

    private bool _canActivateBox = false;

    private string _dialogueGuid;

    public int runCount = 0;

    [Space]
    [Title("Sentences", horizontalLine: true)]
    public string[] sentences;

    private void Start()
    {
        _dialogueGuid = GetComponent<GenerateGUID>().GUID;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_canActivateBox || runCount >= 1 || !activateDialogueOnEnter ||
            DialogueController.Instance.IsDialogueBoxActive()) { return; }

        if (activatesQuest) // passes dialogue-specific data to the controller
        {
            DialogueController.Instance.activatesQuest = activatesQuest;
            DialogueController.Instance.questToActivate = questToActivate;
        }

        if (completesQuest)

        {
            DialogueController.Instance.completesQuest = completesQuest;
            DialogueController.Instance.questYouHaveJustCompleted = questToComplete;
        }

        DialogueController.Instance.ActivateDialogue(sentences);
        runCount++;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canActivateBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        _canActivateBox = false;
        if (!activatesQuest && !completesQuest) { runCount = 0; }
    }

    #region Implementation of ISaveable

    public void PopulateSaveData(SaveData a_SaveData)
    {
        SaveData.DialogueData dd = new(runCount, _dialogueGuid);

        a_SaveData.dialoguesList.Add(dd);
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        foreach (SaveData.DialogueData dd in a_SaveData.dialoguesList.Where(dd => dd.dialogueGuid == _dialogueGuid))
        {
            runCount = dd.runCount;
        }
    }

    #endregion
}