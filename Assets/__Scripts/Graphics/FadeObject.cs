using System.Collections;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;  

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SpriteFade()
    {
        StartCoroutine(SpriteFade(spriteRenderer, 0, 3f));
    }

    public IEnumerator SpriteFade(
    SpriteRenderer sr,
    float endValue,
    float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
}
