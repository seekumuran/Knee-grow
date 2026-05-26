using UnityEngine;

public class APKBuilder : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        Debug.Log("ANDROID BUILD ACTIVE");
#endif
    }
}
