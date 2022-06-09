using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Lean.Touch;
using UnityEngine.UI;

public class Item_nventoryUI :SelectableItem
{
    
    [SerializeField] public  Text itemName;
    [SerializeField] public Image itemImage;
    [SerializeField] public GameObject gameObjectAttached;

    


    private LayerMask layer;
    private ItemInventoryData itemData;
    //private LeanFinger m_DraggingFinger;

    private Vector3 originalPosition;

    private bool canBeDrag;
    private bool isSavedInventory;
    
    private bool isSelected;

    public bool IsSelect
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    
    public bool CanBeDrag
    {
        get { return canBeDrag;}
    }
    
    
    public bool IsSavedInventory
    {
        get{return isSavedInventory;}
    }
    
    
    public void  SetSelected(bool targetBool)
    {
        if(PlayerController.current.GetPlayerState(PlayerStates.Interacting))
        {
            IsSelect = targetBool;
            itemImage.color = itemImage.color = new Color(1, 1, 1, 0.5f);
            gameObjectAttached.SetActive(true);
            Debug.Log(IsSelect);
        }
        else
        {
            IsSelect = false;
        }
        
    }
    public void SetData(ItemInventoryData _itemData)
    {
         itemData = _itemData;
         itemName.text= itemData.nameItem;
         itemImage.sprite = itemData.itemImage;
         itemImage.color = new Color(1, 1, 1, 1);
         isSavedInventory = true;
    }

    void Awake()
    {
        
        IsSelect = false;
        gameObjectAttached.SetActive(false);
        
        itemImage.color = new Color(0, 0, 0, 0);

    }

    void Update()
    {

    }

    // public void HandleItemSelection(LeanFinger finger)
    // {
    //
    //     // if (finger.IsOverGui)
    //     // {
    //     //     RaycastHit hit;
    //     //     Ray ray = finger.GetRay();
    //     //     
    //     //     if (Physics.Raycast(ray, out hit))
    //     //     {
    //     //         Item_nventoryUI item = hit.transform.GetComponent<Item_nventoryUI>();
    //     //             Debug.Log(item);
    //     //         if (item != null)
    //     //         {
    //     //             Debug.Log("Is touching item ");
    //     //
    //     //         }
    //     //     }
    //     //    
    //     // }
    // }
    //
    
    // public void HandleSelectEvent(LeanFinger finger)
    // {
    //     if(!CanBeDrag)return;
    //     m_DraggingFinger = finger;
    //     OnSelectItem?.Invoke(this, finger);
    //     
    // }

    // public void HandleDeselectEvent()
    // {
    //     m_DraggingFinger = null;
    //     OnDeselectItem?.Invoke(this);
    // }
    
    // public System.Action<Item_nventoryUI, LeanFinger> OnSelectItem;
    // public System.Action<Item_nventoryUI> OnDeselectItem;
    
// #if UNITY_EDITOR
//     protected virtual void Reset()
//     {
//         Use.UpdateRequiredSelectable(gameObject);
//     }
// #endif
//     
}
