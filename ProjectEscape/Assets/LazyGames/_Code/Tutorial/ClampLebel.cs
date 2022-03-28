using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class ClampLebel : MonoBehaviour
{
    float pitch;
    public float xvalue;
    public GameObject Palanca;
    private LeanTwistRotateAxis LeanR;
    public int maxRotate, minRotate;

    private void Start()
    {
        LeanR = this.GetComponent<LeanTwistRotateAxis>();
    }

    void Update()
    {
        
        if(xvalue == maxRotate)
        {
            xvalue += Palanca.transform.rotation.x;
        }
        if(xvalue != 0)
        {
            xvalue = minRotate;
            LeanR.enabled = false;
        }
        pitch = Mathf.Clamp(xvalue, minRotate, maxRotate);

        transform.eulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    }
}
