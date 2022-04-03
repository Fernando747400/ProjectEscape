using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerController playerController;

    public void switchCamera(Camera puzzleCamera)
    {
        mainCamera.gameObject.SetActive(false);
        puzzleCamera.gameObject.SetActive(true);
        playerController.ActivateInteracting();
        playerController.HandlePlayerStates();
    }

    public void switchToMainCamera()
    {
        Camera.main.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
