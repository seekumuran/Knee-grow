using UnityEngine;

public class AirComboManager : MonoBehaviour
{
    public float airComboForce = 5f;

    public LayerMask enemyLayer;

    public Transform attackPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            LaunchAirCombo();
        }
    }

    void LaunchAirCombo()
    {
        Collider[] enemies =
            Physics.OverlapSphere(
                attackPoint.position,
                3f,
                enemyLayer
            );

        foreach (Collider enemy in enemies)
        {
            Rigidbody rb =
                enemy.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(
                    Vector3.up * airComboForce,
                    ForceMode.Impulse
                );
            }
        }
    }
}
