using UnityEngine;
using DOTweenConfigs;

public class DoScale : MonoBehaviour
{
    [SerializeField]
    private Scale3DTweenConfig tweenConfig;

    private void Start()
    {
        transform.DOScale(tweenConfig);
    }
}