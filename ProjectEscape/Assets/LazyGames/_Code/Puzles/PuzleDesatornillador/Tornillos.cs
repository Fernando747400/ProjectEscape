using UnityEngine;

public class Tornillos : MonoBehaviour
{
    public GameObject tPrefab;

    void Start()
    {
        tPrefab.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "desatornillador")
        {
            tPrefab.SetActive(false);
        }
    }
}
