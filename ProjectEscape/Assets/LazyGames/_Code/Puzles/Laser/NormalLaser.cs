using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLaser : MonoBehaviour
{
    public bool CreateRay = false;

    public GameObject Laser;

    private void Start()
    {
        CreateRay = false;
        Laser.GetComponent<Laser>().enabled = false;
        Laser.GetComponent<LineRenderer>().enabled = false;
    }

    public void FixedUpdate()
    {
        if (CreateRay == true)
        {
            Laser.GetComponent<Laser>().enabled = true;
            Laser.GetComponent<LineRenderer>().enabled = true;
        }
        if(CreateRay == false)
        {
            Laser.GetComponent<Laser>().enabled = false;
            Laser.GetComponent<LineRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CreateRay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        CreateRay = false;
    }
}
