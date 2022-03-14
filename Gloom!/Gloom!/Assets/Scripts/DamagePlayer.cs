using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageToDeal;
    public float timeToHit;
    private float hitCounter;

    void Start()
    {

    }

    void Update()
    {
        if (hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && hitCounter <= 0)
        {
            PlayerHealthController.instance.TakeDamage(damageToDeal);
            hitCounter = timeToHit;
        }
    }
}
