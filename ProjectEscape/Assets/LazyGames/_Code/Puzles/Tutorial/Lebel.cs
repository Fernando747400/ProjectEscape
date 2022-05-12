using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebel : MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;
    public int cameraPlaceArray = 1;

    public void Start()
    {
        Bombilla.color = Color.white;
        Cristal.gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Great")
        {
            Bombilla.color = Color.green;
            Cristal.gameObject.SetActive(false);

            // Call Event open door
            PlayerController.current.DeactivateInteracting();
            CameraHandler.current.SelectCamera(cameraPlaceArray);
            PlayerController.current.SetPlayerInCinematic();
            
            StartCoroutine(WaitOpenDoor());

        }
        else if (other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);

        }
    }



    IEnumerator WaitOpenDoor()
    {
        GameManager.current.openShipDoor();
        yield return new WaitForSeconds(5);
        CameraHandler.current.SwitchToPlayerCamera();
        PlayerController.current.UnSetPlayerCinematic();


    }
}
