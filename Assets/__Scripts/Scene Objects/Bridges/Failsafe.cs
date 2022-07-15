using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{
    [SerializeField] private BridgeController onBridge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag is "Player" or "Enemy")
        {
            onBridge.Failsafe(onBridge.playerName);
        }
    }
}