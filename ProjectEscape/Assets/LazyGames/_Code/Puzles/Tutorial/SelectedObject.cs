using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private BoxCollider PuzzleColliderBox;
    [SerializeField] private LeanDragTranslate[] myLeanDrags;

    private LeanDragTranslate lean;
    private void Start()
    {
        LeanTouch.OnFingerDown += GetViewInfoTouch;
        LeanTouch.OnFingerUp += TurnOffLeans;
       

        for (int i = 0; i < myLeanDrags.Length; i++)
        {
            myLeanDrags[i].enabled = false;
        }
    }

    private void Update()
    {
        if (PlayerController.current.GetPlayerState(PlayerStates.Interacting))
        {
            PuzzleColliderBox.enabled = false;
        }
        else
        {
            PuzzleColliderBox.enabled = true;
        }
    }

    void TurnOffLeans(LeanFinger finger)
    {
        if (finger.Up)
        {
            for (int i = 0; i < myLeanDrags.Length; i++)
            {
                myLeanDrags[i].enabled = false;
            }
        }
       
    }
    
    void GetViewInfoTouch(LeanFinger finger)
    {
        RaycastHit hit;
        Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
        // Debug.Log(coordinate);
        Ray myRay = myCamera.ScreenPointToRay(coordinate);
        if (Physics.Raycast(myRay, out hit, 25f))
        {
            if (finger.Down)
            {
                LeanDragTranslate _lean = hit.transform.GetComponent<LeanDragTranslate>();
                if (_lean != null)
                {
                    _lean.enabled = true;
                }   
            }
        }

    }

    
}
