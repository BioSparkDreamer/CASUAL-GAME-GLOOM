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
    public CanvasGroup theHud;

    [Header("Hurt Screen Variables")]
    public Image hurtScreen;
    public float hurtAlpha = .25f, hurtFadeSpeed = 2f;

    [Header("Objective Variables")]
    public TMP_Text objectiveText;
    public Transform blueKeycardDoor, yellowKeyCardDoor, redKeyCardDoor, exitDoor;
    private float distance;

    //Key Variables
    public bool hasBlueKey, hasYellowKey, hasRedKey;
    public Image blueKeyCard, yellowKeyCard, redKeyCard;
    public int currentObjective = 3;

    //Status Text Variables
    public TMP_Text invincibileStatusText, damageStatusText, speedStatusText,
    pickUpStatusEffect;

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
        EnableDisableHud();
        UpdateXCamera();
        UpdateYCamera();
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

        //Hurt Screen
        if (hurtScreen.color.a != 0)
        {
            hurtScreen.color = new Color(hurtScreen.color.r, hurtScreen.color.g, hurtScreen.color.b,
            Mathf.MoveTowards(hurtScreen.color.a, 0f, hurtFadeSpeed * Time.deltaTime));
        }

        //Count down Invinciblity Duration
        if (PlayerHealthController.instance.isInvincible)
        {
            invincibileStatusText.gameObject.SetActive(true);
            invincibileStatusText.text = "Invincibility: " + PlayerHealthController.instance.invincibleCounter.ToString("F0") + " Seconds";

            if (PlayerHealthController.instance.invincibleCounter <= 0.1f && PlayerHealthController.instance.isInvincible)
            {
                PlayerHealthController.instance.isInvincible = false;
                invincibileStatusText.gameObject.SetActive(false);
            }
        }

        if (PlayerController.instance.hasDoubleSpeed)
        {
            speedStatusText.gameObject.SetActive(true);
            speedStatusText.text = "2X Speed: " + PlayerController.instance.speedPowerCounter.ToString("F0") + " Seconds";

            if (PlayerController.instance.speedPowerCounter <= 0.1f && PlayerController.instance.hasDoubleSpeed)
            {
                speedStatusText.gameObject.SetActive(false);
            }
        }

        if (PlayerController.instance.hasDoubleDamage)
        {
            damageStatusText.gameObject.SetActive(true);
            damageStatusText.text = "2X Damage: " + PlayerController.instance.damagePowerCounter.ToString("F0") + " Seconds";

            if (PlayerController.instance.damagePowerCounter <= 0.1f && PlayerController.instance.hasDoubleDamage)
            {
                damageStatusText.gameObject.SetActive(false);
            }
        }

        ChangingObjectiveText();
    }

    public void ChangingObjectiveText()
    {
        switch (currentObjective)
        {
            case 3:
                {
                    if (hasBlueKey)
                    {
                        distance = (blueKeycardDoor.transform.position - PlayerController.instance.transform.position).magnitude;
                        objectiveText.text = "Distance to Blue Door: " + distance.ToString("F1") + " meters";
                    }
                    else if (!hasBlueKey)
                        objectiveText.text = "Find the Blue Keycard!";

                    break;
                }

            case 2:
                {
                    if (hasYellowKey)
                    {
                        distance = (yellowKeyCardDoor.transform.position - PlayerController.instance.transform.position).magnitude;
                        objectiveText.text = "Distance to Yellow Door: " + distance.ToString("F1") + " meters";
                    }
                    else if (!hasYellowKey)
                        objectiveText.text = "Find the Yellow Keycard!";

                    break;
                }

            case 1:
                {
                    if (hasRedKey)
                    {
                        distance = (redKeyCardDoor.transform.position - PlayerController.instance.transform.position).magnitude;
                        objectiveText.text = "Distance to Red Door: " + distance.ToString("F1") + " meters";
                    }
                    else if (!hasRedKey)
                        objectiveText.text = "Find the Red Keycard!";

                    break;
                }
            case 0:
                {
                    distance = (exitDoor.transform.position - PlayerController.instance.transform.position).magnitude;
                    objectiveText.text = "Distance to Exit: " + distance.ToString("F1") + " meters";
                    break;
                }
        }
    }

    public void UpdateHealthUI()
    {
        healthText.text = PlayerHealthController.instance.currentHealth.ToString();
    }
    public void UpdateAmmoUI()
    {
        ammoText.text = PlayerController.instance.activeGun.currentAmmo.ToString();
    }

    public void UpdateArmorUI()
    {
        armorText.text = PlayerHealthController.instance.currentArmor.ToString();
    }

    public void EnableHurtScreen()
    {
        hurtScreen.color = new Color(hurtScreen.color.r, hurtScreen.color.g, hurtScreen.color.b, hurtAlpha);
    }

    public void UpdateBlueKey()
    {
        hasBlueKey = true;
        blueKeyCard.gameObject.SetActive(true);
    }

    public void UpdateYellowKey()
    {
        hasYellowKey = true;
        yellowKeyCard.gameObject.SetActive(true);
    }

    public void UpdateRedKey()
    {
        hasRedKey = true;
        redKeyCard.gameObject.SetActive(true);
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

    public void ShowPickUpStatus(int amountToAdd, string whatIsPickup)
    {
        pickUpStatusEffect.gameObject.SetActive(true);

        if (whatIsPickup == "Health")
            pickUpStatusEffect.text = "Health Added: +" + amountToAdd.ToString();

        if (whatIsPickup == "Armor")
            pickUpStatusEffect.text = "Armor Added: +" + amountToAdd.ToString();

        if (whatIsPickup == "Pistol")
            pickUpStatusEffect.text = "Proton .45 Ammo: +" + amountToAdd.ToString();

        if (whatIsPickup == "Shotgun")
            pickUpStatusEffect.text = "Ghostbuster-3000 Ammo: +" + amountToAdd.ToString();

        if (whatIsPickup == "MachineGun")
            pickUpStatusEffect.text = "Poltabuster-47 Ammo: +" + amountToAdd.ToString();

        if (whatIsPickup == "ShotgunPickup")
            pickUpStatusEffect.text = "Picked up Ghostbuster-3000 ";

        if (whatIsPickup == "MachineGunPickup")
            pickUpStatusEffect.text = "Picked up Poltabuster-47 ";

        StartCoroutine(DissapearTextCo(pickUpStatusEffect));
    }

    public IEnumerator DissapearTextCo(TMP_Text statusText)
    {
        yield return new WaitForSeconds(3.5f);
        statusText.gameObject.SetActive(false);
    }

    public void EnableDisableHud()
    {
        if (SettingsController.instance.hudToggle.isOn == true)
        {
            theHud.alpha = 1;
        }
        else if (SettingsController.instance.hudToggle.isOn == false)
        {
            theHud.alpha = 0;
        }
    }

    public void UpdateXCamera()
    {
        if (SettingsController.instance.xInvertToggle.isOn == true)
        {
            PlayerController.instance.invertX = true;
        }
        else
        {
            PlayerController.instance.invertX = false;
        }
    }

    public void UpdateYCamera()
    {
        if (SettingsController.instance.yInvertToggle.isOn == true)
        {
            PlayerController.instance.invertY = true;
        }
        else if (SettingsController.instance.yInvertToggle.isOn == false)
        {
            PlayerController.instance.invertY = false;
        }
    }
}
