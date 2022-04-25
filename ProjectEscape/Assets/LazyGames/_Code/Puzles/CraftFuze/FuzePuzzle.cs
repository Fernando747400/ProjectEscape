using System.Collections;
using UnityEngine;

public class FuzePuzzle : MonoBehaviour, IUsable
{
    public GameObject PartOne, PartTwo, Fuze3;
    public GameObject[] Parts;


    public bool CanInteract
    {
        get;
        set;
    }

    void Start()
    {
        PartOne.SetActive(false);
        PartTwo.SetActive(false);
        Fuze3.SetActive(false);
    }

    void Update()
    {
        Parts = GameObject.FindGameObjectsWithTag("parts");

        if (Parts.Length == 2)
        {
            Fuze3.SetActive(true);
            StartCoroutine(WaitOpenDoor());
        }
    }

    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(2);

        //if(PlayerController.current.GetPlayerState())
        //CameraHandler.current.SwitchToPlayerCamera();
        //PlayerController.current.UnSetPlayerCinematic();


        Debug.Log("This is payre state" + PlayerController.current.PlayerState);
    }


    public void Use()
    {
        GameManager.current.activateInteracting();
    }
}