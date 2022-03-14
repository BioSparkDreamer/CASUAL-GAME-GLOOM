using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public bool isBlueKey, isRedKey, isYellowKey, isCollected;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isBlueKey && !isCollected)
        {
            UIController.instance.UpdateBlueKey();
            AudioManager.instance.PlaySFX(9);
            isCollected = true;
            Destroy(gameObject);
        }

        if (other.tag == "Player" && isYellowKey && !isCollected)
        {
            UIController.instance.UpdateYellowKey();
            AudioManager.instance.PlaySFX(9);
            isCollected = true;
            Destroy(gameObject);
        }

        if (other.tag == "Player" && isRedKey && !isCollected)
        {
            UIController.instance.UpdateRedKey();
            AudioManager.instance.PlaySFX(9);
            isCollected = true;
            Destroy(gameObject);
        }
    }
}
