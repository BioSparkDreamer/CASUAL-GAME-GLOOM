using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Object Variables")]
    public Animator anim;
    public Image gunImage;

    [Header("Gun Variables")]
    public string gunName;
    public int damageAmount;
    public bool isPistol, isShotgun, isMachineGun;

    [Header("Shooting Variables")]
    public float fireRate;
    [HideInInspector] public float fireCounter;

    [Header("Ammo Variables")]
    public int currentAmmo;
    public int pickUpAmount;

    void Start()
    {
        //Get Components
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }
}
