using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IUsable
{
    private Collider collider;
    public GameObject particles;

    public string nameSFX = "Door_Open";
    public bool CanInteract
    {
        get;
        set;
    }

    public Vector3 targetPosition;

    private void Start() {
        
        if(GameManager.current!= null)
        {
            GameManager.current.OpenShipDoor += Open;
            GameManager.current.OpenSecondDoor += Open;
            GameManager.current.OpenThirdDoor+= Open;
            Debug.Log("Se susbcribe puerta " + this.gameObject.name);

        }

        collider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        // GameManager.current.OpenShipDoor += Open;
    }

    private void OnDisable()
    {
        if(GameManager.current!=null)
        {
            GameManager.current.OpenShipDoor -= Open;
            GameManager.current.OpenSecondDoor -= Open;
            GameManager.current.OpenThirdDoor -= Open;

        }
    }

    public void Use()
    {
        // Open();
    }
    

    public void Open()
    {
        if (collider != null)
        {
            collider.enabled = false;
        }

        if (particles != null)
        {
            particles.SetActive(false);
        }
        iTween.MoveTo(this.gameObject, iTween.Hash("position",targetPosition, "time",5));

        if (nameSFX != null)
        {
            AudioManager.instance.Play(nameSFX);
        }
    }
}
