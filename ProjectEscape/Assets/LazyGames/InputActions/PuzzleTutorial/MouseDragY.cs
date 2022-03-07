using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDragY : TutorialInputManager
{
    private GameObject Tarjeta;
    private bool press;
    private bool BombillaUno;
    public Material Bombilla;
    private BoxCollider box;

    private void Start()
    {
        press = false;
        BombillaUno = false;
        box = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(BombillaUno == false)
        {
            Bombilla.color = Color.white;
        }
        if (BombillaUno == true)
        {
            Bombilla.color = Color.green;
            box.enabled = false;
        }

        if (Tarjeta == null)
        {
            RaycastHit hit = CastRay();
            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Tarjeta"))
                {
                    return;
                }
                Tarjeta = hit.collider.gameObject;
            }
        }
        else
        {
            RaycastHit hit = CastRay();
            Tarjeta = null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Great")
        {
            BombillaUno = true;
        }    
    }

    protected override void MouseDrag(InputAction.CallbackContext value)
    {
        if (press == true)
        {
            Vector3 ScreenPosition = new Vector3(-1.3f, 2f, Mouse.current.position.ReadValue().y / 100);
            transform.position = ScreenPosition;
        }
    }

    protected override void MousePress(InputAction.CallbackContext value)
    {
        if (Tarjeta != null)
        {
            press = true;
        }

    }

    protected override void MousePosition(InputAction.CallbackContext value)
    {
        press = false;
    }
    
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
