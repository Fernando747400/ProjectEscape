using System.Collections;
using UnityEngine;

public class FuzePuzzle : MonoBehaviour, IUsable
{
    public GameObject PartOne, PartTwo, Fuze3;
    public GameObject[] Parts;
    public GameObject placeFuze;
    public bool isUsed = false;

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
        isUsed = false;
    }

    void Update()
    {
        Parts = GameObject.FindGameObjectsWithTag("parts");

        if (Parts.Length == 2 && isUsed == false)
        {
            placeFuze.SetActive(true);
            isUsed = true;
        }
    }

    


    public void Use()
    {
        GameManager.current.activateInteracting();
    }
}
