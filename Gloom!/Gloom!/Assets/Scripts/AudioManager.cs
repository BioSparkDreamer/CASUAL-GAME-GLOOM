using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Source Variables")]
    public AudioSource levelMusic, mainMenuMusic, pauseMusic, cutSceneMusic, winMusic;
    public AudioSource[] sfxEffects;
    public bool isLevel, isMainMenu, isWinMenu, isCutscene;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (isLevel)
        {
            levelMusic.Play();
        }

        if (isMainMenu)
        {
            mainMenuMusic.Play();
        }

        if (isCutscene)
        {
            cutSceneMusic.Play();
        }

        if (isWinMenu)
        {
            winMusic.Play();
        }
    }

    void Update()
    {

    }

    public void StopLevelMusic()
    {
        levelMusic.Pause();
        pauseMusic.Play();
    }

    public void ResumeLevelMusic()
    {
        levelMusic.Play();
        pauseMusic.Stop();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfxEffects[sfxToPlay].Stop();
        sfxEffects[sfxToPlay].Play();
    }

    public void PlaySFXAdjusted(int sfxToPlay)
    {
        sfxEffects[sfxToPlay].pitch = Random.Range(0.8f, 1.2f);
        sfxEffects[sfxToPlay].Play();
    }
}
