using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePuzzle : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        //GameManager.current.setPlayerState();
        GameManager.current.activateInteracting();
        Debug.Log("Usar");
    }
}
