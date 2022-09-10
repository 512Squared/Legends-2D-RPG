using Assets.HeroEditor4D.Common.CharacterScripts;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class AttackDetection : MonoBehaviour
{
    private Character4D character;
    private PlayerStats player;

    public bool hitPossible;

    private void Start()
    {
        character = GetComponentInParent<Character4D>();
        player = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            switch (hitPossible)
            {
                case false:
                    {
                        if (GameManager.Instance.battle) { Debug.Log($"Trigger detected, but hit not possible"); }

                        return;
                    }
                case true when col.gameObject.GetComponent<ZombieController>().isInAttackRange && col.GetComponent<IDamageable>().IsAlive:
                    {
                        Character apex = character.GetComponentInChildren<Character>();
                        player.HitEnemy(col, GetComponent<GenerateGUID>().GUID, apex);
                        if (GameManager.Instance.battle) { Debug.Log($"Hit possible and initiated: "); }

                        hitPossible = false;
                        if (GameManager.Instance.battle) { Debug.Log($"Apex: {apex.AnchorSword.name}"); }

                        if (GameManager.Instance.battle)
                        {
                            Debug.Log($"HitBox: {transform.name} | Activate on: {player.playerName} | Enemy: {col.name}");
                        }

                        break;
                    }
            }
        }
    }
}