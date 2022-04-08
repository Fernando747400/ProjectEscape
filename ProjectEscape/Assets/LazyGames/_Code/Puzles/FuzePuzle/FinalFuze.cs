using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFuze : MonoBehaviour
{
    public GameObject[] Fuzes;

    void Update()
    {
        Fuzes = GameObject.FindGameObjectsWithTag("Fuzes");

        if (Fuzes.Length == 4)
        {
            Debug.Log("Fin del juego");
        }
    }
}
