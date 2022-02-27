using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [Header("Health Variables")]
    public int health = 3;
    private EnemyController enemy;

    [Header("Dropping Items")]
    public bool isPurpleGhost;
    public GameObject blueKey;
    public Transform keyPoint;

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

            if (isPurpleGhost)
            {
                if (blueKey != null && !UIController.instance.hasBlueKey)
                {
                    Instantiate(blueKey, keyPoint.position, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }
    }
}
