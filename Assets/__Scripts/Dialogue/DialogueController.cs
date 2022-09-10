using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

[RequireComponent(typeof(GenerateGUID))]
public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;

    [SerializeField] private TextMeshProUGUI dialogueText, nameText;
    [SerializeField] private GameObject dialogueBox;

    public bool activatesAQuest;
    public bool completesAQuest;

    [ShowIf("activatesAQuest")] [Required]
    public Quest questToActivate;

    [ShowIf("completesAQuest")] [Required]
    public Quest questToComplete;

    private bool _isTrigger = true;
    private int _turn;
    private string _questElementGUID;

    [SerializeField] private string[] dialogueSentences;
    [SerializeField] private int currentSentence;

    public bool dialogueJustStarted;

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        dialogueText.text = dialogueSentences[currentSentence];
        _questElementGUID = GetComponent<GenerateGUID>().GUID;
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
                PlayerStats[] players = GameManager.Instance.GetPlayerStats();
                foreach (PlayerStats player in players)
                {
                    if (player != null) { player.GetComponent<NPCMovement>().isPaused = false; }
                }

                PlayerGlobalData.Instance.isPaused = false;

                if (!_isTrigger) { return; }

                if (activatesAQuest && !questToComplete)
                {
                    // questToActivate is passed twice to avoid null
                    Debug.Log($"OnActivateQuest called: {questToActivate.questName}");
                    Actions.OnDoQuestStuffAfterDialogue?.Invoke("activate", questToActivate, questToActivate);
                    _isTrigger = false;
                }

                if (completesAQuest && !activatesAQuest)
                {
                    // questToComplete is passed twice to avoid null
                    Actions.OnDoQuestStuffAfterDialogue?.Invoke("complete",
                        questToComplete,
                        questToComplete);
                    _isTrigger = false;
                }

                if (completesAQuest && activatesAQuest)
                {
                    Actions.OnDoQuestStuffAfterDialogue?.Invoke("both",
                        questToActivate,
                        questToComplete);
                    _isTrigger = false;
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
        PlayerStats[] players = GameManager.Instance.GetPlayerStats();
        foreach (PlayerStats player in players)
        {
            if (player == null) { continue; }

            if (player.gameObject.activeInHierarchy && player.isTeamMember && player.name != "Thulgran") { player.GetComponent<NPCMovement>().isPaused = true; }
        }

        PlayerGlobalData.Instance.isPaused = true;

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