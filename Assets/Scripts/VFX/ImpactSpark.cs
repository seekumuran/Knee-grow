using UnityEngine;

public class ImpactSpark : MonoBehaviour
{
    public ParticleSystem sparks;

    void Start()
    {
        sparks.Play();

        Destroy(
            gameObject,
            sparks.main.duration
        );
    }
}
