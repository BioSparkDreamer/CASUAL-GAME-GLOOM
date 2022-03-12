using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUps : MonoBehaviour
{
    public bool isPistolAmmo, isShotgunAmmo, isMachineGunAmmo;

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

        }
    }
}
