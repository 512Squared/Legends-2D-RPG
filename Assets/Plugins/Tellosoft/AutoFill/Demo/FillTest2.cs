#if UNITY_EDITOR
using AutoFill;
using UnityEngine;

public class FillTest2 : MonoBehaviour
{
    [Fill(FindIn.Parent)]
    public Rigidbody2D rbInParent;
    
    [Fill(FindIn.Parent)]
    public EdgeCollider2D edgeColliderInParent;
}
#endif