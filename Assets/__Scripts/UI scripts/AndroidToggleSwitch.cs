using System.Collections;
using Assets.HeroEditor4D.Common.CommonScripts;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class AndroidToggleSwitch : MonoBehaviour
{
    public bool joystickOn;

    [Space]
    [SerializeField] private RectTransform toggleIndicatorRectOn;

    [Space]
    [SerializeField] private RectMask2D toggleMask;

    [Space]
    [SerializeField] private float moveDistance;

    [SerializeField]
    private UltimateJoystick joystick;

    [SerializeField]
    private UltimateButton fireButton;

    private float onX;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float tweenTime;
    [SerializeField] private float offset2;

    private float maskW;
    private float maskX;
    private float maskY;
    private float maskZ;

    private bool isInitialized;

    [SerializeField] private Vector4 maskOn;
    [SerializeField] private Vector4 maskOff;

    [Space]
    [SerializeField] private Image toggleOnIndicator;

    [SerializeField] private Sprite toggleOnSprite;
    [SerializeField] private Sprite toggleOffSprite;

    [Space]
    [SerializeField] private Color onColor;

    [SerializeField] private Color offColor;

    public void JoystickToggle(bool audio)
    {
        joystickOn = !joystickOn;
        MenuManager.Instance.AndroidControls();

        switch (joystickOn)
        {
            case false:
                joystick.SetActive(!joystickOn);
                fireButton.SetActive(!joystickOn);
                joystick.DisableJoystick();
                fireButton.DisableButton();
                Toggle(true, audio);
                break;
            case true:
                joystick.SetActive(!joystickOn);
                fireButton.SetActive(!joystickOn);
                joystick.EnableJoystick();
                fireButton.EnableButton();
                Toggle(false, audio);
                break;
        }
    }


    private void Toggle(bool mySwitch, bool audio)
    {
        if (audio) { audioSource.Play(); }

        BackgroundLerp(mySwitch);
        MoveIndicatorOn(mySwitch);
        toggleOnIndicator.sprite = mySwitch ? toggleOffSprite : toggleOnSprite;
    }

    private void BackgroundLerp(bool toggle)
    {
        maskOff = new Vector4(maskW, maskX, offset2, maskZ);
        maskOn = new Vector4(maskW, maskX, maskY, maskZ);
        toggleMask.padding = toggle
            ? Vector4.Lerp(maskOff, maskOn, tweenTime * 2)
            : Vector4.Lerp(maskOn, maskOff, tweenTime * 2);
    }


    private void MoveIndicatorOn(bool value)
    {
        toggleIndicatorRectOn.DOAnchorPosX(value ? onX - moveDistance : onX,
            tweenTime);
    }

    public void ToggleAndroidInitialize()
    {
        if (!isInitialized)
        {
            onX = toggleIndicatorRectOn.anchoredPosition.x;
            audioSource = GetComponent<AudioSource>();
            maskW = toggleMask.padding.w;
            maskX = toggleMask.padding.x;
            maskY = toggleMask.padding.y;
            maskZ = toggleMask.padding.z;

            // all set to true (including Android Controls), then toggles off for initial state
            // otherwise, toggle defaults will be true, even though android controls are elsewhere set to false
            MenuManager.Instance.AndroidControls();
            joystickOn = true;
            JoystickToggle(false);
            isInitialized = true;
        }
    }
}