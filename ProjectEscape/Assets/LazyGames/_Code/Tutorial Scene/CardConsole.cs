using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardConsole : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
   
    public void Start()
    {
        GameManager.current.ShowCardConsole += show;
        // this.gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        GameManager.current.ShowCardConsole -= show;
    }
    private void show()
    {
        // this.gameObject.SetActive(true);
    }

    public void Use()
    {
        Debug.Log("Call setPlayerState desde card console");
        GameManager.current.setPlayerState();
        GameManager.current.activateInteracting();
    }
    
}
