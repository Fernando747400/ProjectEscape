using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPotion : MonoBehaviour
{
    public GameObject FinalPotion;
    public Material ColorOne;
    public Material ColorTwo;

    public void Retry()
    {
        ColorOne.color = Color.black;
        ColorTwo.color = Color.black;
        FinalPotion.GetComponent<Renderer>().material.color = Color.white;
    }
}
