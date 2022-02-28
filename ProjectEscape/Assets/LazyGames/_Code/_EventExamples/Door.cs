using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.current.StartTutorial += Open;
    }

    void Open()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(new Vector3(5,5,5), "time",5));
    }
}
