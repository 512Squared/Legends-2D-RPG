using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System;

public class NotificationFader : MonoBehaviour
{
    public static NotificationFader Instance;

    [SerializeField] private CanvasGroup canvasGroup;
    private Tween _fadeTween;
    public TextMeshProUGUI message;
    public Image noteCharacter;
    [SerializeField] private Transform messageContainer;
    private float _duration;

    private static string _memoryString;
    private static Image _memoryImage;
    private static float _memoryPosX;
    private static float _memoryPosY;

    private bool _isInProgress = false;


    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        if (_isInProgress)
        {
            if (_memoryString != null && _memoryImage != null)
            {
                CallFadeInOut(_memoryString, _memoryImage.sprite, _duration, _memoryPosX, _memoryPosY);
            }
        }
    }

    private void OnDisable()
    {
        if (_isInProgress == true)
        {
            _memoryString = message.text;
            _memoryPosX = messageContainer.position.x;
            _memoryPosY = messageContainer.position.y;
            _memoryImage = noteCharacter;
        }
    }


    public void FadeIn(float duration, string notification, Sprite mug)
    {
        message.text = notification;
        noteCharacter.sprite = mug;
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
        if (_fadeTween != null)
        {
            _fadeTween.Kill(false);
        }

        _fadeTween = canvasGroup.DOFade(endValue, duration);
        _fadeTween.onComplete += onEnd;
    }

    private IEnumerator Fader(string passedMessage, Sprite characterMug, float duration, float xpos, float ypos)
    {
        _isInProgress = true;
        DOTween.KillAll();
        _duration = duration;
        messageContainer.position = new Vector3(xpos, ypos, 0f);
        FadeIn(0.5f, passedMessage, characterMug);
        yield return new WaitForSeconds(duration);
        FadeOut(1f);
        _isInProgress = false;
    }

    public void CallFadeInOut(string message, Sprite character, float dur, float xposition, float yposition)
    {
        StartCoroutine(Fader(message, character, dur, xposition, yposition));
    }
}