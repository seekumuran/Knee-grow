using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;
    public float moveSpeed = 3f;
    public float attackRange = 2f;

    private int currentHealth;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance =
            Vector3.Distance(transform.position, player.position);

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

        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
