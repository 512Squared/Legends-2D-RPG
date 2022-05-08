#if UNITY_EDITOR
using AutoFill;
using UnityEngine;

public class FillTest : MonoBehaviour
{
    [SerializeField, Tooltip("It Will Fill This Field From Self GO If Can't Find Then From Parent GameObject")]
    [Fill]
    private BoxCollider boxCollider;
    
    [Header("It will find required Component at specified path")]
    [SerializeField, Fill("Just/another/game object/to/test the filler/My Object")]
    private LineRenderer findAtPathExample;
    
    [Header("It will find required Component in child")]
    [SerializeField, Fill(FindIn.Child)]
    private LineRenderer findInChildExample;
    
    //It will work on object type fields
    [SerializeField, Fill]
    private int intTest;
}
#endif