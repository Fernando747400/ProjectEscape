using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject placedCamera;

    Vector3 originalPosCamera;


    public void TransformCameraToPlace(Camera mainCamera)
    {
        originalPosCamera = mainCamera.transform.position;

        mainCamera.transform.position = placedCamera.transform.position;
        mainCamera.transform.rotation = placedCamera.transform.rotation;
    }

}
