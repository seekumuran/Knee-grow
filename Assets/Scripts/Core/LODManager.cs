using UnityEngine;

public class LODManager : MonoBehaviour
{
    public GameObject highDetail;

    public GameObject lowDetail;

    public float switchDistance = 20f;

    private Transform player;

    void Start()
    {
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

        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        if (distance > switchDistance)
        {
            highDetail.SetActive(false);

            lowDetail.SetActive(true);
        }
        else
        {
            highDetail.SetActive(true);

            lowDetail.SetActive(false);
        }
    }
}
