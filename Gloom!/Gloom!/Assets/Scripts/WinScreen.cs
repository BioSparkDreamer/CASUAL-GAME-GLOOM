using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WinScreen : MonoBehaviour
{
    public string levelToLoad;

    public float timeBetweenObjects = 1f;
    public GameObject winText, creditsButton, menuButton, quitButton, creditsBackButton;
    public CanvasGroup creditsMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(ShowObjectsCo());
    }

    void Update()
    {

    }

    public IEnumerator ShowObjectsCo()
    {
        yield return new WaitForSeconds(timeBetweenObjects);

        winText.SetActive(true);

        yield return new WaitForSeconds(timeBetweenObjects);

        creditsButton.SetActive(true);

        yield return new WaitForSeconds(timeBetweenObjects);

        menuButton.SetActive(true);

        yield return new WaitForSeconds(timeBetweenObjects);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsButton);
        quitButton.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsMenu.alpha = 1;
        creditsMenu.blocksRaycasts = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsBackButton);
    }

    public void CloseCredits()
    {
        creditsMenu.alpha = 0;
        creditsMenu.blocksRaycasts = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySFX(6);
    }
}
