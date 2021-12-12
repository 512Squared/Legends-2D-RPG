using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class NotificationFader : MonoBehaviour
{

    public static NotificationFader instance;
    
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;
    public TextMeshProUGUI message;
    public Image noteCharacter;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FadeIn(float duration, string notification, Sprite mug)
    {
        message.text = notification;
        noteCharacter.sprite = mug;
        Debug.Log("Fade in called with message: " + notification);
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Debug.Log("Fade out called");
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator Fader(string passedMessage, Sprite characterMug)
    {
        yield return new WaitForSeconds(0.2f);
        FadeIn(0.5f, passedMessage, characterMug);
        yield return new WaitForSeconds(3f);
        FadeOut(0.5f);
    }

    public void CallFadeInOut(string message, Sprite character)
    {
        StartCoroutine(Fader(message, character));
    }
}
