using UnityEngine;

public class EnergyExplosion : MonoBehaviour
{
    public float duration = 0.5f;

    public float expandSpeed = 8f;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void Update()
    {
        transform.localScale +=
            Vector3.one *
            expandSpeed *
            Time.deltaTime;
    }
}
