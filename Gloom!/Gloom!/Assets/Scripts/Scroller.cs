using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage theImage;
    [SerializeField] private float imageX, imageY;

    void Update()
    {
        theImage.uvRect = new Rect(theImage.uvRect.position + new Vector2(imageX, imageY) * Time.deltaTime, theImage.uvRect.size);
    }
}
