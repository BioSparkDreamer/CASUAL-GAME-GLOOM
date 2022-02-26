using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [Header("Health Variables")]
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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
    }

    public void AddHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
