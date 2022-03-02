using System.Collections;
using UnityEngine;

namespace Assets.__Scripts.UI_scripts
{
    public class UINavigation : MonoBehaviour
    {
        public void BackButtonPressed()
        {
            Actions.OnBackButton?.Invoke();
            Debug.Log($"Back button invoked");
        }

        public void HomeButtonPressed()
        {
            Actions.OnHomeButton?.Invoke();
        }

        public void MainMenuOpened()
        {
            Actions.OnMainMenuButton?.Invoke();
        }
        public void ResumeButtonPressed() // on fade mask too
        {
            Actions.OnResumeButton?.Invoke();
        }


    }
}