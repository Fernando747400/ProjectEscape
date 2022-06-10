using UnityEngine;

public class WinTutorial : MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;
    public Material BombillaUno;
    public string sound;
    public GameObject lebel;

    public void Start()
    {
        Bombilla.color = Color.white;
        BombillaUno.color = Color.white;
        Cristal.gameObject.SetActive(true);
        lebel.GetComponent<BoxCollider>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Great")
        {
            Bombilla.color = Color.green;
            Cristal.gameObject.SetActive(false);
            if(sound != null ||  sound != "") PlaySound(sound);
            lebel.GetComponent<BoxCollider>().enabled = true;

        }
        else if(other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);
            lebel.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }
}
