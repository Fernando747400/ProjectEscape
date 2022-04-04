using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Item_nventoryUI itemTarget;
    public ItemInventoryData itemData;

    private bool isInInventory = false;

    void Start()
    {
        GameManager.current.takeObject();
        // isInInventory = InventoryUI_Dino.current.itemList.Find(itemTarget.IsSavedInventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendInfoObjectToInventory()
    {
        
        itemTarget.SetData(itemData);
    }
}
