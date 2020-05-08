using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

	public int maximumSlots = 10;
    private float lastPressed;

    public static Inventory instance;

    void Awake(){
        instance = this;
        lastPressed = Time.time;
    }

    // THIS LET US PICKUP ITEMS
    void OnTriggerStay2D(Collider2D other){
        if (other.GetComponent<ItemPickup>() != null && lastPressed != Time.time){
            Debug.Log("<color=red>[INVENTORY] Usa E para recoger: " + other.GetComponent<ItemPickup>().item.name + "</color>");

            if (Input.GetKeyDown(KeyCode.E)){
                lastPressed = Time.time;
                other.GetComponent<ItemPickup>().PickUp();
            }
        }
    }

    public bool AddItem(Item item){
        if(items.Count < maximumSlots){
            items.Add( item );
            Debug.Log("<color=red>[INVENTORY] Agregado: " + item.name + "</color>");

            if ( onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            return true;
        }else{
            Debug.Log("<color=red>[INVENTORY] No hay espacio para recoger: " + item.name + "</color>");

            return false;
        }
    }

    public void RemoveItem(Item item){
        items.Remove(item);
        Debug.Log("<color=red>[INVENTORY] Removido: " + item.name + "</color>");

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
