using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class Item_nventoryUI : MonoBehaviour
{
    
    private bool isSelected;
    private bool isSavedInventory;

    public bool IsSelected
    {
        get { return isSelected;}
    }

    public bool IsSavedInventory
    {
        get{return isSavedInventory;}
    }
    public void SelectItemFromInventory(LeanFinger lean)
    {
        Button buttonItem = gameObject.AddComponent<Button>();
        // buttonItem.FindSelectableOnDown
        if (lean.Down)
        {
            if(lean.IsOverGui)
            {
                // if(raycast)
                // {
                //     isSelected = true;
                   
                // }
                // else
                // {
                //     isSelected = false;
                //     // Debug.Log()
                // }

            }
        }

         Debug.Log(isSelected);
        

    }
    void Start()
    {
        LeanTouch.OnFingerDown += SelectItemFromInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
