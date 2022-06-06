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
        //xvalue = this.transform.rotation.eulerAngles.x;
        if(xvalue == 90)
        {
            xvalue = Palanca.transform.localEulerAngles.x;
        }
        if(xvalue != 90)
        {
            xvalue = minRotate;
            LeanR.enabled = false;
        }
        pitch = Mathf.Clamp(xvalue, minRotate, maxRotate);

        transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    }
}
