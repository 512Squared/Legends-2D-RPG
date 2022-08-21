using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AnimatorClipInfo[] animClip;

    [SerializeField]
    private ZombieController zombie;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animClip = animator.GetCurrentAnimatorClipInfo(0);
    }

    public void Hit(AnimationEvent evt)
    {
        if (evt.animatorClipInfo.weight > 0.5)
        {
            string dir = evt.stringParameter;
            zombie.AttackTarget();
        }
    }
}