using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public float expandSpeed = 15f;

    public float maxScale = 10f;

    void Update()
    {
        transform.localScale +=
            Vector3.one *
            expandSpeed *
            Time.deltaTime;

        if (transform.localScale.x >= maxScale)
        {
            Destroy(gameObject);
        }
    }
}
