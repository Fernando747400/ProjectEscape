using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Object : MonoBehaviour
{
    public Transform Object;
    public GameObject Objeto;
    public Rigidbody Player;
    public float x,y,z,Force;
    public GameObject Position;
    public Transform position2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotacion();
    }

    private void rotacion()
    {
        Object.transform.Rotate(0,Force,0);
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("haz tomado el objecto");
            Object.position = position2.position;
        
        }
    }        
}
