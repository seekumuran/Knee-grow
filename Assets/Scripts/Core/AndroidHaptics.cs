using UnityEngine;

public class AndroidHaptics : MonoBehaviour
{
    public static void Vibrate()
    {
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif
    }
}
