using UnityEngine;
using System.Collections;

public class CarGate : MonoBehaviour
{

    public GameObject[] Tornillos;
    public GameObject carGate;

    public void Awake()
    {
        carGate.SetActive(true);
    }

    void Update()
    {
        Tornillos = GameObject.FindGameObjectsWithTag("tornillo");

        if(Tornillos.Length == 0)
        {
            carGate.SetActive(false);
            StartCoroutine(WaitOpenDoor());
        }
    }

    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(2);
        CameraHandler.current.SwitchToPlayerCamera();
        PlayerController.current.UnSetPlayerCinematic();
    }
}
