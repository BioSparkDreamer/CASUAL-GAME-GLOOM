using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [Header("Health Pickup Variables")]
    public int healthAmount = 20;
    public bool isHealth;

    [Header("Armor Pick Up Variables")]
    public int armorAmount = 20;
    public bool isArmor;

    public bool isCollected;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            if (isHealth && PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.AddHealth(healthAmount);
                UIController.instance.UpdateHealthUI();
                AudioManager.instance.PlaySFXAdjusted(4);
                isCollected = true;
                Destroy(gameObject);
            }

            if (isArmor && PlayerHealthController.instance.currentArmor < PlayerHealthController.instance.maxArmor)
            {
                PlayerHealthController.instance.currentArmor += armorAmount;
                UIController.instance.UpdateArmorUI();
                AudioManager.instance.PlaySFXAdjusted(0);
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }
}
