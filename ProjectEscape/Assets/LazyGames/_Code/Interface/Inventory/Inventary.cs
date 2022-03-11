using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventary : MonoBehaviour
{
    Mouse mouse;
    
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    public GraphicRaycaster graphRay;
    public Transform canvas;
    public GameObject selectedObject;
    public Transform lastSlot;


    public Vector2 CanvasScreen(Vector2 screenPos)
    { 
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        return(new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize/2));
    }

       void Prepare()
    {
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR 
        #endif
        mouse = Mouse.current;
    }
        void Start()
    {
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
    }
    void Update()
    {
        Drag();
    }

    // Mover items por el camvas
    void Drag()
    {
        // Aqui esta el error, es necesario sacar la posicion del mouse y convertirla en vector 2
        mouse = Mouse.current;
        Vector2 mousePosition = mouse.delta.ReadValue();

        pointerData.position = mousePosition;
        graphRay.Raycast(pointerData, raycastResults);
        
        // al tocar el item obtiene su informacion
        if(mouse.leftButton.wasPressedThisFrame)
        {
            pointerData.position = mousePosition;
            graphRay.Raycast(pointerData, raycastResults);
            // se guarda la informacion del item en selectedObject
            if(raycastResults.Count > 0)
            {
                if(raycastResults[0].gameObject.GetComponent<Item>())
                {
                    selectedObject = raycastResults[0].gameObject;
                    lastSlot = selectedObject.transform.parent;
                    lastSlot.GetComponent<Image>().fillCenter = false;
                    selectedObject.transform.SetParent(canvas);
                }
        }

        }

        

        // Mueve el item de slot al seleccionarlo
        if(selectedObject != null)
        {
            selectedObject.GetComponent<RectTransform>().localPosition = CanvasScreen(mousePosition);
        }

        if(selectedObject != null)
        {
            // Al soltar el mouse soltara el item a un slot vacio
            if(mouse.leftButton.wasReleasedThisFrame)
            {
              // guarda la posicion del mouse
               pointerData.position = mousePosition;
                // limpia la informacion del item
               raycastResults.Clear();
               graphRay.Raycast(pointerData, raycastResults);

              selectedObject.transform.SetParent(lastSlot);

                if(raycastResults.Count > 0)
                {
                  foreach(var result in raycastResults)
                    {
                        if (result.gameObject == selectedObject) {continue;}
                        if(result.gameObject.CompareTag ("Slot"))
                        {
                         // coloca el item en el slot libre seleccionado
                            if(result.gameObject.GetComponentInChildren<Item>() == null)
                            {
                                selectedObject.transform.SetParent(result.gameObject.transform);
                                Debug.Log("Slot Libre");
                            }
                        
                            //se suman los items del mismo tipo
                            if(result.gameObject.CompareTag("Item"))
                            {
                                if(result.gameObject.GetComponentInChildren<Item>().ID == selectedObject.GetComponent<Item>().ID)
                                {
                                Debug.Log("Mismo ID");
                                result.gameObject.GetComponentInChildren<Item>().numberOfObjects += selectedObject.gameObject.GetComponent<Item>().numberOfObjects;
                                Destroy(selectedObject.gameObject);
                                } 
                            }
                                //intercambian de posicion si son distintos
                                else
                                {
                                    Debug.Log("ID distinto");
                                    selectedObject.transform.SetParent(result.gameObject.transform.parent);
                                    result.gameObject.transform.SetParent(lastSlot);
                                    result.gameObject.transform.localPosition = Vector2.zero;
                                } 
                            }
                        }
                    }
                selectedObject.transform.localPosition = Vector2.zero;
                selectedObject = null;
            }
        }
        raycastResults.Clear();
    }
}