using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour
{
    public string arrivalStation;

    // Start is called before the first frame update
    private void Start()
    {
        if (arrivalStation == PlayerGlobalData.Instance.arrivingAt)
        {
            PlayerGlobalData.Instance.transform.position = transform.position;
            GameManager.Instance.LocateCharactersInNewScene(transform.position);
        }
    }
}