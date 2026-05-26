using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinisherFlash : MonoBehaviour
{
    public Image flashImage;

    public float flashDuration = 0.2f;

    void Start()
    {
        flashImage.color =
            new Color(1, 1, 1, 0);
    }

    public void Flash()
    {
        StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {
        flashImage.color =
            new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(flashDuration);

        flashImage.color =
            new Color(1, 1, 1, 0);
    }
}
