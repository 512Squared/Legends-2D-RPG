using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainside : MonoBehaviour
{
    public bool isOnBridge = false;
    [SerializeField] BridgeController onBridge;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            onBridge.BridgeActivation(onBridge.playerName);
            Debug.Log($"{onBridge.playerName} activated the bridge. isOnBridge: {isOnBridge}");
        }
    }
}
