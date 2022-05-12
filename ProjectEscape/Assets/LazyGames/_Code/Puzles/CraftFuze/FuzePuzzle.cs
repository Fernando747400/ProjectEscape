using System.Collections;
using UnityEngine;

public class FuzePuzzle : MonoBehaviour, IUsable
{
    public GameObject PartOne, PartTwo, Fuze3;
    public GameObject[] Parts;
    public GameObject placeFuze;


    public bool CanInteract
    {
        get;
        set;
    }

    void Start()
    {
        PartOne.SetActive(false);
        PartTwo.SetActive(false);
        // Fuze3.SetActive(false);
    }

    void Update()
    {
        Parts = GameObject.FindGameObjectsWithTag("parts");

        if (Parts.Length == 2)
        {
            Fuze3.transform.position = placeFuze.transform.position;
        }
    }

    


    public void Use()
    {
        GameManager.current.activateInteracting();
    }
}
