using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Canvas canvas;
    public static CameraHandler current;
    public Camera playerCamera;

    public Camera[] camerasInScene;
    public PlayerController playerController;

    private void Awake() {
        current = this;
    }

     private void Start() {

         TurnOff();
    }
    private void SwitchCamera(Camera cameraToSwitch)
    {
        
        Camera.main.gameObject.SetActive(false);
        TurnOff();
        
        cameraToSwitch.gameObject.SetActive(true);
        
    }

    public void SwitchToPlayerCamera()
    {
        TurnOff();
        playerCamera.gameObject.SetActive(true);
    }


    public void SelectCamera(int placeInArray)
    {
        SwitchCamera(camerasInScene[placeInArray]);
    }

    void TurnOff()
    {
         for (int i = 0; i < camerasInScene.Length; i++)
        {
             camerasInScene[i].gameObject.SetActive(false);
        } 
    }
}
