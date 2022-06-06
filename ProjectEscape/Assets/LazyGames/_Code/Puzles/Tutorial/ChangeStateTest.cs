using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateTest : MonoBehaviour, IUsable
{

    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        Debug.Log("Call setPlayerState desde card console");
        GameManager.current.setPlayerState();
        GameManager.current.activateInteracting();
    }
}
