using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class GenerateGUID : MonoBehaviour
{
    [SerializeField]
    private string gUid = "";

    public string GUID { get => gUid; set => gUid = value; }

    private void OnValidate()
    {
        // Only populate in the editor
        if (Application.IsPlaying(gameObject)) { return; }

        // Ensure the object has a guaranteed unique id
        if (gUid == "")
        {
            //Assign GUID
            gUid = System.Guid.NewGuid().ToString();
        }
    }


    [Button(ButtonSizes.Large)] [GUIColor(0.682f, 0.686f, 0.156f)]
    public void CreateNewGUID()
    {
        gUid = System.Guid.NewGuid().ToString();
    }
}