using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFuze : MonoBehaviour, IUsable
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

    public bool CanInteract
    {
        get;
        set;
    }
    public void Use()
    {
       // CameraHandler.current.SelectCamera(2);
        GameManager.current.activateInteracting();
    }



}
