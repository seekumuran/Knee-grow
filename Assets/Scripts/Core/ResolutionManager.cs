using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public void Set1080p()
    {
        Screen.SetResolution(
            1920,
            1080,
            true
        );
    }

    public void Set720p()
    {
        Screen.SetResolution(
            1280,
            720,
            true
        );
    }
}
