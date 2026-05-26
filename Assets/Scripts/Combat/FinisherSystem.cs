using UnityEngine;

public class FinisherSystem : MonoBehaviour
{
    public float finisherRange = 3f;

    public LayerMask enemyLayer;

    public FinisherFlash flash;

    public GameObject shockwavePrefab;

    public Transform shockwaveSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PerformFinisher();
        }
    }

    void PerformFinisher()
    {
        Collider[] enemies =
            Physics.OverlapSphere(
                transform.position,
                finisherRange,
                enemyLayer
            );

        foreach (Collider enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        if (flash != null)
        {
            flash.Flash();
        }

        if (shockwavePrefab != null)
        {
            Instantiate(
                shockwavePrefab,
                shockwaveSpawn.position,
                Quaternion.identity
            );
        }

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.4f, 0.4f);
        }

        if (HitStop.Instance != null)
        {
            HitStop.Instance.Stop(0.12f);
        }
    }
}
