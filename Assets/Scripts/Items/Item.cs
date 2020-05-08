using UnityEngine;

[CreateAssetMenu(fileName="New item", menuName="Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New item";

	public Sprite icon = null;
	public bool isDefault = false;

    public virtual void Use(){
        // This uses the item
        // Something might happen... or not

        Debug.Log("<color=aqua>[ITEM] Usando: " + name + "</color>");
    }

    public void RemoveFromInventory(){
        Inventory.instance.RemoveItem(this);
    }
}
