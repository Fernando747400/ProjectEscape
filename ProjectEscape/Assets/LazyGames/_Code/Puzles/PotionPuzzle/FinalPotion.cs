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

    public string chemSound;
    public string stinger;

    private bool solved = false;

    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        ColorOne.color = Color.black;
        ColorTwo.color = Color.black;
        Matraz.GetComponent<Fuze>().enabled = false;
        solved = false;
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
            

                if (!solved)
                {
                    if (chemSound != null || chemSound != "") PlaySound(chemSound);
                     if (stinger != null || stinger != "") PlaySound(stinger);
                solved = true;
                }
        }
        if (this.gameObject.GetComponent<Renderer>().material.color != ColorWin.color)
        {
            Indicador.color = Color.red;
            solved = false;
        }
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }
}
