using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour
{
    public CanvasGroup theHud;
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
            GameManager.instance.EndLevel();
            PlayerController.instance.activeGun.gunImage.enabled = false;
            theHud.alpha = 0;
        }
    }
}
