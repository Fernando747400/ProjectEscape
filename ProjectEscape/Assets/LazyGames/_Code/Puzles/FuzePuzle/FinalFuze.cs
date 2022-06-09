using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFuze : MonoBehaviour, IUsable
{
    public GameObject[] Fuzes;
    public int cameraPlaceArray = 3;
    private bool DontRepeat = false;

    void Start()
    {
        DontRepeat = false;
    }
    void Update()
    {
       Fuzes = GameObject.FindGameObjectsWithTag("Fuzes");

        CheckPuzzleState();
    }


    public void CheckPuzzleState()
    {
        if (Fuzes.Length == 4 && DontRepeat == false)
        { 
          StartCoroutine(WaitOpenDoor());
        }
    }

    IEnumerator WaitOpenDoor()
    {
        PlayerController.current.DeactivateInteracting();
        CameraHandler.current.SelectCamera(cameraPlaceArray);
        PlayerController.current.SetPlayerInCinematic();
        yield return new WaitForSeconds(1);
        GameManager.current.openSecondDooor();
        yield return new WaitForSeconds(5);
        CameraHandler.current.SwitchToPlayerCamera();
        PlayerController.current.UnSetPlayerCinematic();

        DontRepeat = true;
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
