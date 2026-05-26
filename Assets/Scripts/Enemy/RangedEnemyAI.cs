using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform firePoint;

    public float fireRate = 2f;

    public float attackRange = 10f;

    public float moveSpeed = 2f;

    private float fireTimer;

    private Transform player;

    void Start()
    {
        GameObject p =
            GameObject.FindGameObjectWithTag("Player");

        if (p != null)
        {
            player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 dir =
            (player.position - transform.position).normalized;

        dir.y = 0;

        transform.position +=
            dir * moveSpeed * Time.deltaTime;

        transform.rotation =
            Quaternion.LookRotation(dir);
    }

    void AttackPlayer()
    {
        transform.LookAt(player);

        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            FireProjectile();

            fireTimer = fireRate;
        }
    }

    void FireProjectile()
    {
        GameObject proj =
            Instantiate(
                projectilePrefab,
                firePoint.position,
                Quaternion.identity
            );

        EnemyProjectile projectile =
            proj.GetComponent<EnemyProjectile>();

        Vector3 dir =
            (player.position - firePoint.position).normalized;

        projectile.Initialize(dir);
    }
}
