using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{

    public CanvasGroup uiElement;


    private IEnumerator Wait(float aWaitTime)
    {
        yield return new WaitForSeconds(aWaitTime);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }


    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.3f)
    {

        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        
        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

    }

}


