using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [Header("Variables to Use")]
    public Animator fadeScreen;
    public string levelToLoad;

    void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {

    }

    public void FadeFromBlack()
    {
        fadeScreen.SetBool("FadeIn", true);
    }

    public void FadeToBlack()
    {
        fadeScreen.SetBool("FadeOut", true);
        StartCoroutine(FadeFromBlackCo());
    }

    public IEnumerator FadeFromBlackCo()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LoadingScreen>().LoadScene(levelToLoad);
    }
}
