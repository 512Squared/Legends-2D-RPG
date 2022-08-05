using UnityEngine;

public class CarryBase : MonoBehaviour
{

    [SerializeField]
    private Transform ringBase;

    [SerializeField]
    private Transform parent;
    private void Update()
    {
        ringBase.position = parent.position;
    }
}