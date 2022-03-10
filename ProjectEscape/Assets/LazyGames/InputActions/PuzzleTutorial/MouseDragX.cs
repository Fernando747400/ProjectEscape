using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDragX : TutorialInputManager
{
    private GameObject Switch;
    public GameObject Cristal;
    private bool press;
    private bool BombillaDos;
    public Material Bombilla;

    private void Start()
    {
        press = false;
        BombillaDos = false;
    }

    private void Update()
    {
        if (BombillaDos == false)
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);
        }
        if (BombillaDos == true)
        {
            Bombilla.color = Color.magenta;
            Cristal.gameObject.SetActive(false);
        }

        if (Switch == null)
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Switch"))
                {
                    Debug.Log("No es la tarjeta");
                    return;
                }

                Debug.Log("Es la tarjeta");
                Switch = hit.collider.gameObject;
            }
        }
        else
        {
            RaycastHit hit = CastRay();
            Switch = null;
            Debug.Log("No choca con nada");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Great")
        {
            BombillaDos = true;
        }

        if(other.tag == "bad")
        {
            BombillaDos = false;
        }
    }

    protected override void MouseDrag(InputAction.CallbackContext value)
    {
        if (press == true)
        {
            Vector3 ScreenPosition = new Vector3(Mouse.current.position.ReadValue().x / 500 - 12, 2f, -3.90f);
            transform.position = ScreenPosition;
        }
    }

    protected override void MousePress(InputAction.CallbackContext value)
    {
        if (Switch != null)
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
