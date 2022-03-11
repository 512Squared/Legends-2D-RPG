
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
[RequireComponent(typeof(Graphic))]
public class GrayscaleEffectApplier : MonoBehaviour
{
    [Range(0, 1)]
    public float effect = 1;

    public Material mat;


    void Start()
    {
        Image img = GetComponent<Image>();
        if (img.material.name == "GrayscaleEffect") { mat = img.material; }
        else
        {
            img.material = Resources.Load("Materials/GrayscaleEffect", typeof(Material)) as Material;
            mat = img.material;
        };
    }


    void Update()
    {
        Image img = GetComponent<Image>(); // FIXED
        mat = img.materialForRendering; // FIXED
        if (mat != null) mat.SetFloat("_EffectAmount", effect);//_EffectAmount  // _GrayscaleAmount
    }
}
