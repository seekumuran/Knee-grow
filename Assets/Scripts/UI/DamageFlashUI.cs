using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlashUI : MonoBehaviour
{
    public Image flashImage;

    public float flashDuration = 0.15f;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        flashImage.color =
            new Color(1, 0, 0, 0.4f);

        yield return new WaitForSeconds(flashDuration);

        flashImage.color =
            new Color(1, 0, 0, 0);
    }
}
