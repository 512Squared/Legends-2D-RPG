using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class GenerateGUID : MonoBehaviour
{
    [SerializeField]
    private string _gUID = "";

    public string GUID { get => _gUID; set => _gUID = value; }

    private void OnValidate()
    {
        // Only populate in the editor
        if (Application.IsPlaying(gameObject)) { return; }

        // Ensure the object has a guaranteed unique id
        if (_gUID == "")
        {
            //Assign GUID
            _gUID = System.Guid.NewGuid().ToString();
        }
    }


    [Button(ButtonSizes.Large)] [GUIColor(0.682f, 0.686f, 0.156f)]
    public void CreateNewGUID()
    {
        _gUID = System.Guid.NewGuid().ToString();
        Debug.Log($"New GUID Created: {gameObject.name}");
    }
}