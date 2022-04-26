using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;

    [SerializeField] private TextMeshProUGUI dialogueText, nameText;
    [SerializeField] private GameObject dialogueBox;

    public bool activatesQuest;
    public string questToActivate;
    public bool completesQuest;
    public string questYouHaveJustCompleted;
    public string emptyArg = string.Empty;
    private int _turn;

    [SerializeField] private string[] dialogueSentences;
    [SerializeField] private int currentSentence;

    public bool dialogueJustStarted;

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        dialogueText.text = dialogueSentences[currentSentence];
    }

    // Update is called once per frame
    private void Update()
    {
        if (!dialogueBox.activeInHierarchy) { return; }

        if (!Input.GetButtonUp("Fire1")) { return; }

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
                    Debug.Log($"OnActivateQuest called: {questToActivate}");
                    activatesQuest = false;
                }

                else
                {
                    switch (completesQuest)
                    {
                        case true when !activatesQuest:
                            Actions.OnDoQuestStuffAfterDialogue?.Invoke("complete", emptyArg,
                                questYouHaveJustCompleted);
                            completesQuest = false;
                            break;
                        case true when activatesQuest:
                            Actions.OnDoQuestStuffAfterDialogue?.Invoke("both", questToActivate,
                                questYouHaveJustCompleted);
                            completesQuest = false;
                            activatesQuest = false;
                            break;
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


    private void CheckForName()
    {
        if (!dialogueSentences[currentSentence].StartsWith("#")) { return; }

        nameText.text = dialogueSentences[currentSentence].Replace("#", "");
        currentSentence++;
        switch (_turn)
        {
            case 1:
                nameText.color = new Color32(209, 206, 66, 255);
                _turn = 0;
                return;
            case 0:
                nameText.color = new Color32(89, 198, 200, 255);
                _turn = 1;
                break;
        }
    }

    public bool IsDialogueBoxActive()
    {
        return dialogueBox.activeInHierarchy;
    }
}