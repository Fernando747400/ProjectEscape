using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public int numberOfObjects = 1;
    public Text numberOfObjectsText;
    public int ID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfObjectsText.text = numberOfObjects.ToString();
    }
}

