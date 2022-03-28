using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{

	Mouse mouse;
	Camera myCamera;
	private LeanFinger finger;
	
	[Header("Rycast")]
    [Range(0f, 100f)]
    [SerializeField] float distanceHit;
	[SerializeField] LayerMask usablesMask;


	[SerializeField] private PlayerController playerController;

    private void Start()
    {
	    Prepare();
    }

    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR 
		if (mouse.leftButton.wasPressedThisFrame)
		{
			GetViewInfo();
        }
#endif

    }

    void Prepare()
	{
		
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
		mouse = Mouse.current;
#endif
		try { myCamera = Camera.main; }
		catch { myCamera = GetComponent<Camera>();}
		
#if UNITY_ANDROID || UNITY_EDITOR
		LeanTouch.OnFingerDown += GetViewInfoTouch;
#endif
		
	}
    
	void GetViewInfo()
	{
		RaycastHit hit;
		Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
		Ray myRay = myCamera.ScreenPointToRay(coordinate);
		if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value))
		{
			// Debug.Log("Raycast hitted: " + hit.transform.gameObject.name);
			IUsable usable = hit.transform.GetComponent<IUsable>();
			CameraPosition cameraPosition = hit.transform.GetComponent<CameraPosition>();
			if (usable != null)
			{
				usable.Use();
				if (cameraPosition != null)
				{
					// Debug.Log("ChangeCamera Pos");
					cameraPosition.TransformCameraToPlace(myCamera);
				}
			}
        }
        else
        {
			// Debug.Log("Didn't hit anything");
        }
	}

	void GetViewInfoTouch(LeanFinger finger)
	{
		if (playerController.PlayerState == PlayerStates.NoInteracting)
		{
			
			if (!finger.IsOverGui)
			{
				Debug.Log("<color=#EEBFFF> Esta sacando el raycast?</color>");
				// Debug.Log("<color=#EEBFFF> finger is NOT GUI</color>");
				RaycastHit hit;
				Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
				Ray myRay = myCamera.ScreenPointToRay(coordinate);
			
				if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value))
				{
					// Debug.Log("Raycast hitted: " + hit.transform.gameObject.name);
			
					IUsable usable = hit.transform.GetComponent<IUsable>();
					CameraPosition cameraPosition = hit.transform.GetComponent<CameraPosition>();
			
					if (usable != null)
					{
						usable.Use();
						if (cameraPosition != null)
						{
							// Debug.Log("ChangeCamera Pos");
							cameraPosition.TransformCameraToPlace(myCamera);
						}
					} 
					else
					{
						// Debug.Log("Didn't hit anythig on touch");
					}
				}
			}
		}
		
		// GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), coordinate, Quaternion.Euler(Vector3.zero));
	}
}

