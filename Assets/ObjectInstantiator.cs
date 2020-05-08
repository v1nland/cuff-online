using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    void InstantiateObjectOnServer( Item item )
    {
        GameObject instantiatedItem = PhotonNetwork.Instantiate("Collectable", new Vector3(0, 0, 0), Quaternion.identity, 0);
        instantiatedItem.GetComponent<ItemPickup>().item = item;
    }
}
