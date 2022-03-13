using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    public Gun pistolGun, shotgun, machineGun;

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

    void Update()
    {

    }

    public void UpdatePistolAmmo()
    {
        if (pistolGun.isPistol)
        {
            pistolGun.currentAmmo += pistolGun.pickUpAmount;
            UIController.instance.ShowPickUpStatus(pistolGun.pickUpAmount, "Pistol");
            UIController.instance.UpdateAmmoUI();
        }
    }

    public void UpdateMachineAmmo()
    {
        if (machineGun.isMachineGun)
        {
            machineGun.currentAmmo += machineGun.pickUpAmount;
            UIController.instance.ShowPickUpStatus(machineGun.pickUpAmount, "MachineGun");
            UIController.instance.UpdateAmmoUI();
        }
    }

    public void UpdateShotgunAmmo()
    {
        if (shotgun.isShotgun)
        {
            shotgun.currentAmmo += shotgun.pickUpAmount;
            UIController.instance.ShowPickUpStatus(shotgun.pickUpAmount, "Shotgun");
            UIController.instance.UpdateAmmoUI();
        }

    }
}
