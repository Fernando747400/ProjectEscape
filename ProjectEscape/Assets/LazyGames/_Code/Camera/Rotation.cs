using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    public float yAngle;
    public float xAngle;
    public float zAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(Mathf.Sin(Time.time) * xAngle, yAngle, zAngle) * Time.deltaTime * speed, Space.Self);
    }
}
