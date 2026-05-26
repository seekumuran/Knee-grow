using UnityEngine;

public class BossAI : MonoBehaviour
{
    public int maxHealth = 500;

    public float moveSpeed = 4f;

    public bool rageMode;

    private int currentHealth;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;

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

        MoveTowardsPlayer();

        if (!rageMode &&
            currentHealth <= maxHealth * 0.4f)
        {
            ActivateRage();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 dir =
            (player.position - transform.position)
            .normalized;

        dir.y = 0;

        transform.position +=
            dir * moveSpeed * Time.deltaTime;

        transform.rotation =
            Quaternion.LookRotation(dir);
    }

    void ActivateRage()
    {
        rageMode = true;

        moveSpeed *= 1.8f;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
