using Assets.HeroEditor4D.Common.CharacterScripts;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class AttackDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !col.GetComponent<IDamageable>().IsDead)
        {
            Character4D character = GetComponentInParent<Character4D>();
            Character apex = character.GetComponentInChildren<Character>();
            if (PlayerGlobalData.Instance.debugOn) { Debug.Log($"Apex: {apex.AnchorSword.name}"); }
            PlayerGlobalData.Instance.HitEnemy(col, GetComponent<GenerateGUID>().GUID);
        }
    }
}