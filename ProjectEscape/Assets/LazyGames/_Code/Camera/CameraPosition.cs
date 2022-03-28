using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject placedCamera;
    
    private Camera playerCamera;
    Vector3 originalPosCamera;


    public void TransformCameraToPlace(Camera mainCamera)
    {
        playerCamera = Camera.main;

        originalPosCamera = playerCamera.transform.position;

        mainCamera.transform.position = new Vector3(0, 0, 0);
        mainCamera.transform.rotation = new Quaternion();
        mainCamera.transform.position = placedCamera.transform.position;
        mainCamera.transform.rotation = placedCamera.transform.rotation;
    }

    public void ReturnCameraToPlayer()
    {
        playerCamera.transform.position = originalPosCamera;
    }


}
