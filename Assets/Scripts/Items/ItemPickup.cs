using Photon.Pun;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

	public Item item;

    Inventory inventory;

    public void PickUp(){
        Debug.Log("<color=aqua>[ITEM] Recogiendo: " + item.name + "</color>");

        bool wasPicked = Inventory.instance.AddItem(item);

        if (wasPicked)
		    PhotonNetwork.Destroy( gameObject );
	}
}
