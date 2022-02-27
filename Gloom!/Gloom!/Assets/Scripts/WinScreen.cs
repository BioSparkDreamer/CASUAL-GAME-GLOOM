using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public string levelToLoad;

    void Start()
    {
        GameManager.instance.UnLockCursor();
    }

    void Update()
    {

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySFX(6);
    }
}
