using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainside : MonoBehaviour
{
    public bool isOnBridge = false;
    [SerializeField] private BridgeController onBridge;

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                onBridge.BridgeActivation();
                Debug.Log($"{col.name} activated the bridge. isOnBridge: {isOnBridge}");
                break;
            case "Enemy":
                col.GetComponent<ZombieController>().ChangeBridgeSortingLayer("over");
                Debug.Log($"{col.name} activated the bridge. isOnBridge: {isOnBridge}");
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider.CompareTag("Enemy")) { Debug.Log($"Collision activated: {col.otherCollider.name}"); }
    }
}