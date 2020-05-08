﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    public Button removeButton;

    Item item;

    public void setItem(Item newItem){
        item = newItem;

        icon.sprite = newItem.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void clearItem(){
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton(){
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem(){
        if (item != null)
            item.Use();
    }
}