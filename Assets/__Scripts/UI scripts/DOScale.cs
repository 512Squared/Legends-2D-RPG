using UnityEngine;
using DOTweenConfigs;

public class DOScale : MonoBehaviour
{
    [SerializeField]
    private Scale3DTweenConfig tweenConfig;

    private void Start()
    {
        transform.DOScale(tweenConfig);
    }
}