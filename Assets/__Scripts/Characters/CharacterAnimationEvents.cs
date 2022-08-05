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
            switch (dir)
            { 
                case "front":
                    Debug.Log($"Front attack hit");
                    zombie.Attack("front");
                    break;
                case "back": Debug.Log($"Back attack hit");
                    zombie.Attack("back");
                    break;
                case "left": Debug.Log($"Left attack hit");
                    zombie.Attack("left");
                    break;
                case "right": Debug.Log($"Right attack hit");
                    zombie.Attack("right");
                    break;
            }
        }
    }
    
    
}