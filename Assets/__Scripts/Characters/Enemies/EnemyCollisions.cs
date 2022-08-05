using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    [SerializeField]
    private ZombieController zombieController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable hit))
        {
            //zombieController.hitTarget = hit;
        }
    }
}