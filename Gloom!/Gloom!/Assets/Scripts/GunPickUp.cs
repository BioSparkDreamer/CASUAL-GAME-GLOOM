using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    [Header("Pick Up Variables")]
    public string gunName;
    private bool isCollected;
    public string gunPickUpName;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            PlayerController.instance.AddGun(gunName);
            UIController.instance.ShowPickUpStatus(0, gunPickUpName);
            Destroy(gameObject);
            isCollected = true;
        }
    }
}
