using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [Header("Health Variables")]
    public int maxHealth;
    public int currentHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(int damageToDeal)
    {
        currentHealth -= damageToDeal;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UIController.instance.ShowGameOver();
        }

        UIController.instance.UpdateHealthUI();
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
}
