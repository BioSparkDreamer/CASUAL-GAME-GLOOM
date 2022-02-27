using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [Header("Ammo Pickup Variables")]
    public int ammoAmmount = 25;
    public bool isAmmo;

    [Header("Health Pickup Variables")]
    public int healthAmount = 20;
    public bool isHealth;

    [Header("Armor Pick Up Variables")]
    public int armorAmount = 20;
    public bool isArmor;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isAmmo)
            {
                PlayerController.instance.currentAmmo += ammoAmmount;
                UIController.instance.UpdateAmmoUI();
                AudioManager.instance.PlaySFXAdjusted(0);
                Destroy(gameObject);
            }

            if (isHealth && PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.AddHealth(healthAmount);
                UIController.instance.UpdateHealthUI();
                AudioManager.instance.PlaySFXAdjusted(4);
                Destroy(gameObject);
            }

            if (isArmor && PlayerHealthController.instance.currentArmor < PlayerHealthController.instance.maxArmor)
            {
                PlayerHealthController.instance.currentArmor += armorAmount;
                UIController.instance.UpdateArmorUI();
                AudioManager.instance.PlaySFXAdjusted(0);
                Destroy(gameObject);
            }
        }
    }
}
