using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [Header("Health Variables")]
    public int maxHealth;
    public int currentHealth;

    [Header("Armor Variables")]
    public int currentArmor;
    public int maxArmor;

    [Header("Invincibility Variables")]
    public float invincibleLength;
    [HideInInspector] public float invincibleCounter;
    public bool isInvincible;

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
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damageToDeal)
    {
        if (invincibleCounter <= 0)
        {
            if (currentArmor <= 0)
            {
                currentHealth -= damageToDeal;
                invincibleCounter = invincibleLength;
                UIController.instance.EnableHurtScreen();
                AudioManager.instance.PlaySFXAdjusted(5);

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    PlayerController.instance.GetComponent<CircleCollider2D>().enabled = false;
                    PlayerController.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    GameOverMenu.instance.OpenGameOverScreen();
                }

                UIController.instance.UpdateHealthUI();
            }
            else if (currentArmor >= 0)
            {
                currentArmor -= damageToDeal * 2;
                invincibleCounter = invincibleLength;
                UIController.instance.EnableHurtScreen();
                AudioManager.instance.PlaySFXAdjusted(5);

                if (currentArmor < 0)
                {
                    currentArmor = 0;
                }

                UIController.instance.UpdateArmorUI();
            }
        }
    }

    public void AddHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.ShowPickUpStatus(healthToAdd, "Health");
        UIController.instance.UpdateHealthUI();
    }

    public void AddArmor(int armorToAdd)
    {
        currentArmor += armorToAdd;

        if (currentArmor >= maxArmor)
        {
            currentArmor = maxArmor;
        }

        UIController.instance.ShowPickUpStatus(armorToAdd, "Armor");
        UIController.instance.UpdateArmorUI();
    }

    public void MakeInvincible(float invinciblePowerLength)
    {
        invincibleCounter += invinciblePowerLength;

        if (invincibleCounter >= 30)
        {
            invincibleCounter = 30;
        }

        isInvincible = true;
    }
}
