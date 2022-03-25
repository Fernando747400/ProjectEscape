using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] private Camera myCamera;

    private LeanDragTranslate lean;
    private void Start()
    {
        LeanTouch.OnFingerDown += GetViewInfoTouch;
        lean = this.GetComponent<LeanDragTranslate>();
        lean.enabled = false;
        // Debug.Log(lean.EnableTransform);
    }

    public void SetSelectable()
    {
        
    }


    void GetViewInfoTouch(LeanFinger finger)
    {
        RaycastHit hit;
        Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
        // Debug.Log(coordinate);
        Ray myRay = myCamera.ScreenPointToRay(coordinate);
        if (Physics.Raycast(myRay, out hit, 25f))
        {
            LeanDragTranslate _lean = hit.transform.GetComponent<LeanDragTranslate>();
            if (_lean != null)
            {
                _lean.enabled = true;
                
            }
            else if(_lean == null)
            {
                lean = this.GetComponent<LeanDragTranslate>();
                lean.enabled = false;
            }
        }

    }

}
