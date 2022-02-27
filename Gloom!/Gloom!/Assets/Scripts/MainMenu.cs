using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [Header("Starting Game")]
    public string sceneToLoad;

    [Header("Menu Object Variables")]
    public GameObject[] buttons;
    public CanvasGroup mainMenu, optionsMenu, controlsMenu, creditsMenu;
    public GameObject startMenu;

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

    public void OpenMainMenu()
    {
        startMenu.SetActive(false);
        mainMenu.alpha = 1;
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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySFX(6);
    }
}
