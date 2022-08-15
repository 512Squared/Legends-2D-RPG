using UnityEngine;


public class Otherside : MonoBehaviour
{
    public bool isOnBridge;

    [SerializeField] private BridgeController onBridge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                onBridge.BridgeActivation();
                Debug.Log($"{other.name} activated the bridge. isOnBridge: {isOnBridge}");
                break;
            case "Enemy":
                other.GetComponent<ZombieController>().ChangeBridgeSortingLayer("over");
                Debug.Log($"{other.name} activated the bridge. isOnBridge: {isOnBridge}");
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider.CompareTag("Enemy")) { Debug.Log($"Collision activated: {col.otherCollider.name}"); }
    }
}