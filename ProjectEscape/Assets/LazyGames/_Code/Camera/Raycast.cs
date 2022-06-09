using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
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
	
	List<IUsable> usables = new List<IUsable>();



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

		
	//	try { mouse = Mouse.current; }
		//catch { LeanTouch.OnFingerDown += GetViewInfoTouch; Log("No mouse found, switched to LeanTouch Instead");}		
		
		
		LeanTouch.OnFingerDown += GetViewInfoTouch;
	}
    
	
	void GetViewInfoTouch(LeanFinger finger)
	{
		if (playerController.PlayerState == PlayerStates.NoInteracting)
		{
			if (!finger.IsOverGui)
			{
				Log("Esta sacando el raycast?");
				// Log("Finger is NOT GUI");
				RaycastHit hit;
				Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
				// Log("Position Finger in screen " + coordinate);
				if (myCamera == null) myCamera = Camera.main;
				Ray myRay = myCamera.ScreenPointToRay(coordinate);

				if (Physics.Raycast(myRay, out hit, maxDistance, usablesMask.value))
				{
					Log("Raycast hitted: " + hit.transform.gameObject.name);

					usables.Clear();
					usables = hit.transform.GetComponents<IUsable>().ToList(); ////Double checks to see if the object has the IUsable interface inherited. 
					InteractableObjects interactableObjects = hit.transform.GetComponent<InteractableObjects>();
					
					if (usables.Count > 0)
					{
						foreach(var Usable in usables)
                        {
							Usable.Use();
                        }
						if (interactableObjects != null)
						{
							interactableObjects.SendInfoObjectToInventory();
						}
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

