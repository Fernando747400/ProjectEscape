using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPotion : MonoBehaviour
{
    public Material ColorOne;
    public Material ColorTwo;

    private void Start()
    {
        ColorOne.color = Color.black;
        ColorTwo.color = Color.black;
    }

    public void SelectColor()
    {
        if(ColorOne.color == Color.black)
        {
            ColorOne.color = this.gameObject.GetComponent<Renderer>().material.color;
        }
        else if (ColorTwo.color == Color.black && ColorOne.color != Color.black)
        {
            ColorTwo.color = this.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}
