using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStates _playerStates;
    public PlayerStates PlayerState
    {
        get{ return _playerStates;}
        set { _playerStates = value;}
    }
    
    void Start()
    {
        SetPlayer();   
    }
    void Update()
    {
        
    }
    private void FixedUpdate() {
        MovementPlayer();
    }

    void SetPlayer()
    {

    }   

    private void MovementPlayer()
    {

    }
    public enum PlayerStates
    {
        NoInteracting = 0,
        Interacting = 1,
    
    }
}
