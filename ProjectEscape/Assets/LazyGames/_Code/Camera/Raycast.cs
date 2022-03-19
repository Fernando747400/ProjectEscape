using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{

	Mouse mouse;
	Camera myCamera;

	[Header("Rycast")]
    [Range(0f, 100f)]
    [SerializeField] float distanceHit;
	[SerializeField] LayerMask usablesMask;

    private void Start()
    {
		Prepare();
    }

    void Update()
    {
		if (mouse.leftButton.wasPressedThisFrame)
		{
			GetViewInfo();
        }
        else
        {
			GetViewInfo();
        }
	}

    void Prepare()
	{
		mouse = Mouse.current;
		try { myCamera = Camera.main; }
		catch { myCamera = GetComponent<Camera>();}
		Lean.Touch.LeanTouch.OnFingerDown += GetViewInfoTouch;
	}


	void GetViewInfo()
	{
		RaycastHit hit;
		Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
		Ray myRay = myCamera.ScreenPointToRay(coordinate);
		if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value))
		{
			Debug.Log("Raycast hitted: " + hit.transform.gameObject.name);
			IUsable usable = hit.transform.GetComponent<IUsable>();
			if (usable != null)
			{
				usable.Use();
			}
        }
        else
        {
			Debug.Log("Didn't hit anything");
        }
	}

	void GetViewInfoTouch(Lean.Touch.LeanFinger finger)
	{
		RaycastHit hit;
		Vector2 coordinate = new Vector2(finger.ScreenPosition.x, finger.ScreenPosition.y);
		Ray myRay = myCamera.ScreenPointToRay(coordinate);
		if (Physics.Raycast(myRay, out hit, distanceHit, usablesMask.value))
		{
			Debug.Log("Raycast hitted: " + hit.transform.gameObject.name);
			IUsable usable = hit.transform.GetComponent<IUsable>();
			if (usable != null)
			{
				usable.Use();
			} else
            {
				Debug.Log("Didn't hit anythig on touch");
			}
		}
		GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), coordinate, Quaternion.Euler(Vector3.zero));
	}
}
