using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [Header("Loading Screen Variables")]
    public GameObject loadingScreen;
    public TMP_Text loadingText, loadingTextOutline;
    public Slider loadingBar;

    void Start()
    {

    }

    void Update()
    {

    }

    public void LoadScene(string levelToLoad)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelCO(levelToLoad));
    }

    public IEnumerator LoadLevelCO(string levelToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            loadingText.text = "Loading...";
            loadingTextOutline.text = "Loading...";

            if (operation.progress >= .9f)
            {
                loadingText.text = "Press any Key/Button to Continue";
                loadingTextOutline.text = "Press any Key/Button to Continue";
                if (Input.anyKeyDown && !operation.allowSceneActivation)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
