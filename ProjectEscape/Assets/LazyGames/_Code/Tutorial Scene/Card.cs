using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        GameManager.current.showCardConsole();
        //GameManager.current.setPlayerState();
        this.gameObject.SetActive(false);
    }
}
