using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [Header("Door Variables")]
    public Transform doorModel;
    public GameObject colliderObject, tileObject;
    public float openSpeed;
    public bool shouldOpen;
    public bool requiresKey;
    public bool isBlueDoor, isYellowDoor, isRedDoor;

    void Start()
    {
        tileObject.SetActive(false);
    }

    void Update()
    {
        if (isBlueDoor)
        {
            if (requiresKey && UIController.instance.hasBlueKey)
            {
                if (shouldOpen && doorModel.position.z != 1f)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 1f)
                    {
                        colliderObject.SetActive(false);

                        if (UIController.instance.currentObjective == 3)
                        {
                            UIController.instance.currentObjective--;
                        }
                    }
                }
                else if (!shouldOpen && doorModel.position.z != 0)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 0f)
                    {
                        colliderObject.SetActive(true);
                    }
                }
            }
        }

        if (isYellowDoor)
        {
            if (requiresKey && UIController.instance.hasYellowKey)
            {
                if (shouldOpen && doorModel.position.z != 1f)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 1f)
                    {
                        colliderObject.SetActive(false);

                        if (UIController.instance.currentObjective == 2)
                        {
                            UIController.instance.currentObjective--;
                        }
                    }
                }
                else if (!shouldOpen && doorModel.position.z != 0)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 0f)
                    {
                        colliderObject.SetActive(true);
                    }
                }
            }
        }

        if (isRedDoor)
        {
            if (requiresKey && UIController.instance.hasRedKey)
            {
                if (shouldOpen && doorModel.position.z != 1f)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 1f)
                    {
                        colliderObject.SetActive(false);

                        if (UIController.instance.currentObjective == 1)
                        {
                            UIController.instance.currentObjective--;
                        }
                    }
                }
                else if (!shouldOpen && doorModel.position.z != 0)
                {
                    doorModel.position = Vector3.MoveTowards(doorModel.position,
                    new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

                    if (doorModel.position.z == 0f)
                    {
                        colliderObject.SetActive(true);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
