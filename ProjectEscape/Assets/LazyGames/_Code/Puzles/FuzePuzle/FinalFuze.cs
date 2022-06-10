using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFuze : MonoBehaviour, IUsable
{
    public GameObject[] Fuzes;
    public int cameraPlaceArray = 3;
    private bool DontRepeat = false;
    public string StingerSound;
    public string ElecStart;
    public string Electricity;

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
            DontRepeat = true;
            if (StingerSound != null || StingerSound != "") PlaySound(StingerSound);
            if (ElecStart != null || ElecStart != "") PlaySound(ElecStart);
            if (Electricity != null || Electricity != "") PlaySound(Electricity);
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
            GameManager.current.activateInteracting();
        }
       
        //CheckPuzzleState();
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }



}
