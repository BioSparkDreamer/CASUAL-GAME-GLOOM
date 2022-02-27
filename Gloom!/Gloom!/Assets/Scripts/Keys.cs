using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [Header("Key Variables")]
    public bool isBlueKey;
    public GameObject blueKey;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isBlueKey)
        {
            UIController.instance.UpdateBlueKey();
            Destroy(blueKey);
        }
    }
}
