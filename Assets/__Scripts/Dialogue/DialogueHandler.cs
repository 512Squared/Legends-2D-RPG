using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueHandler : MonoBehaviour
{

    public string[] sentences;
    private bool canActivateBox;

    public int runCount = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && runCount < 1 && Input.GetButtonDown("Fire1") && !DialogueController.instance.isDialogueBoxActive())
        {
            DialogueController.instance.ActivateDialogue(sentences);
            runCount++;
        } 
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Player"))
            {
                canActivateBox = true;
                Debug.Log("Dialogue activated.");

            }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
            runCount = 0;
        }
    }

    
}
