using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [Header("Object Variables")]
    public SpriteRenderer theSR;
    private Vector3 targetPoint;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;
    }

    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.z = transform.position.z;

        transform.LookAt(targetPoint, -Vector3.forward);
    }
}
