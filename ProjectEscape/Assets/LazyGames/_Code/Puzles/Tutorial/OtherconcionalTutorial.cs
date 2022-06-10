using UnityEngine;

public class OtherconcionalTutorial: MonoBehaviour
{
    public GameObject Cristal;
    public Material Bombilla;
    public string sound;
    public string stinger;

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
            if (sound != null || sound != "") PlaySound(sound);
            if (stinger != null || stinger != "") PlaySound(stinger);
            GameManager.current.openShipDoor();
        }
        else if (other.tag == "bad")
        {
            Bombilla.color = Color.white;
            Cristal.gameObject.SetActive(true);

        }
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }
}
