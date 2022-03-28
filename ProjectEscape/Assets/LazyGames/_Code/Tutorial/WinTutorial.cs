using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class WinTutorial : MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;
    public GameObject Palanca;

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
            Palanca.gameObject.GetComponent<LeanTwistRotateAxis>().enabled = true;
        }
        else if(other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);
            Palanca.gameObject.GetComponent<LeanTwistRotateAxis>().enabled = false;

        }
    }
}
