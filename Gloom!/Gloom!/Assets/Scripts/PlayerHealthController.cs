using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [Header("Health Variables")]
    public int maxHealth;
    public int currentHealth;

    [Header("Armor")]
    public int currentArmor;
    public int maxArmor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth;
        currentArmor = (maxArmor / 2);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(int damageToDeal)
    {
        if (currentArmor <= 0)
        {
            currentHealth -= damageToDeal;
            AudioManager.instance.PlaySFXAdjusted(5);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameOverMenu.instance.OpenGameOverScreen();
            }

            UIController.instance.UpdateHealthUI();
        }
        else if (currentArmor >= 0)
        {
            currentArmor -= damageToDeal * 2;
            AudioManager.instance.PlaySFXAdjusted(5);

            if (currentArmor < 0)
            {
                currentArmor = 0;
            }

            UIController.instance.UpdateArmorUI();
        }
    }

    public void AddHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthUI();
    }

    public void AddArmor(int armorToAdd)
    {
        currentArmor += armorToAdd;

        if (currentArmor >= maxArmor)
        {
            currentArmor = maxArmor;
        }

        UIController.instance.UpdateArmorUI();
    }
}
