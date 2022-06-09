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

   
    void Start()
    {
        GameManager.current.PuzzleCrafteo += OpenDoorCrafteoPuzzle;
    }

    void Update()
    {
        Tornillos = GameObject.FindGameObjectsWithTag("tornillo");

        if(Tornillos.Length == 0)
        {
            carGate.SetActive(false);
        }
    }


    void OpenDoorCrafteoPuzzle()
    {
        StartCoroutine(WaitOpenDoor());
    }

    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(2);

        if(PlayerController.current.GetPlayerState(PlayerStates.Interacting))
        {
            CameraHandler.current.SwitchToPlayerCamera();
            PlayerController.current.DeactivateInteracting();

        }
       // PlayerController.current.UnSetPlayerCinematic();
    }
}
