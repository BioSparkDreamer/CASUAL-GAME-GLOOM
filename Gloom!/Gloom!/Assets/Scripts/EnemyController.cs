using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Object Variables")]
    public Rigidbody2D theRB;

    [Header("Chase and Move Variables")]
    private Vector3 playerDirection;
    public float playerRange = 10f;
    public bool shouldChase;
    public float moveSpeed;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
            theRB.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

    }
}
