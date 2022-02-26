using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [Header("Ammo Pickup Variables")]
    public int ammoAmmount = 25;
    public bool isAmmo;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isAmmo)
            {
                PlayerController.instance.currentAmmo += ammoAmmount;
                Destroy(gameObject);
            }
        }
    }
}
