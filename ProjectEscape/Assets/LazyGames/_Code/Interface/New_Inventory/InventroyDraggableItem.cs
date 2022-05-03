using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public abstract class InventroyDraggableItem : MonoBehaviour
{
    
    private Item_nventoryUI _dragItem;
   
    public Item_nventoryUI DraggableItem
    {
        get { return _dragItem; }
    }

    private void Start()
    {
        // DraggableItem.OnSelectItem += HandleOnSelectDraggableItem;
        // DraggableItem.OnDeselectItem += HandleOnDeselectDraggableItem;
    }
    
    protected abstract void HandleOnSelectDraggableItem(Item_nventoryUI item, LeanFinger finger);
    protected abstract void HandleOnDeselectDraggableItem(Item_nventoryUI item);
}
