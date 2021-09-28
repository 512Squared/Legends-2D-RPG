using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game was quit!");
        Application.Quit();
    }
}
