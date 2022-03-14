using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public static SettingsController instance;

    [Header("FPS Counter Variables")]
    public Toggle fpsToggle;
    public TMP_Text fpsText;
    public GameObject fpsCounterObject;
    [HideInInspector] public int fpsInt;

    [Header("Fullscreen Toggle Variables")]
    public Toggle fullScreenToggle;
    [HideInInspector] public int screenInt;

    [Header("Vsync Variables")]
    public Toggle vSyncToggle;
    [HideInInspector] public int syncInt;

    [Header("Invert Variables")]
    public Toggle xInvertToggle;
    [HideInInspector] public int xInt;
    public Toggle yInvertToggle;
    [HideInInspector] public int yInt;

    [Header("HUD Variables")]
    public Toggle hudToggle;
    [HideInInspector] public int hudInt;

    [Header("Audio Variables")]
    public AudioMixer theMixer;
    public Slider masterSlider, musicSlider, sfxSlider;
    public TMP_Text masterText, musicText, sfxText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //FPS Counter Toggle
        if (PlayerPrefs.HasKey("FpsToggleState"))
        {
            fpsInt = PlayerPrefs.GetInt("FpsToggleState");
        }
        else
        {
            fpsInt = 1;
        }

        if (fpsInt == 1)
        {
            fpsToggle.isOn = true;
            fpsCounterObject.SetActive(true);
        }
        else
        {
            fpsToggle.isOn = false;
            fpsCounterObject.SetActive(false);
        }


        //Fullscreen Toggle
        if (PlayerPrefs.HasKey("FullScreenState"))
        {
            screenInt = PlayerPrefs.GetInt("FullScreenState");
        }
        else
        {
            screenInt = 1;
        }

        if (screenInt == 1)
        {
            fullScreenToggle.isOn = true;
            Screen.fullScreen = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;
        }

        //Vsync Toggle
        if (PlayerPrefs.HasKey("SyncToggleState"))
        {
            syncInt = PlayerPrefs.GetInt("SyncToggleState");
        }
        else
        {
            syncInt = 1;
        }

        if (syncInt == 1)
        {
            vSyncToggle.isOn = true;
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            vSyncToggle.isOn = false;
            QualitySettings.vSyncCount = 0;
        }

        //Invert Toggles
        if (PlayerPrefs.HasKey("InvertXState"))
        {
            xInt = PlayerPrefs.GetInt("InvertXState");
        }
        else
        {
            syncInt = 0;
        }

        if (xInt == 1)
        {
            xInvertToggle.isOn = true;
        }
        else
        {
            xInvertToggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("InvertYState"))
        {
            yInt = PlayerPrefs.GetInt("InvertYState");
        }
        else
        {
            yInt = 0;
        }

        if (yInt == 1)
        {
            yInvertToggle.isOn = true;
        }

        else
        {
            yInvertToggle.isOn = false;
        }

        //HUD Toggle
        if (PlayerPrefs.HasKey("HudToggleState"))
        {
            hudInt = PlayerPrefs.GetInt("HudToggleState");
        }
        else
        {
            hudInt = 1;
        }

        if (hudInt == 1)
        {
            hudToggle.isOn = true;
        }

        else
        {
            hudToggle.isOn = false;
        }
    }

    void Start()
    {
        //Master Volume Slider
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVolume"));
            Debug.Log("Setting Mixer");
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        //Music Volume Slider
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVolume"));
            Debug.Log("Setting Music Mixer");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        //SFX Volume Slider
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            theMixer.SetFloat("SfxVol", PlayerPrefs.GetFloat("SfxVolume"));
            sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        }

        masterText.text = (masterSlider.value + 80).ToString() + "%";
        musicText.text = (musicSlider.value + 80).ToString() + "%";
        sfxText.text = (sfxSlider.value + 80).ToString() + "%";
    }

    void Update()
    {
        //Calculating FPS
        float fps = 1 / Time.unscaledDeltaTime;
        fpsText.text = "FPS:   " + fps.ToString("F0");
    }

    public void FpsToggleMode(bool isFpsOn)
    {
        if (isFpsOn == false)
        {
            PlayerPrefs.SetInt("FpsToggleState", 0);
            fpsCounterObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("FpsToggleState", 1);
            fpsCounterObject.SetActive(true);
            Debug.Log("FPS Counter is Off");
        }
    }

    public void FullscreenMode(bool isFullScreenOn)
    {
        Screen.fullScreen = isFullScreenOn;

        if (isFullScreenOn == false)
        {
            isFullScreenOn = false;
            PlayerPrefs.SetInt("FullScreenState", 0);
        }
        else
        {
            isFullScreenOn = true;
            PlayerPrefs.SetInt("FullScreenState", 1);
            Debug.Log("Changing to fullscreen");
        }
    }

    public void VsyncToggleMode(bool isSyncOn)
    {
        if (isSyncOn == false)
        {
            PlayerPrefs.SetInt("SyncToggleState", 0);
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            PlayerPrefs.SetInt("SyncToggleState", 1);
            QualitySettings.vSyncCount = 1;
            Debug.Log("Vsync is On");
        }
    }

    public void InvertXState(bool isXInverted)
    {
        if (isXInverted == false)
        {
            PlayerPrefs.SetInt("InvertXState", 0);
            Debug.Log("Camera X Invert is Off");
        }
        else
        {
            PlayerPrefs.SetInt("InvertXState", 1);
        }
    }

    public void InvertYState(bool isYInverted)
    {
        if (isYInverted == false)
        {
            PlayerPrefs.SetInt("InvertYState", 0);
            Debug.Log("Camera Y Invert is Off");
        }
        else
        {
            PlayerPrefs.SetInt("InvertYState", 1);
        }
    }

    public void HudToggleState(bool isHudOn)
    {
        if (isHudOn == false)
        {
            PlayerPrefs.SetInt("HudToggleState", 0);
            Debug.Log("HUD is Off");
        }
        else
        {
            PlayerPrefs.SetInt("HudToggleState", 1);
        }
    }

    public void MasterVolume()
    {
        masterText.text = (masterSlider.value + 80).ToString() + "%";
        theMixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void MusicVolume()
    {
        musicText.text = (musicSlider.value + 80).ToString() + "%";
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SfxVolume()
    {
        sfxText.text = (sfxSlider.value + 80).ToString() + "%";
        theMixer.SetFloat("SfxVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
    }
}
