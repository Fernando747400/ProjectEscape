using UnityEngine;

public class OtherconcionalTutorial: MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;

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
        }
        else if (other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);

        }
    }
}
