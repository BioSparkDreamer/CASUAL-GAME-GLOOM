using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [Header("Health Variables")]
    public int health = 3;
    private EnemyController enemy;
    public GameObject deathEffect;

    public GameObject blueKey, redKey, shotGun, machineGun;
    public Transform keyPoint;
    public bool dropShotgun, dropMachineGun, dropBlueKey, dropRedKey;

    void Start()
    {
        enemy = GetComponent<EnemyController>();
    }

    void Update()
    {

    }

    public void TakeDamage(int damageToDeal)
    {
        health -= damageToDeal;
        enemy.colorCounter = enemy.timeBetweenColor;

        if (health <= 0)
        {
            health = 0;
            AudioManager.instance.PlaySFXAdjusted(1);

            if (dropBlueKey)
            {
                if (blueKey != null && !UIController.instance.hasBlueKey)
                {
                    Instantiate(blueKey, keyPoint.position, keyPoint.rotation);
                }
            }

            if (dropRedKey)
            {
                if (redKey != null && !UIController.instance.hasRedKey)
                {
                    Instantiate(redKey, keyPoint.position, keyPoint.rotation);
                }
            }

            if (dropShotgun)
            {
                if (shotGun != null)
                {
                    Instantiate(shotGun, keyPoint.position, keyPoint.rotation);
                }
            }

            if (dropMachineGun)
            {
                if (machineGun != null)
                {
                    Instantiate(machineGun, keyPoint.position, keyPoint.rotation);
                }
            }

            Instantiate(deathEffect, transform.position + new Vector3(0f, 0f, -0.6f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
