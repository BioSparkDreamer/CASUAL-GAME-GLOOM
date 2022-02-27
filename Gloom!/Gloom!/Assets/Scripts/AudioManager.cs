using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Source Variables")]
    public AudioSource levelMusic;
    public AudioSource[] sfxEffects;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {

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
