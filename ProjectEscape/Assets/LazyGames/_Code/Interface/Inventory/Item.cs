using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public int numberOfItems = 1;
    public Text numberOfItemsText;
    public int ID;

    void Start()
    {
        
    }

    void Update()
    {
        numberOfItemsText.text = numberOfItems.ToString();
    }
}
