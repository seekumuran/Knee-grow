using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;

    public float moveSpeed = 3f;

    public float attackRange = 2f;

    public EnemyFlash flashEffect;

    private int currentHealth;

    private Transform player;

    private bool dead;

    void Start()
    {
        currentHealth = maxHealth;

        GameObject playerObj =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (dead) return;

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
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction =
            (player.position - transform.position).normalized;

        direction.y = 0f;

        transform.position +=
            direction * moveSpeed * Time.deltaTime;

        transform.rotation =
            Quaternion.LookRotation(direction);
    }

    public void TakeDamage(int damage)
    {
        if (dead) return;

        currentHealth -= damage;

        if (flashEffect != null)
        {
            flashEffect.Flash();
        }

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.1f, 0.15f);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;

        Destroy(gameObject);
    }
}
