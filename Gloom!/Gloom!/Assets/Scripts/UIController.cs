using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Fade Screen Variables")]
    public Image fadeScreen;
    public float fadeSpeed;
    public bool fadeFromBlack, fadeToBlack;

    void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {
        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
            Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
            Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeFromBlack()
    {
        fadeFromBlack = true;
        fadeToBlack = false;
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
    }
}
