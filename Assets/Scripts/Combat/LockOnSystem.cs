using UnityEngine;

public class LockOnSystem : MonoBehaviour
{
    public float lockRange = 15f;

    public Transform currentTarget;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        Collider[] enemies =
            Physics.OverlapSphere(
                transform.position,
                lockRange
            );

        float closestDistance = Mathf.Infinity;

        Transform nearest = null;

        foreach (Collider col in enemies)
        {
            if (!col.CompareTag("Enemy")) continue;

            float distance =
                Vector3.Distance(
                    transform.position,
                    col.transform.position
                );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = col.transform;
            }
        }

        currentTarget = nearest;
    }
}
