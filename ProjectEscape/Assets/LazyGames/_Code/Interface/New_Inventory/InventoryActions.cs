using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActions : MonoBehaviour
{
    public  Item_nventoryUI[] itemsUI;
    
    public void EreaseItemsData()
    {
        for (int i = 0; i < itemsUI.Length; i++)
        {
            itemsUI[i].itemImage = null;
            itemsUI[i].itemImage = null;
            itemsUI[i].gameObjectAttached = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
