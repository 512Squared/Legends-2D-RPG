using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Otherside : MonoBehaviour
{
    public bool isOnBridge = false;

    [SerializeField] private BridgeController onBridge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag is "Player" or "Enemy")
        {
            onBridge.BridgeActivation(onBridge.playerName);
            Debug.Log($"{onBridge.playerName} activated the bridge. isOnBridge: {isOnBridge}");
        }
    }
}