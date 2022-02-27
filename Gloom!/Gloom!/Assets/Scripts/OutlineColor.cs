using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OutlineColor : MonoBehaviour
{
    public Outline outlineColor;

    public void OnSelect()
    {
        outlineColor.effectColor = Color.white;
    }

    public void OnDeselect()
    {
        outlineColor.effectColor = Color.black;
    }
    public void OnPointerEnter()
    {
        outlineColor.effectColor = Color.white;
    }
    public void OnPointerExit()
    {
        outlineColor.effectColor = Color.black;
    }
}
