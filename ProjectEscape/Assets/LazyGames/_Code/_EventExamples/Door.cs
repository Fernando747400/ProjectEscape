using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector3 targetPosition;

    private void Start() {
        
        if(GameManager.current!= null)
        {
            GameManager.current.OpenShipDoor += Open;
            GameManager.current.OpenSecondDoor += Open;
            Debug.Log("Se susbcribe puerta " + this.gameObject.name);

        }
    }
    private void OnEnable()
    {
        // GameManager.current.OpenShipDoor += Open;
    }

    private void OnDisable()
    {
        if(GameManager.current!=null)
        {
            GameManager.current.OpenShipDoor -= Open;
            GameManager.current.OpenSecondDoor -= Open;

        }
    }

    public void Open()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position",targetPosition, "time",5));
        FindObjectOfType<AudioManager>().Play("Door_Open");
    }
}
