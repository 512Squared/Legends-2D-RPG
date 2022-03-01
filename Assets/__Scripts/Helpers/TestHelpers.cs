using UnityEngine;
using Sirenix.OdinInspector;

public class TestHelpers : MonoBehaviour
{
    [HorizontalGroup("Test Helpers", 380)]
    [BoxGroup("Test Helpers/New Input")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [LabelWidth(70)]
    [SerializeField] string spellName;
    [HorizontalGroup("Test Helpers", 80)]
    [BoxGroup("Test Helpers/Duplicates"), HideLabel]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [SerializeField] bool allowStringDuplicates;
    [BoxGroup("Test Helpers/New Input")]
    [GUIColor(.5f, 0.8f, 0.215f)]
    [LabelWidth(70)]
    [SerializeField] int quantity;
    [BoxGroup("Test Helpers/Duplicates"), HideLabel]
    [GUIColor(0.5f, 0.8f, 0.215f)]
    [SerializeField] bool allowIntDuplicates;
    
    void Start()
    {
        //AddToArray();
    }
    private void AddToArray()
    {

        string[] testArray = { "one", "two", "three", "Lightning definitely strikes twice" };
        testArray = testArray.AddStringToArray(spellName, allowStringDuplicates);
        for (int i = 0; i < testArray.Length; i++)
        {
            Debug.Log($"Index: {i} | Item: {testArray[i]}");            
        }

        int[] testIntArray = { 1, 2, 3 };
        testIntArray = testIntArray.AddIntToArray(quantity, allowIntDuplicates);
        for (int i = 0; i < testIntArray.Length; i++)
        {
            Debug.Log($"Index: {i} | Item: {testIntArray[i]}");
        }
    }
}
