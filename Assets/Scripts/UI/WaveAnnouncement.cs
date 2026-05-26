using UnityEngine;
using TMPro;
using System.Collections;

public class WaveAnnouncement : MonoBehaviour
{
    public TextMeshProUGUI announcementText;

    public float displayTime = 2f;

    void Start()
    {
        announcementText.gameObject.SetActive(false);
    }

    public void ShowWave(int wave)
    {
        StartCoroutine(ShowRoutine(wave));
    }

    IEnumerator ShowRoutine(int wave)
    {
        announcementText.gameObject.SetActive(true);

        announcementText.text =
            "WAVE " + wave;

        yield return new WaitForSeconds(displayTime);

        announcementText.gameObject.SetActive(false);
    }
}
