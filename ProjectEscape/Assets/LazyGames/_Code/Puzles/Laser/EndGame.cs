using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject LaserOne;
    public GameObject LaserTwo;
    public GameObject LaserThree;

    private bool One, Two, Three;

    private void Update()
    {
        One = LaserOne.GetComponent<Laser>().End;
        Two = LaserTwo.GetComponent<LaserTwo>().End;
        Three = LaserThree.GetComponent<Cube_Rotation>().End;

        if(One && Two && Three)
        {
            Debug.Log("Se acabo el juego");
        }
    }
}
