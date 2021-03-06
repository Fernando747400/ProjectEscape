using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    public Transform startPoint;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
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
            }
        }
        else lr.SetPosition(1, -transform.right * 5000);
    }
}
