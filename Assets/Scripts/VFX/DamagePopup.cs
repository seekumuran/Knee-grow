using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TextMeshPro textMesh;

    public float moveSpeed = 2f;

    public float lifeTime = 1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position +=
            Vector3.up *
            moveSpeed *
            Time.deltaTime;
    }

    public void Setup(int damage)
    {
        textMesh.text = damage.ToString();
    }
}
