using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.current.StartTutorial += Open;
    }

    private void OnDisable()
    {
        GameManager.current.StartTutorial -= Open;
    }

    void Open()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position",new Vector3(2,4,0), "time",5));
    }
}
