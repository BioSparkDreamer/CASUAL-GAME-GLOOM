using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Damage Variables")]
    public int damageAmount;

    [Header("Movement Variables")]
    public float moveSpeed = 5f;
    public Rigidbody2D theRB;
    private Vector3 playerDirection;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        playerDirection = PlayerController.instance.transform.position - transform.position;
        playerDirection.Normalize();
        playerDirection = playerDirection * moveSpeed;
    }

    void FixedUpdate()
    {
        theRB.velocity = playerDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
