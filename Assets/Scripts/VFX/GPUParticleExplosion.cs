using UnityEngine;

public class GPUParticleExplosion : MonoBehaviour
{
    public ParticleSystem particles;

    void Start()
    {
        particles.Play();

        Destroy(
            gameObject,
            particles.main.duration
        );
    }
}
