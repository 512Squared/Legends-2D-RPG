using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable
{
    void Damage(int damage);

    Vector3 GetPositionOfHead();
    string Combatant { get; }

    bool IsDead { get; set; }
}