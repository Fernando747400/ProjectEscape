using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class InventoryUI_Dino : MonoBehaviour
{
   [SerializeField] List<Item_nventoryUI> itemList = new List<Item_nventoryUI>(); 




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

     public void AddItemsToList()
    {


        UpdateItemsInventory();        
    }
    
    public void UpdateItemsInventory()
    {

    }
    

     private void OnEnable() {
         // GameManager.current.TakeObject += AddItemsToList;
        
    }
    private void OnDisable() {
        // GameManager.current.TakeObject -= AddItemsToList;
    }


}
