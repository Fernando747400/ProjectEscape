using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebel : MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;
    public int cameraPlaceArray;

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
            Debug.Log("label?");
            PlayerController.current.DeactivateInteracting();
            CameraHandler.current.SelectCamera(cameraPlaceArray);
            StartCoroutine(WaitOpenDoor());
            GameManager.current.openShipDoor();
            StopAllCoroutines();
            CameraHandler.current.SwitchToPlayerCamera();

        }
        else if (other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);

        }
    }



    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(7);
    }
}
