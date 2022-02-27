using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("Fade Screen Variables")]
    public Image fadeScreen;
    public float fadeSpeed;
    public bool fadeFromBlack, fadeToBlack;

    [Header("HUD Variables")]
    public TMP_Text healthText;
    public TMP_Text ammoText;
    public TMP_Text armorText;

    [Header("Hurt Screen Variables")]
    public float hurtScreenLength;
    private float hurtCounter;
    public GameObject hurtScreen;

    [Header("Key Variables")]
    public bool hasBlueKey;
    public Image blueKeyCard;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        FadeFromBlack();
        UpdateAmmoUI();
        UpdateHealthUI();
        UpdateArmorUI();
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

        if (hurtCounter > 0)
        {
            hurtCounter -= Time.deltaTime;
            hurtScreen.SetActive(true);
        }
        else
        {
            hurtScreen.SetActive(false);
        }
    }

    public void UpdateHealthUI()
    {
        healthText.text = PlayerHealthController.instance.currentHealth.ToString() + "%";
    }
    public void UpdateAmmoUI()
    {
        ammoText.text = PlayerController.instance.currentAmmo.ToString();
    }

    public void UpdateArmorUI()
    {
        armorText.text = PlayerHealthController.instance.currentArmor.ToString() + "%";
    }

    public void EnableHurtScreen()
    {
        hurtCounter = hurtScreenLength;
    }

    public void UpdateBlueKey()
    {
        hasBlueKey = true;
        blueKeyCard.gameObject.SetActive(true);
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
