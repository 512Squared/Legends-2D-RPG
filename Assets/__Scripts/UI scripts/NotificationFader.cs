using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System;

public class NotificationFader : MonoBehaviour
{

    public static NotificationFader instance;
    
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;
    public TextMeshProUGUI message;
    public Image noteCharacter;
    [SerializeField] private Transform messageContainer;
    private float duration;

    private static string memoryString;
    private static Image memoryImage;
    private static float memoryPos;

    private bool isInProgress = false;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        if(isInProgress) if(memoryString != null && memoryImage != null) CallFadeInOut(memoryString, memoryImage.sprite, 1.5f, memoryPos); 
    }

    private void OnDisable()
    {
        if (isInProgress == true)
        {
            memoryString = message.text;
            memoryPos = messageContainer.position.x;
            memoryImage = noteCharacter;
        }
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

    private IEnumerator Fader(string passedMessage, Sprite characterMug, float duration, float pos)
    {
        isInProgress = true;
        DOTween.KillAll();
        this.duration = duration;
        yield return new WaitForSeconds(0f);
        messageContainer.position = new Vector3(pos, 30f, 0f);
        yield return new WaitForSeconds(0f);
        FadeIn(0.5f, passedMessage, characterMug);
        yield return new WaitForSeconds(duration);
        FadeOut(1f);
        isInProgress = false;    
    }

    public void CallFadeInOut(string message, Sprite character, float dur, float position)
    {
        StartCoroutine(Fader(message, character, dur, position));
    }
}
