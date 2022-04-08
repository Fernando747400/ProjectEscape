using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuze : InteractableObjects, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        this.gameObject.SetActive(false);
    }
}
