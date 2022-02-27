using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Object Variables")]
    public Rigidbody2D theRB;
    public SpriteRenderer theSR;

    [Header("Chase and Move Variables")]
    private Vector3 playerDirection;
    public float playerRange = 10f;
    public bool shouldChase;
    public float moveSpeed;

    [Header("Shooting Variables")]
    public float fireRate = .5f;
    private float shotCounter;
    public bool shouldShoot;
    public GameObject bullet;
    public Transform firePoint;

    [Header("Changing Sprite Variables")]
    public Color hurtColor;
    private Color defaultColor;
    public float timeBetweenColor;
    [HideInInspector] public float colorCounter;

    void Start()
    {
        defaultColor = theSR.color;
    }

    void Update()
    {
        if (colorCounter > 0)
        {
            theSR.color = hurtColor;
            colorCounter -= Time.deltaTime;
        }
        else
        {
            theSR.color = defaultColor;
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
            theRB.velocity = playerDirection.normalized * moveSpeed;

            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }

        else
        {
            theRB.velocity = Vector2.zero;
        }
    }
}
