using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ending Level Variables")]
    public string levelToLoad;
    public bool levelEnding;
    public float timeToLoadLevel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        LockCursor();
    }

    void Update()
    {

    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCO());
    }

    public IEnumerator EndLevelCO()
    {
        levelEnding = true;
        PauseMenu.instance.canPause = false;
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(timeToLoadLevel);

        SceneManager.LoadScene(levelToLoad);
    }
}
