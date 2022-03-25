using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject inputsUI;
    
    [Header("Camera")]
    [SerializeField] Transform transformCamera;
    [Range(1f,40f)]
    [SerializeField] float sensitivityX = 20f;
    [Range(0f,5f)]
    [SerializeField] float sensitivityY= 0.5f;
    
    private CharacterController myCharacterController;
    
    // Camera and Player Movement
    float cameraLimit = 85f;
    float xRotation = 0;
    float uiCamX, uiCamY;
    
    private Keyboard keyboard;
    private Mouse mouse;

    private Vector2 myVector2Move;
    private Vector2 myVector2Cam;
    private Vector2 myVector2Keyboard;

    
    [SerializeField] private bool changeMouse = false;
    [SerializeField] private bool isInteracting = false;
    
    public PlayerStates _playerStates;
    public PlayerStates PlayerState
    {
        get{ return _playerStates;}
        set { _playerStates = value;}
    }
    
    void Start()
    {
        SetPlayer();   
    }
    private void FixedUpdate()
    {
        MovementPlayer();
        MovementCamera();
        
        
    }

    void SetPlayer()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
        mouse = Mouse.current;
#endif
        myCharacterController = gameObject.GetComponent<CharacterController>();
        GameManager.current.SetPlayerState += HandlePlayerStates;
    }

    public void ReceiveInputsPlayer(Vector2 _vectorMove, Vector2 _vectorCam, Vector2 _vectorkeyboard)
    {
        myVector2Keyboard = _vectorkeyboard;
        myVector2Move = _vectorMove;
        myVector2Cam = _vectorCam;
        
        uiCamX = myVector2Cam.x * sensitivityX;
        uiCamY = myVector2Cam.y * sensitivityY;
    }
    private void MovementPlayer()
    {
        //UI Input
        Vector3 horizontalVelocity = (transform.right * myVector2Move.x + transform.forward * myVector2Move.y) * moveSpeed;
        
        //Keyboard Input
        if (keyboard != null)
        {
            if (keyboard.anyKey.isPressed)
            {
               horizontalVelocity = (transform.right * myVector2Keyboard.x + transform.forward * myVector2Keyboard.y) * moveSpeed;
            }
        }
            
        myCharacterController.Move(horizontalVelocity * Time.deltaTime);
    }

    private void MovementCamera()
    {
        Vector2 mouseVector2 = mouse.delta.ReadValue();
        
        float mouseY = 0;
        float mouseX = 0;
        
        mouseY = mouseVector2.y * sensitivityY;
        mouseX = mouseVector2.x * sensitivityX;
        
  
        if (changeMouse)
        {
            transform.Rotate(Vector3.up,mouseX * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            transformCamera.eulerAngles = targetRotation;
        }
        else
        {
            transform.Rotate(Vector3.up,uiCamX * Time.deltaTime);
            xRotation -= uiCamY;
            xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            transformCamera.eulerAngles = targetRotation;
        }
        
    }

    public void HandlePlayerStates()
    {
        isInteracting = !isInteracting;

        if (isInteracting)
        {
            PlayerState = PlayerStates.Interacting;
            inputsUI.gameObject.SetActive(false);

        }
        else
        {
            PlayerState = PlayerStates.NoInteracting;
            inputsUI.gameObject.SetActive(true);
        }
    }

     //void OnEnable()
    //{
      //  GameManager.current.SetPlayerState += HandlePlayerStates;
    //}

    private void OnDisable()
    {
        GameManager.current.SetPlayerState -= HandlePlayerStates;
    }


}


public enum PlayerStates
    {
        NoInteracting = 0,
        Interacting = 1,
    
    }

