using Photon.Pun;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    PhotonView photonView;

    public Item item;

    private void Start() {
        photonView = GetComponent<PhotonView>();
    }

    Inventory inventory;

    public void PickUp(){
        Debug.Log("<color=aqua>[ITEM] Recogiendo: " + item.name + "</color>");

        bool wasPicked = Inventory.instance.AddItem(item);

        if (wasPicked) {
            photonView.RPC("LocalSelfDestroy", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void LocalSelfDestroy() {
        GameObject.Destroy(gameObject);
    }
}
