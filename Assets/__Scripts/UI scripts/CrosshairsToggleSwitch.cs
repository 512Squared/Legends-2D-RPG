using Assets.HeroEditor4D.Common.CommonScripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class CrosshairsToggleSwitch : MonoBehaviour
{
    public bool crosshairToggle;

    [Space]
    [SerializeField] private RectTransform toggleIndicatorRectOn;

    [Space]
    [SerializeField] private RectMask2D toggleMask;

    [Space]
    [SerializeField] private float moveDistance;

    private bool isInitialized;

    private float onX;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float tweenTime;
    [SerializeField] private float offset2;

    private float maskW;
    private float maskX;
    private float maskY;
    private float maskZ;

    [SerializeField] private Vector4 maskOn;
    [SerializeField] private Vector4 maskOff;

    [Space]
    [SerializeField] private Image toggleOnIndicator;

    [SerializeField] private Sprite toggleOnSprite;
    [SerializeField] private Sprite toggleOffSprite;

    [Space]
    [SerializeField] private Color onColor;

    [SerializeField] private Color offColor;

    public void CrosshairsToggle()
    {
        crosshairToggle = !crosshairToggle;

        switch (crosshairToggle)
        {
            case true:
                Toggle(true);
                break;
            case false:
                Toggle(false);
                break;
        }
    }


    private void Toggle(bool mySwitch)
    {
        audioSource.Play();
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

    public void ToggleCrosshairsInitialize() // initializes on Settings opening in UI - OnClick event
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

            crosshairToggle = true;
            CrosshairsToggle();
            isInitialized = true;
        }
    }
}