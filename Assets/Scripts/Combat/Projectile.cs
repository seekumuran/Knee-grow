using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public int damage = 20;
    public float lifeTime = 3f;

    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position +=
            direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                if (HitStop.Instance != null)
                {
                    HitStop.Instance.Stop(0.05f);
                }
            }

            Destroy(gameObject);
        }
    }
}
