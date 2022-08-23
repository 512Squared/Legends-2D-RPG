using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    private float dissolveAmount;
    [SerializeField] protected bool isDissolving;
    private static readonly int DissolveAmount = Shader.PropertyToID("_DissolveAmount");
    private float dissolveSpeed;

    [SerializeField] private SpriteRenderer sprite;

    private void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + (dissolveSpeed * Time.deltaTime));
            sprite.material.SetFloat(DissolveAmount, dissolveAmount);
        }

        else
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - (dissolveSpeed * Time.deltaTime));
            sprite.material.SetFloat(DissolveAmount, dissolveAmount);
        }
    }

    public void StartDissolve(float dissolveSpeed)
    {
        isDissolving = true;
        this.dissolveSpeed = dissolveSpeed;
    }

    public void StopDissolve(float dissolveSpeed)
    {
        isDissolving = false;
        this.dissolveSpeed = dissolveSpeed;
    }
}