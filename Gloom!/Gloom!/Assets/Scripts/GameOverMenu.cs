using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;

    [Header("Loading to Main Menu")]
    public string loadToMenu;

    [Header("Game Over Menu Variables")]
    public GameObject[] buttons;
    public CanvasGroup controlsMenu, optionsMenu, creditsMenu;
    public GameObject restartButton, gameOverScreen;
    public bool isDead;

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

    public void ChangeActiveButtons(int buttonToChoose)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[buttonToChoose]);
    }

    public void OpenGameOverScreen()
    {
        isDead = true;
        gameOverScreen.SetActive(true);
        PauseMenu.instance.canPause = false;
        GameManager.instance.UnLockCursor();
        AudioManager.instance.StopLevelMusic();
        Time.timeScale = 0;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restartButton);
    }

    public void RestartLevel()
    {
        ChangeTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenControls()
    {
        controlsMenu.alpha = 1;
        controlsMenu.blocksRaycasts = true;
    }

    public void CloseControls()
    {
        controlsMenu.alpha = 0;
        controlsMenu.blocksRaycasts = false;
    }

    public void OpenOptions()
    {
        optionsMenu.alpha = 1;
        optionsMenu.blocksRaycasts = true;
    }

    public void CloseOptions()
    {
        optionsMenu.alpha = 0;
        optionsMenu.blocksRaycasts = false;
    }

    public void OpenCredits()
    {
        creditsMenu.alpha = 1;
        creditsMenu.blocksRaycasts = true;
    }

    public void CloseCredits()
    {
        creditsMenu.alpha = 0;
        creditsMenu.blocksRaycasts = false;
    }

    public void LoadMainMenu()
    {
        ChangeTimeScale();
        SceneManager.LoadScene(loadToMenu);
    }

    public void ChangeTimeScale()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySFX(6);
    }

}
