using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePotion : MonoBehaviour, IUsable
{
    public bool CanInteract
    {
        get;
        set;
    }

    public void Use()
    {
        GameManager.current.activateInteracting();
    }
}
