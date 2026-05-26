using UnityEngine;

public class HitReactionController : MonoBehaviour
{
    public Animator animator;

    private readonly int hitHash =
        Animator.StringToHash("Hit");

    public void PlayHitReaction()
    {
        animator.SetTrigger(hitHash);
    }
}
