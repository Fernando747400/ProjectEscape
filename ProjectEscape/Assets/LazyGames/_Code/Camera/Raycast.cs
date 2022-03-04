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
	}

    void Prepare()
	{
		mouse = Mouse.current;
		try { myCamera = Camera.main; }
		catch { myCamera = GetComponent<Camera>(); }
	}


	void GetViewInfo()
	{
		RaycastHit hit;
		Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
		Ray myRay = myCamera.ScreenPointToRay(coordinate);
		if ((Physics.Raycast(myRay, out hit, distanceHit)))
		{
			Debug.Log("Raycast hitted: " + hit.transform.gameObject.name);
			IUsable usable = hit.transform.GetComponent<IUsable>();
			if (usable != null)
			{
				usable.Use();
				Debug.Log("Hit a cube");
			}
		}
	}
}
