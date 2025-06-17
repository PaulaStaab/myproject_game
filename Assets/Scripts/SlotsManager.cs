using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    public bool SlotFree = true;
    //public Image iconImage;

    // Called to insert an item into the slot
    public void SetItem(InventoryItemData item)
    {
        //iconImage.sprite = item.itemIcon;
        //iconImage.enabled = true;
        //SlotFree = false;
    }

    // Optional: Clear the slot
    public void ClearSlot()
    {
        //iconImage.sprite = null;
        //iconImage.enabled = false;
        //SlotFree = true;
    }
}

