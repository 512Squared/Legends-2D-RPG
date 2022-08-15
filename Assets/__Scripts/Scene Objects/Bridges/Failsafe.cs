using UnityEngine;

public class Failsafe : MonoBehaviour
{
    [SerializeField] private BridgeController onBridge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                onBridge.Failsafe();
                break;
            case "Enemy":
                other.GetComponent<ZombieController>().ChangeBridgeSortingLayer("under");
                break;
        }
    }
}