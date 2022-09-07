using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ToggleSwitch : MonoBehaviour
{
    public bool toggleSwitch;

    [Space]
    [SerializeField] private RectTransform toggleIndicatorRectOn;

    [Space]
    [SerializeField] private RectMask2D toggleMask;

    [Space]
    [SerializeField] private float moveDistance;

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

    private void Awake()
    {
        onX = toggleIndicatorRectOn.anchoredPosition.x;
        audioSource = GetComponent<AudioSource>();
        maskW = toggleMask.padding.w;
        maskX = toggleMask.padding.x;
        maskY = toggleMask.padding.y;
        maskZ = toggleMask.padding.z;
        toggleSwitch = true;
        Toggle(toggleSwitch);
        GameManager.Instance.ToggleCrosshairs();
    }

    public void Crosshairs()
    {
        toggleSwitch = !toggleSwitch;
        switch (toggleSwitch)
        {
            case true:
                Toggle(true);
                break;
            case false:
                Toggle(false);
                break;
        }
    }

    private void Toggle(bool toggle)
    {
        audioSource.Play();
        GameManager.Instance.ToggleCrosshairs();
        BackgroundLerp(toggle);
        MoveIndicatorOn(toggle);
        toggleOnIndicator.sprite = toggle ? toggleOffSprite : toggleOnSprite;
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
}