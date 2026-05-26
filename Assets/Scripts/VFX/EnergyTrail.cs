using UnityEngine;

public class EnergyTrail : MonoBehaviour
{
    public TrailRenderer trail;

    void Start()
    {
        trail.emitting = true;
    }
}
