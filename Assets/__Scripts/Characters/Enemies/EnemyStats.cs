using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private int hitPoints;
    public bool isBeingAttacked;

    [ShowInInspector]
    public int HitPoints
    {
        get => hitPoints;
        set => hitPoints = value;
    }

    private void Start()
    {
        HitPoints = 100;
    }
}