using UnityEngine;
using UnityEngine.Rendering.Universal;

public class JinJinNecklace : MonoBehaviour
{
    [SerializeField]
    private Light2D thulgranLight;

    [SerializeField]
    private QuestElement questElement;
    
   
    private void OnEnable()
    {
        Actions.OnClaimQuestRewards += EnableLight;
    }

    private void OnDisable()
    {
        Actions.OnClaimQuestRewards -= EnableLight;
    }

    private void EnableLight(Quest quest)
    {
        Debug.Log($"EnableLight called");
        if (questElement.elementCompleted && quest.isDone)
        {
            thulgranLight.enabled = true;
            Debug.Log($"Light activated.");
        }
    }
}