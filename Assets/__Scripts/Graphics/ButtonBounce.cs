using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Collections;

public class ButtonBounce : MonoBehaviour
{

    [SerializeField] RectTransform[] buttonToBounce;
    [Range(0.5f, 2f)]
    [SerializeField] float minImageSize = 0.8f;
    [Range(0.5f, 2f)]
    [SerializeField] float maxImageSize = 1.2f;
    [Range(0.5f, 2f)]
    [SerializeField] float minButtonSize = 0.7f;
    [Range(0.5f, 2f)]    
    [SerializeField] float maxButtonSize = 1f;
    public RectTransform item;

    

    private void Awake()
    {
        for (int i = 0; i < buttonToBounce.Length; i++)
        {
            Button btn = buttonToBounce[i].gameObject.GetComponentInChildren<Button>();
            btn.onClick.AddListener(ButtonBouncing);
        }        
    }

    [TabGroup("Buttons"), Button]
    public void ButtonBouncing()
    {
        for (int i = 0; i < buttonToBounce.Length; i++)
        {
            var sequence = DOTween.Sequence()
            .Append(buttonToBounce[i].DOScale(0.9f, 0.2f)).SetEase(Ease.InBounce)
            .Join(buttonToBounce[i].GetComponentInChildren<RectTransform>().DOScale(minButtonSize, 0.2f)).SetEase(Ease.InBounce)
            .Append(buttonToBounce[i].DOScale(1f, 0.6f)).SetEase(Ease.OutBounce)
            .Join(buttonToBounce[i].GetComponentInChildren<RectTransform>().DOScale(maxButtonSize, 0.6f)).SetEase(Ease.OutBounce);
            sequence.SetLoops(1, LoopType.Yoyo);
        }
    }
    [TabGroup("Buttons"), Button]
    public void ImageBouncing()
    {
        for (int i = 0; i < buttonToBounce.Length; i++)
        {
            var sequence = DOTween.Sequence()
            .Append(buttonToBounce[i].GetComponentInChildren<RectTransform>().DOScale(maxImageSize, 0.6f))
            .Append(buttonToBounce[i].GetComponent<RectTransform>().DOScale(minImageSize, 0.7f));
            sequence.SetLoops(1, LoopType.Yoyo);
        }
    }
    [TabGroup("Buttons"), Button]
    public void AnimateItemSelection()
    {
        StartCoroutine(AnimateCoRoutine());
    }

   IEnumerator AnimateCoRoutine()
    {
        yield return null;
        var sequence = DOTween.Sequence()
        .Append(item.DOScale(0.9f, 0.2f)).SetEase(Ease.InBounce)
        .Join(item.GetComponentInChildren<RectTransform>().DOScale(minButtonSize, 0.2f)).SetEase(Ease.InBounce)
        .Append(item.DOScale(1f, 0.6f)).SetEase(Ease.OutBounce)
        .Join(item.GetComponentInChildren<RectTransform>().DOScale(maxButtonSize, 0.6f)).SetEase(Ease.OutBounce);
        sequence.SetLoops(1, LoopType.Yoyo);
    }
}


