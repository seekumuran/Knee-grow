using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    public float attackRange = 3f;

    public int heavyDamage = 35;

    public LayerMask enemyLayer;

    public Transform heavyAttackPoint;

    public Animator animator;

    private bool canHeavy = true;

    private readonly int heavyHash =
        Animator.StringToHash("Heavy");

    void Update()
    {
        HandleHeavyAttack();
    }

    void HandleHeavyAttack()
    {
        if (Input.GetMouseButtonDown(1) && canHeavy)
        {
            PerformHeavyAttack();
        }
    }

    void PerformHeavyAttack()
    {
        canHeavy = false;

        animator.SetTrigger(heavyHash);

        Collider[] enemies =
            Physics.OverlapSphere(
                heavyAttackPoint.position,
                attackRange,
                enemyLayer
            );

        foreach (Collider enemy in enemies)
        {
            EnemyAI ai =
                enemy.GetComponent<EnemyAI>();

            if (ai != null)
            {
                ai.TakeDamage(heavyDamage);
            }

            Rigidbody rb =
                enemy.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 knockback =
                    (enemy.transform.position -
                     transform.position).normalized;

                rb.AddForce(
                    knockback * 8f +
                    Vector3.up * 4f,
                    ForceMode.Impulse
                );
            }
        }

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.25f, 0.3f);
        }

        if (HitStop.Instance != null)
        {
            HitStop.Instance.Stop(0.12f);
        }

        Invoke(nameof(ResetHeavy), 1f);
    }

    void ResetHeavy()
    {
        canHeavy = true;
    }
}
