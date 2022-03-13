using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUps : MonoBehaviour
{
    public bool isPistolAmmo, isShotgunAmmo, isMachineGunAmmo, isCollected;
    public SpriteRenderer theSR;
    public Sprite pistolAmmo, shotgunAmmo, machineGunAmmo;

    void Awake()
    {
        theSR = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        if (isPistolAmmo)
        {
            theSR.sprite = pistolAmmo;
        }
        else if (isShotgunAmmo)
        {
            theSR.sprite = shotgunAmmo;
        }
        else if (isMachineGunAmmo)
        {
            theSR.sprite = machineGunAmmo;
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            if (isPistolAmmo)
            {
                WeaponManager.instance.UpdatePistolAmmo();
                isCollected = true;
                Destroy(gameObject);
            }

            if (isMachineGunAmmo)
            {
                WeaponManager.instance.UpdateMachineAmmo();
                isCollected = true;
                Destroy(gameObject);
            }

            if (isShotgunAmmo)
            {
                WeaponManager.instance.UpdateShotgunAmmo();
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }
}
