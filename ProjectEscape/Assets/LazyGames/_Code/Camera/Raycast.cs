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
    [SerializeField] float distanceHit;

	[Header("Usables Mask")]
	[SerializeField] LayerMask usablesMask;

	[Header("Player Controller")]
	[SerializeField] private PlayerController playerController;

	[Header("Print logs of this script")]
	[SerializeField] private bool printLogs;


    private void Start()
    {
	    Prepare();
    }

    void Update()
    {
		if (mouse!= null && mouse.leftButton.wasPressedThisFrame)
		{
			GetViewInfo();
        }
    }

    void Prepare()
	{
		try { myCamera = Camera.main; }
		catch { myCamera = GetComponent<Camera>(); Dlog("Didn't find a camera. Tried searching for one"); }

		try { mouse = Mouse.current; }
		catch { LeanTouch.OnFingerDown += GetViewInfoTouch; Dlog("No mouse found, switched to LeanTouch Instead");}		
	}
    
	void GetViewInfo()
	{
		RaycastHit hit;
		Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2); //Gets the position of the middle of the screen
		Ray myRay = myCamera.ScreenPointToRay(coordinate);
		if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value)) //Raycast only interacts with objects that are on the Usables layer mask.
		{
			Dlog("Raycast hitted: " + hit.transform.gameObject.name);
			IUsable usable = hit.transform.GetComponent<IUsable>(); //Double checks to see if the object has the IUsable interface inherited. 
			CameraPosition cameraPosition = hit.transform.GetComponent<CameraPosition>();
			if (usable != null)
			{
				usable.Use();
				if (cameraPosition != null)
				{
					Dlog("ChangeCamera Pos");
					cameraPosition.TransformCameraToPlace(myCamera);
				}
			}
        }
        else
        {
			Dlog("Didn't hit anything. Check if the object has the Usables layermask correctly implemented");
        }
	}

	void GetViewInfoTouch(LeanFinger finger)
	{
		if (playerController.PlayerState == PlayerStates.NoInteracting)
		{
			
			if (!finger.IsOverGui)
			{
				Dlog("Esta sacando el raycast?");
				Dlog("Finger is NOT GUI");
				RaycastHit hit;
				Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
				Ray myRay = myCamera.ScreenPointToRay(coordinate);
			
				if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value))
				{
					Dlog("Raycast hitted: " + hit.transform.gameObject.name);
			
					IUsable usable = hit.transform.GetComponent<IUsable>();
					CameraPosition cameraPosition = hit.transform.GetComponent<CameraPosition>();
			
					if (usable != null)
					{
						usable.Use();
						if (cameraPosition != null)
						{
							Dlog("ChangeCamera Pos");
							cameraPosition.TransformCameraToPlace(myCamera);
						}
					} 
					else
					{
						Dlog("Didn't hit anythig on touch");
					}
				}
			}
		}
	}

	private void Dlog(string message)
    {
		if (printLogs)
		{
			Debug.Log("<color=#EEBFFF> " + message + " </color>");
		}
    }
}

