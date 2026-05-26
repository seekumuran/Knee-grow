using UnityEngine;

public class BlastAttack : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform firePoint;

    public float cooldown = 1f;

    private bool canFire = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canFire)
        {
            FireBlast();
        }
    }

    void FireBlast()
    {
        canFire = false;

        GameObject projectile =
            Instantiate(
                projectilePrefab,
                firePoint.position,
                Quaternion.identity
            );

        Projectile proj = projectile.GetComponent<Projectile>();

        proj.Initialize(transform.forward);

        Invoke(nameof(ResetCooldown), cooldown);
    }

    void ResetCooldown()
    {
        canFire = true;
    }
}
