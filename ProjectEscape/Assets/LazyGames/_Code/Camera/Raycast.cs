using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.InputSystem;
//[|87
public class Raycast : MonoBehaviour
{

	Mouse mouse;
	Camera myCamera;

	[Header("Raycast distance")]
    [Range(0f, 100f)]
    [SerializeField] float maxDistance;

	[Header("Usables Mask")]
	[SerializeField] LayerMask usablesMask;

	[Header("Dependencies")]
	[SerializeField] PlayerController playerController;

	[Header("Debugging")]
	[SerializeField] Logger logger;


    private void Start()
    {
	    Prepare();
    }

    void Update()
    {
		if (mouse!= null && mouse.rightButton.wasPressedThisFrame)
		{
			// GetViewInfo();
        }
    }

    void Prepare()
	{
		try { myCamera = Camera.main; }
		catch { myCamera = GetComponent<Camera>(); Log("Didn't find a camera. Tried searching for one on this script parent"); }

		
		try { mouse = Mouse.current; }
		catch { LeanTouch.OnFingerDown += GetViewInfoTouch; Log("No mouse found, switched to LeanTouch Instead");}		
		
		
		LeanTouch.OnFingerDown += GetViewInfoTouch;
	}
    
	void GetViewInfo()
	{
		if(playerController.PlayerState == PlayerStates.NoInteracting)
        {
			RaycastHit hit;
			Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2); //Gets the position of the middle of the screen
			Ray myRay = myCamera.ScreenPointToRay(coordinate); //Defines a ray from the given screen coordinate
			if (Physics.Raycast(myRay, out hit, maxDistance, usablesMask.value)) //Raycast only interacts with objects that are on the Usables layer mask.
			{
				Log("Raycast hitted: " + hit.transform.gameObject.name);
				IUsable usable = hit.transform.GetComponent<IUsable>(); //Double checks to see if the object has the IUsable interface inherited. 
				IUsable cameraUsable = hit.transform.GetComponent<CameraSwitcher>(); //Checks to see if we need to move the camera 
				if (usable != null)
				{
					usable.Use();
				}
				if (cameraUsable != null)
				{
					cameraUsable.Use();
					Log("Changed camera Position");
				}
			}
			else
			{
				Log("Didn't hit anything on the usables mask");
			}
        }
	}

	void GetViewInfoTouch(LeanFinger finger)
	{
		if (playerController.PlayerState == PlayerStates.NoInteracting)
		{
			if (!finger.IsOverGui)
			{
				// Log("Esta sacando el raycast?");
				Log("Finger is NOT GUI");
				RaycastHit hit;
				Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
				Log("Positino ddddddFinger in screen " + coordinate);
				Ray myRay = myCamera.ScreenPointToRay(coordinate);

				if (Physics.Raycast(myRay, out hit, maxDistance, usablesMask.value))
				{
					Log("Raycast hitted: " + hit.transform.gameObject.name);

					IUsable usable = hit.transform.GetComponent<IUsable>(); ////Double checks to see if the object has the IUsable interface inherited. 
					IUsable cameraUsable = hit.transform.GetComponent<CameraSwitcher>(); //Checks to see if we need to move the camera 

					if (usable != null)
					{
						usable.Use();
					}

					if (cameraUsable != null)
					{
						cameraUsable.Use();
						Log("Changed camera Position");
					}
				}
                else { 
						Log("Didn't hit anythig with touch on the usables mask");
					}
			}
		}
	}

	void Log(object message)
    {
		if (logger)
		{
			logger.Log(message, this);
		}
    }
}

