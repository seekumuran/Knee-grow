using UnityEngine;

public class CounterAttack : MonoBehaviour
{
    public int counterDamage = 40;

    public float counterRange = 3f;

    public LayerMask enemyLayer;

    public Transform counterPoint;

    public ParrySystem parry;

    void Update()
    {
        if (parry.SuccessfulParry() &&
            Input.GetMouseButtonDown(0))
        {
            PerformCounter();
        }
    }

    void PerformCounter()
    {
        Collider[] enemies =
            Physics.OverlapSphere(
                counterPoint.position,
                counterRange,
                enemyLayer
            );

        foreach (Collider enemy in enemies)
        {
            EnemyAI ai =
                enemy.GetComponent<EnemyAI>();

            if (ai != null)
            {
                ai.TakeDamage(counterDamage);
            }
        }

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.3f, 0.3f);
        }
    }
}
