using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current;
    
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject inputsUI;
    
    [Header("Camera")]
    [SerializeField] Transform transformCamera;
    [Range(1f,40f)]
    [SerializeField] float sensitivityX = 20f;
    [Range(0f,5f)]
    [SerializeField] float sensitivityY= 0.5f;

    [Header("UI")] 
    [SerializeField] private GameObject returnButton;
    
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

    private Vector3 originalCameraPos;
    private Camera mainCamera;
    
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
        current = this;
        //DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 30;
        SetPlayer();   
        StartCoroutine(corAudioCooldown());
    }
    private void FixedUpdate()
    {
        MovementPlayer();
        MovementCamera();
        corAudioCooldown();
        
    }

    void SetPlayer()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
        mouse = Mouse.current;
#endif
        mainCamera = Camera.main;
        myCharacterController = gameObject.GetComponent<CharacterController>();

        returnButton = GameObject.Find("ReturnButton");
        inputsUI = GameObject.Find("InputUI");

        if (GameManager.current != null)
        {
            Debug.Log("<color=#FFC733> EXISTE GameManager en Scene? </color>" + GameManager.current);

            GameManager.current.SetPlayerState += HandlePlayerStates;
            GameManager.current.ActivateInteracting += ActivateInteracting;



        }


        HandlePlayerStates();
        
        


       
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
        if (PlayerState == PlayerStates.NoInteracting)
        {
            if (keyboard != null)
            {
                if (keyboard.anyKey.isPressed)
                {
                    horizontalVelocity = (transform.right * myVector2Keyboard.x + transform.forward * myVector2Keyboard.y) * moveSpeed;
                }
            }
        }
        
        myCharacterController.Move(horizontalVelocity * Time.deltaTime);
    }

    private void MovementCamera()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
       
        if (changeMouse)
        {
            if (mouse.enabled)
            {
                Vector2 mouseVector2 = mouse.delta.ReadValue();
        
                float mouseY = 0;
                float mouseX = 0;
        
                mouseY = mouseVector2.y * sensitivityY;
                mouseX = mouseVector2.x * sensitivityX;

                if (PlayerState == PlayerStates.NoInteracting)
                {
                    transform.Rotate(Vector3.up,mouseX * Time.deltaTime);
                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

                    Vector3 targetRotationMouse = transform.eulerAngles;
                    targetRotationMouse.x = xRotation;
                    transformCamera.eulerAngles = targetRotationMouse;
                }
          
            }
        }
       
#endif
       
            transform.Rotate(Vector3.up,uiCamX * Time.deltaTime);
            xRotation -= uiCamY;
            xRotation = Mathf.Clamp(xRotation, -cameraLimit, cameraLimit);

            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            transformCamera.eulerAngles = targetRotation;
       
        
    }

    public void HandlePlayerStates()
    {
        if (isInteracting)
        {
            PlayerState = PlayerStates.Interacting;
           

            if(returnButton != null)
            {
                returnButton.SetActive(true);

            }

            if(returnButton != null)
            {
                inputsUI.gameObject.SetActive(false);
            }


        }
        else
        {
            PlayerState = PlayerStates.NoInteracting;
            
            returnButton.SetActive(false);
            inputsUI.gameObject.SetActive(true);
        }
    }

    public bool GetPlayerState(PlayerStates stateTarget)
    {
        if (stateTarget == PlayerState)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetPlayerInCinematic()
    {
        ActivateInteracting();
        returnButton.gameObject.SetActive(false);
        inputsUI.gameObject.SetActive(false);
        
    }

    public void UnSetPlayerCinematic()
    {
        DeactivateInteracting();
        returnButton.gameObject.SetActive(false);
        inputsUI.gameObject.SetActive(true);
    }
    public void ActivateInteracting()
    {
        isInteracting = true;
        HandlePlayerStates();
    }

    public void DeactivateInteracting()
    {
        isInteracting = false;
        HandlePlayerStates();
    }

    void OnEnable()
    {
      // GameManager.current.SetPlayerState += HandlePlayerStates;
    }

    private void OnDisable()
    {
        if(GameManager.current!=null)
        GameManager.current.SetPlayerState -= HandlePlayerStates;
    }

    //cryoStorage -23/05/22
    //calls audio manager method play when player is moving
    IEnumerator corAudioCooldown()
    {
        while (true)
        {
            CallAudio();
            yield return new WaitForSeconds(.5f);
        }
    }
     void CallAudio()
    {
        if(myCharacterController.velocity.magnitude > 0)
        {
            FindObjectOfType<AudioManager>().Play("Player_Step");
        }
    }
}


public enum PlayerStates
    {
        NoInteracting = 0,
        Interacting = 1,
    
    }

