using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    
    [Header("Camera")]
    [SerializeField] Transform transformCamera;
    [Range(1f,40f)]
    [SerializeField] float sensitivityX = 20f;
    [Range(0f,5f)]
    [SerializeField] float sensitivityY= 0.5f;
    
    private CharacterController myCharacterController;
    
    float cameraLimit = 85f;
    float xRotation = 0;
    float mouseX, mouseY;

    private Vector2 myVector2Move;
    private Vector2 myVector2Cam;
    
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
    private void FixedUpdate()
    {
        MovementPlayer();
        MovementCamera();
    }

    void SetPlayer()
    {
        myCharacterController = gameObject.GetComponent<CharacterController>();
    }

    public void ReceiveInputsPlayer(Vector2 _vectorMove, Vector2 _vectorCam)
    {
        myVector2Move = _vectorMove;
        myVector2Cam = _vectorCam;
        
        mouseX = myVector2Cam.x * sensitivityX;
        mouseY = myVector2Cam.y * sensitivityY;
    }
    private void MovementPlayer()
    {
        Vector3 horizontalVelocity = (transform.right * myVector2Move.x + transform.forward * myVector2Move.y) * moveSpeed;
        myCharacterController.Move(horizontalVelocity * Time.deltaTime);
    }

    private void MovementCamera()
    {
       transform.Rotate(Vector3.up,mouseX * Time.deltaTime);
       xRotation -= mouseY;
       xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

       Vector3 targetRotation = transform.eulerAngles;
       targetRotation.x = xRotation;
       transformCamera.eulerAngles = targetRotation;
       
    }
    public enum PlayerStates
    {
        NoInteracting = 0,
        Interacting = 1,
    
    }
}
