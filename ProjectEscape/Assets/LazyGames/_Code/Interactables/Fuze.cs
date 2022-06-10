using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuze : InteractableObjects, IUsable
{
    public string sound;
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    public void Use()
    {
        if (sound != null || sound != "") PlaySound(sound);
        Debug.Log("Debería apagarse" + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }
}
