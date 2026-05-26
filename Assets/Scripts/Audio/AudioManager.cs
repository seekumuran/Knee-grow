using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("SFX")]
    public AudioSource sfxSource;

    public AudioClip hitSound;
    public AudioClip blastSound;
    public AudioClip dashSound;
    public AudioClip explosionSound;

    [Header("Music")]
    public AudioSource musicSource;

    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    void PlayMusic()
    {
        musicSource.clip = backgroundMusic;

        musicSource.loop = true;

        musicSource.Play();
    }
}
