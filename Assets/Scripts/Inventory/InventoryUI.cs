using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;
    InventorySlot[] inventorySlots;

    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            inventoryUI.SetActive( !inventoryUI.activeSelf );
        }
    }

    void UpdateUI() {
        Debug.Log("<color=red>[INVENTORY] Updating UI</color>");

        for (int i = 0; i < inventorySlots.Length; i++){
            if(i < inventory.items.Count){
                inventorySlots[i].setItem( inventory.items[i] );
            }else{
                inventorySlots[i].clearItem();
            }
        }
    }
}
