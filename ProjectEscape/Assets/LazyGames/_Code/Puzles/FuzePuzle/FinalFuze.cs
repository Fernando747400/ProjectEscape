using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFuze : MonoBehaviour, IUsable
{
    public GameObject[] Fuzes;
    public int cameraPlaceArray = 1;


    void Start()
    {

       
    }
    void Update()
    {
       Fuzes = GameObject.FindGameObjectsWithTag("Fuzes");
    }


    public void CheckPuzzleState()
    {
        if (Fuzes.Length == 3)
        { 
            PlayerController.current.DeactivateInteracting();
            CameraHandler.current.SelectCamera(cameraPlaceArray);
            PlayerController.current.SetPlayerInCinematic();
            StartCoroutine(WaitOpenDoor());

        }
    }

    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(1);
        GameManager.current.openSecondDooor();
        yield return new WaitForSeconds(5);
        CameraHandler.current.SwitchToPlayerCamera();
        PlayerController.current.UnSetPlayerCinematic();


    }
    
    public bool CanInteract
    {
        get;
        set;
    }
    public void Use()
    {

        if (GameManager.current != null)
        {
            Debug.Log("<color =#FFC733> Se suscribe el evento </color>");
            GameManager.current.activateInteracting();

        }
       
        CheckPuzzleState();
    }



}
