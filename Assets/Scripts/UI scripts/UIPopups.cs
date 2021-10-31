using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPopups : MonoBehaviour
{

    public RectTransform mainEQuipInfoPanel, characterChoicePanel;


    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeText;
    
    // Start is called before the first frame update
    void Start()
    {
        mainEQuipInfoPanel.DOAnchorPos(Vector2.zero, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseButton()
    {
        mainEQuipInfoPanel.DOAnchorPos(new Vector2(-750, 0), 1f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 0), 1f);
    }

    public void executeUseButton()
    {
        mainEQuipInfoPanel.DOAnchorPos(new Vector2(0, 0), 1f);
        characterChoicePanel.DOAnchorPos(new Vector2(0, 900), 1f);
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }
    
    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    
    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeText != null)
        {
            fadeText.Kill(false);
        }

        fadeText = canvasGroup.DOFade(endValue, duration);
    }

    public IEnumerator FadeInCall()
    {
        yield return new WaitForSeconds(1f);
        FadeIn(1f);
    }

    public IEnumerator FadeOutCall()
    {
        yield return new WaitForSeconds(1f);
        FadeOut(1f);
    }




}
