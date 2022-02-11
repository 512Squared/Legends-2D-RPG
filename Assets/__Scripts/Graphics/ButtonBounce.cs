using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonBounce : MonoBehaviour
{

    [SerializeField] RectTransform[] buttonToBounce;

    private void Start()
    {
        for (int i = 0; i < buttonToBounce.Length; i++)
        {
            Button btn = buttonToBounce[i].gameObject.GetComponentInChildren<Button>();
            btn.onClick.AddListener(ButtonBouncing);
        }
    }

    public void ButtonBouncing()
    {
        for (int i = 0; i < buttonToBounce.Length; i++)
        {
            var sequence = DOTween.Sequence()
            .Append(buttonToBounce[i].DOScale(0.9f, 0.2f)).SetEase(Ease.InBounce)
            .Join(buttonToBounce[i].GetComponentInChildren<RectTransform>().DOScale(0.9f, 0.2f)).SetEase(Ease.InBounce)
            .Append(buttonToBounce[i].DOScale(1f, 0.6f)).SetEase(Ease.OutBounce)
            .Join(buttonToBounce[i].GetComponentInChildren<RectTransform>().DOScale(1f, 0.6f)).SetEase(Ease.OutBounce);
            sequence.SetLoops(1, LoopType.Yoyo);
        }
    }
}


