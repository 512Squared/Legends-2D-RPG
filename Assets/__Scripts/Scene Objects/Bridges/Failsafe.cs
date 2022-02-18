using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{
    [SerializeField] BridgeController onBridge;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            onBridge.Failsafe(onBridge.playerName);            
        }
    }
}
