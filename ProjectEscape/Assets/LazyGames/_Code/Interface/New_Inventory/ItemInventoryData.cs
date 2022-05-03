using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Items_Data")]
public class ItemInventoryData : ScriptableObject
{
    // []
    //Data Item
    [SerializeField] public Sprite itemImage;
    [SerializeField] public string nameItem;
    [SerializeField] public string namePuzzle;
    
    
    public string MyPoolKey = "item";
   
}
