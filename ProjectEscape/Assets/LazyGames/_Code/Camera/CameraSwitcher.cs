using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour, IUsable
{
    [SerializeField] CameraHandler cameraHandler;
    [SerializeField] Camera puzzleCamera;

    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        cameraHandler.switchCamera(puzzleCamera);
    }
}
