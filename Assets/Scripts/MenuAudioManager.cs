using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;

    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("Button Sounds")]
    public AudioClip buttonClickSound;

    void Start()
    {
        PlayBackgroundMusic();
    }

    // =========================
    // MUSIC
    // =========================

    void PlayBackgroundMusic()
    {
        if (backgroundMusic == null) return;

        musicSource.clip = backgroundMusic;

        musicSource.loop = true;

        musicSource.Play();
    }

    // =========================
    // BUTTON SOUND
    // =========================

    public void PlayButtonSound()
    {
        if (buttonClickSound == null) return;

        sfxSource.PlayOneShot(buttonClickSound);
    }
}
