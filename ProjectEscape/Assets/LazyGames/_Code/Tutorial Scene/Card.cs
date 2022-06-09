using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : InteractableObjects, IUsable
{
    
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        GameManager.current.showCardConsole();
        StartCoroutine(DelayTookObject());
    }

    IEnumerator DelayTookObject()
    {
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);

    }
    
}
