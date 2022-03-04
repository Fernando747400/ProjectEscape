using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputs : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Player.transform.position = new Vector3(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Player.transform.position = new Vector3(0,0,speed * Time.deltaTime);
          //  Player.AddForce(0,0,speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Player.transform.position = new Vector3(0,0,-speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            
           // Player.AddForce(speed * Time.deltaTime,0,0);
        }
    }
}
