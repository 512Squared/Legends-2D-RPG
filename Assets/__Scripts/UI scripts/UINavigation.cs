using System.Collections;
using UnityEngine;

namespace Assets.__Scripts.UI_scripts
{
    public class UINavigation : MonoBehaviour
    {
        public void BackButtonPressed()
        {
            Actions.OnBackButton?.Invoke();
        }

        public void HomeButtonPressed()
        {
            Actions.OnHomeButton?.Invoke();
        }

        public void MainMenuOpened()
        {
            Actions.OnMainMenuButton?.Invoke();
            Debug.Log($"OnMainMenuButton invoked | Invocation List: {Actions.OnMainMenuButton.GetInvocationList().Length}");
        }
        public void ResumeButtonPressed() // on fade mask too
        {
            Actions.OnResumeButton?.Invoke();
        }


    }
}