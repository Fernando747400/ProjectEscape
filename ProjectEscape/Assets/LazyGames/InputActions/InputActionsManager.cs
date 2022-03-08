using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionsManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private PlayerControls playerControls;
    private PlayerControls.PlayerActions playerActions;
    
    private Vector2 vectorMovInput;
    private Vector2 vectorCamInpt;
    void Awake()
    {
        playerControls = new PlayerControls();
        playerActions = playerControls.Player;

        playerActions.Move.performed += ctx => vectorMovInput = ctx.ReadValue<Vector2>();
        playerActions.Look.performed += ctx => vectorCamInpt = ctx.ReadValue<Vector2>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController.ReceiveInputsPlayer(vectorMovInput,vectorCamInpt);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDestroy()
    {
        playerControls.Disable();
    }
}
