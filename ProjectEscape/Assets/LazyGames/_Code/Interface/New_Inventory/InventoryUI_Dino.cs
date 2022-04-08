using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public  class InventoryUI_Dino : MonoBehaviour
{
    public static InventoryUI_Dino current;
    
   [SerializeField] public List<Item_nventoryUI> itemList = new List<Item_nventoryUI>();

   public bool[] itemsPick;

  
    void Start()
    {
        current = this;

        for (int i = 0; i < itemList.Capacity; i++)
        {
            itemsPick[i] = itemList[i].IsSavedInventory;
        }
      
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    
 

   

}
