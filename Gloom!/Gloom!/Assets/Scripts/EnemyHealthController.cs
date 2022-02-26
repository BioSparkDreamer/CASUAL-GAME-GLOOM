using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [Header("Health Variables")]
    public int health = 3;
    public GameObject deathEffect;

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(int damageToDeal)
    {
        health -= damageToDeal;

        if (health <= 0)
        {
            health = 0;
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
