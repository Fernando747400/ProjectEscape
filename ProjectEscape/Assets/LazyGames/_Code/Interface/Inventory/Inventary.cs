using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CharacterController))]
public class Inventary : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    public Transform canvas;
    public GameObject selectedObject;
    void Start()
    {
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
    }
    void Update()
    {
        Drag();
    }

    void Drag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
        }
        graphRay.Raycast(pointerData, raycastResults);
        if(raycastResults.Count > 0){
            if(raycastResults[0].gameObject.GetComponent<Items>())
            {
                selectedObject = raycastResults[0].gameObject;
                selectedObject.transform.SetParent(canvas);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            pointerData.position = Input.mousePosition;
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);
            if(raycastResults.Count > 0)
            {
                foreach(var result in raycastResults)
                {
                    if(result.gameObject.tag == "Slot")
                    selectedObject.transform.localPosition = Vector2.zero;
                    {selectedObject.transform.SetParent(result.gameObject.transform);}
                }
            }
        }
    }
}
