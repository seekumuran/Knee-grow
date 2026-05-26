using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour
{
    public void TriggerSlowMotion(
        float slowAmount,
        float duration)
    {
        StartCoroutine(
            SlowMotionRoutine(
                slowAmount,
                duration
            )
        );
    }

    IEnumerator SlowMotionRoutine(
        float slowAmount,
        float duration)
    {
        Time.timeScale = slowAmount;

        yield return new WaitForSecondsRealtime(
            duration
        );

        Time.timeScale = 1f;
    }
}
