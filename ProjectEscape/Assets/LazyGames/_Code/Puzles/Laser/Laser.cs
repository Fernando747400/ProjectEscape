using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    public Transform startPoint;

    public bool End = false;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        End = false;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if(hit.collider)
            {
                lr.SetPosition(1, hit.point);
                if(hit.collider.tag == "EndGame")
                {
                    End = true;
                    //Debug.Log("FinalOne");
                }
                else
                {
                    End = false;
                }
            }
        }
        else lr.SetPosition(1, -transform.right * 5000);
    }
}
