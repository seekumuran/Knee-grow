using UnityEngine;
using System.Collections;

public class DashTrail : MonoBehaviour
{
    public GameObject ghostPrefab;

    public float spawnRate = 0.05f;

    public float ghostLifetime = 0.3f;

    private bool spawning;

    public void StartTrail()
    {
        if (!spawning)
        {
            StartCoroutine(SpawnTrail());
        }
    }

    public void StopTrail()
    {
        spawning = false;
    }

    IEnumerator SpawnTrail()
    {
        spawning = true;

        while (spawning)
        {
            GameObject ghost =
                Instantiate(
                    ghostPrefab,
                    transform.position,
                    transform.rotation
                );

            Destroy(ghost, ghostLifetime);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
