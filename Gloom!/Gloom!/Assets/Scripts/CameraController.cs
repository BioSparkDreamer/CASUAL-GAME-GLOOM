using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [Header("Move Variables")]
    public Transform moveTarget;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    void LateUpdate()
    {
        transform.position = moveTarget.position;
        transform.rotation = moveTarget.rotation;
    }
}
