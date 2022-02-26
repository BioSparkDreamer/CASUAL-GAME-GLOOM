using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Object Variables")]
    public Rigidbody2D theRB;
    public Camera camTrans;

    [Header("Movement Variables")]
    public float moveSpeed = 5f;
    private Vector2 moveInput, mouseInput;
    private Vector3 moveHorizontal, moveVertical, rotationAmount;
    public float mouseSensitivity = 1;
    private float maxAngle = 150, minAngle = 20;

    [Header("Shooting Variables")]
    public GameObject bulletEffect;
    public int currentAmmo;
    public int gunDamage;
    public float nextTimeToFire;
    private float nextTimeCounter;
    public Animator shotGunAnim;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!UIController.instance.isDead)
        {
            Movement();

            MouseMovement();

            CameraMovement();

            Shooting();
        }
    }

    void FixedUpdate()
    {
        if (!UIController.instance.isDead)
        {
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        }
    }

    void Movement()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveHorizontal = transform.up * -moveInput.x;
        moveVertical = transform.right * moveInput.y;
    }

    void MouseMovement()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        transform.rotation.eulerAngles.y,
        transform.rotation.eulerAngles.z - mouseInput.x);
    }

    void CameraMovement()
    {
        rotationAmount = camTrans.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);

        camTrans.transform.localRotation = Quaternion.Euler(rotationAmount.x, Mathf.Clamp(rotationAmount.y, minAngle, maxAngle),
        rotationAmount.z);
    }

    void Shooting()
    {
        if ((Input.GetButton("Shoot") || Input.GetAxis("ShootingTrigger") > 0.5) && nextTimeCounter <= 0)
        {
            if (currentAmmo > 0)
            {
                Ray ray = camTrans.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletEffect, hit.point, Quaternion.identity);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyHealthController>().TakeDamage(gunDamage);
                    }
                }
                else
                {
                    Debug.Log("I am not looking at anything");
                }

                nextTimeCounter = nextTimeToFire;
                shotGunAnim.SetTrigger("Shoot");
                currentAmmo--;
                UIController.instance.UpdateAmmoUI();
            }
        }

        if (nextTimeCounter > 0)
        {
            nextTimeCounter -= Time.deltaTime;
        }
    }
}
