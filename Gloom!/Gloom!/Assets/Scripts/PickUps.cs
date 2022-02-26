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
                Destroy(gameObject);
            }

            if (isHealth && PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.AddHealth(healthAmount);
                UIController.instance.UpdateHealthUI();
                Destroy(gameObject);
            }
        }
    }
}
