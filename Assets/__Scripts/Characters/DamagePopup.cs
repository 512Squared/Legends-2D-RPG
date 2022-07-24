using System.Collections;
using CodeMonkey.Utils;
using UnityEngine;
using TMPro;
using UnityEngine.Diagnostics;

public class DamagePopup : MonoBehaviour
{
    private const float DisappearTimerMax = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;
    private static int sortingOrder;

    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        position = new Vector3(position.x, position.y, 0);
        Transform damagePopupTransform = Instantiate(GameAssets.Fetch.pdDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit);
        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount, bool isCriticalHit)
    {
        textMesh.fontSize = !isCriticalHit ? 5 : 7;
        textColor = !isCriticalHit ? UtilsClass.GetColorFromString("E59205") : UtilsClass.GetColorFromString("E51F06");
        damageAmount = !isCriticalHit ? damageAmount + Random.Range(4, 8) : damageAmount + Random.Range(15, 25);
        textMesh.SetText(damageAmount.ToString());
        textMesh.color = textColor;
        disappearTimer = DisappearTimerMax;
        moveVector = new Vector3(Random.Range(0.7f, 1.4f), Random.Range(0.7f, 1.4f)) * 2f;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        UtilsClass.ShakeCamera(0.6f, 0.05f);
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 1.2f * Time.deltaTime;
        if (disappearTimer > DisappearTimerMax * 0.5f)
        {
            const float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            const float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;


        if (disappearTimer < 0)
        {
            const float disappearSpeed = 1f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
        }

        if (textColor.a < 0) { Destroy(transform.gameObject); }
    }
}