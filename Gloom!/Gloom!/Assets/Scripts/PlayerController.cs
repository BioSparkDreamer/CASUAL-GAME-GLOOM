using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Object Variables")]
    [SerializeField] private Rigidbody2D theRB;
    [SerializeField] private Animator anim;
    [SerializeField] private Camera theCam;

    [Header("Movement Variables")]
    public float moveSpeed = 5f;
    public Transform camTransform;
    private Vector2 moveInput, mouseInput;
    private Vector3 moveHorizontal, moveVertical, rotationAmount;
    private float maxAngle = 150, minAngle = 20;

    [Header("Option Variables")]
    public float mouseSensitivity = 1;
    public bool invertX, invertY;

    [Header("Shooting Variables")]
    public GameObject bulletEffect;

    [Header("Gun Variables")]
    public Gun activeGun;
    public List<Gun> allGuns = new List<Gun>();
    public List<Gun> unlockableGuns = new List<Gun>();
    public int currentGun;

    void Awake()
    {
        //Setting the instance to this if it's null
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //Get Components
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCam = Camera.main;

        //Activate the gun but minus 1 from list we will be adding 1 to the list of guns
        currentGun--;
        SwitchGun();
    }

    void Update()
    {
        if (!GameOverMenu.instance.isDead && !PauseMenu.instance.isPaused && !GameManager.instance.levelEnding)
        {
            //Call function for doing movement
            Movement();

            //Call function for doing mouse and camera movement
            MouseMovement();

            //Call function for collecting inputs for switching weapon
            SwitchingWeapons();

            //Call function for doing shooting
            Shooting();

            //Call function for doing animations
            Animations();
        }
    }

    void FixedUpdate()
    {
        //Moving the Velocity of the Player based on bools
        if (!GameOverMenu.instance.isDead && !PauseMenu.instance.isPaused && !GameManager.instance.levelEnding)
        {
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        }
        else
        {
            theRB.velocity = Vector3.zero;
        }
    }

    void Movement()
    {
        //Get input for player moving on the x and y axis
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Use Vector3 variables to be able to move the player baed on input
        moveHorizontal = transform.up * -moveInput.x;
        moveVertical = transform.right * moveInput.y;
    }

    void MouseMovement()
    {
        //Get Mouse Input for Rotating the Camera
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //Bools for Inverting the Camera
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }

        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }

        //Code for rotating the player
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        transform.rotation.eulerAngles.y,
        transform.rotation.eulerAngles.z - mouseInput.x);

        //Code for rotating the camera using a transform on the player
        rotationAmount = camTransform.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);

        //Code for clamping the camera so it doesn't glitch during gameplay
        camTransform.transform.localRotation = Quaternion.Euler(rotationAmount.x, Mathf.Clamp(rotationAmount.y, minAngle, maxAngle),
        rotationAmount.z);
    }

    void SwitchingWeapons()
    {
        if (Input.GetButtonDown("Switch"))
        {
            SwitchGun();
        }
    }

    void Shooting()
    {
        if ((Input.GetButton("Shoot") || Input.GetAxis("ShootingTrigger") > 0.5) && activeGun.fireCounter <= 0)
        {
            if (activeGun.currentAmmo > 0)
            {
                Ray ray = theCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletEffect, hit.point + transform.right * (-moveSpeed * Time.deltaTime), Quaternion.identity);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyHealthController>().TakeDamage(activeGun.damageAmount);
                    }
                }
                else
                {
                    Debug.Log("I am not looking at anything");
                }

                activeGun.anim.SetTrigger("Shoot");
                activeGun.currentAmmo--;
                activeGun.fireCounter = activeGun.fireRate;

                AudioManager.instance.PlaySFXAdjusted(3);
                UIController.instance.UpdateAmmoUI();
            }
        }
    }

    public void SwitchGun()
    {
        //Deactive current gun
        activeGun.gameObject.SetActive(false);

        //Activate the next gun
        currentGun++;

        //If the number of the current gun gets bigger than the list total then reset back to 0
        if (currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        //Switch current active gun and set it to true
        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
        UIController.instance.UpdateAmmoUI();
    }

    public void AddGun(string gunToAdd)
    {
        //Create a bool to check if gun is unlocked
        bool gunIsUnlocked = false;

        if (unlockableGuns.Count > 0)
        {
            for (int i = 0; i < unlockableGuns.Count; i++)
            {
                if (unlockableGuns[i].gunName == gunToAdd)
                {
                    gunIsUnlocked = true;
                    allGuns.Add(unlockableGuns[i]);

                    unlockableGuns.RemoveAt(i);
                    i = unlockableGuns.Count;
                }
            }
        }

        //If we collect gun then switch to the gun
        if (gunIsUnlocked)
        {
            currentGun = allGuns.Count - 2;
            SwitchGun();
        }
    }

    public void Animations()
    {
        //Make Player Bob up and down if moving
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
