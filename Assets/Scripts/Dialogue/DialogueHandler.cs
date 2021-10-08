using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{

    public string[] sentences;
    private bool canActivateBox;
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && Input.GetButtonDown("Fire1") && !DialogueController.instance.isDialogueBoxActive())
        {
            DialogueController.instance.ActivateDialogue(sentences);
            runCount++;
        } 
    }

    public int runCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (runCount < 1)
        {
            if (collision.CompareTag("Player"))
            {
                canActivateBox = true;
                Debug.Log("Dialogue activated.");

            }
        }

        else if (runCount >= 1 && CompareTag("Player"))

        {
            Debug.Log("Dialogue already previously activated.");
            canActivateBox = false;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
        }
    }


}
