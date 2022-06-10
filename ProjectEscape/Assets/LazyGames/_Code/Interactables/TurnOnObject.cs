using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnObject : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
    public GameObject mygameObject;
    public GameObject canvas;
    public void Use()
    {
        mygameObject.SetActive(true);
        //canvas.SetActive(false);
        GameManager.current.activateInteracting();
    }
        // Start is called before the first frame update
        void Start()
    {
        mygameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
