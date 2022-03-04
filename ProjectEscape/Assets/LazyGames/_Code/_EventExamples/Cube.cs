using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour,IUsable
{
    GameManager gameManager;

    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Use()
    {
        Debug.Log("Mouse enter");
        gameManager.startTutorial();
    }
}
