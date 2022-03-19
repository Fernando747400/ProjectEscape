using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RotationLeverY : TutorialInputManager
{
    private GameObject Switch;
    private bool press;
    private bool BombillaDos;
    public Material Bombilla;
    [SerializeField] private string SceneToLoad;

    private void Start()
    {
        press = false;
        BombillaDos = false;
    }

    private void Update()
    {
        Debug.Log(Mouse.current.position.ReadDefaultValue().x);
        if (BombillaDos == false)
        {
            Bombilla.color = Color.white;
        }
        if (BombillaDos == true)
        {
            Bombilla.color = Color.yellow;
        }

        if (Switch == null)
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Lever"))
                {
                    Debug.Log("No es la tarjeta");
                    return;
                }

                Debug.Log("Es la palanca");
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
            StartCoroutine(loadScene());
        }
    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneToLoad);
    }

    protected override void MouseDrag(InputAction.CallbackContext value)
    {
        if (press == true)
        {
            Vector3 ScreenPosition = new Vector3(175, 0, 0);
            transform.rotation = Quaternion.Euler(ScreenPosition);
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
