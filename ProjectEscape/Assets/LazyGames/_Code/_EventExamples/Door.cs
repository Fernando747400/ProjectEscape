using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector3 targetPosition;

    private void Start() {
        
        GameManager.current.OpenShipDoor += Open;
    }
    private void OnEnable()
    {
        // GameManager.current.OpenShipDoor += Open;
    }

    private void OnDisable()
    {
        GameManager.current.OpenShipDoor -= Open;
    }

    public void Open()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position",targetPosition, "time",5));
    }
}
