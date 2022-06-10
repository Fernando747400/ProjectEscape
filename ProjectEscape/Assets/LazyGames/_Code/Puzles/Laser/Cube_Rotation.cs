using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Rotation : MonoBehaviour
{
    public float Speed = 5;
    public float yRotation = 4;
    public bool isRotate = false;

    public GameObject Laser;

    public bool End = false;

    private void Start()
    {
        isRotate = false;
        End = false;
    }

    public void FixedUpdate()
    {
        if(isRotate == true)
        {
            float time = Time.deltaTime * Speed;
            Laser.transform.Rotate(0, yRotation * time, 0, Space.Self);
        }
        if(Laser.transform.eulerAngles.y <= 0.5f && Laser.transform.eulerAngles.y >= -0.5f)
        {
            End = true;
            //Debug.Log("EndThree");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isRotate = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isRotate = false;
    }
}
