using UnityEngine;

public class LockOnSystem : MonoBehaviour
{
    public float lockRange = 20f;

    public Transform currentTarget;

    public Camera mainCamera;

    public ThirdPersonCamera normalCamera;

    public LockOnCamera lockOnCamera;

    private bool lockedOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!lockedOn)
            {
                FindTarget();
            }
            else
            {
                Unlock();
            }
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

        if (nearest != null)
        {
            currentTarget = nearest;

            lockedOn = true;

            normalCamera.enabled = false;

            lockOnCamera.enabled = true;

            lockOnCamera.player = transform;

            lockOnCamera.currentTarget = currentTarget;
        }
    }

    void Unlock()
    {
        lockedOn = false;

        currentTarget = null;

        normalCamera.enabled = true;

        lockOnCamera.enabled = false;
    }
}
