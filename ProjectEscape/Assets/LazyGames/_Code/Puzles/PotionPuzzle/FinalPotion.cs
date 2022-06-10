using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPotion : MonoBehaviour
{
    public Material ColorOne;
    public Material ColorTwo;
    public Material ColorWin;
    public Material Indicador;

    public GameObject Matraz;

    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        ColorOne.color = Color.black;
        ColorTwo.color = Color.black;
        Matraz.GetComponent<Fuze>().enabled = false;
    }

    void Update()
    {
        if (ColorOne.color != Color.black && ColorTwo.color != Color.black)
        {
            this.gameObject.GetComponent<Renderer>().material.color = ColorOne.color + ColorTwo.color;
        }

        if(this.gameObject.GetComponent<Renderer>().material.color == ColorWin.color)
        {
            Indicador.color = Color.green;
            Matraz.GetComponent<Fuze>().enabled = true;
        }
        if (this.gameObject.GetComponent<Renderer>().material.color != ColorWin.color)
        {
            Indicador.color = Color.red;
        }
    }
}
