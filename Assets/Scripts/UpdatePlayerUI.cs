using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerUI : MonoBehaviourPun
{
    public Text RenderedUserName;

    private void Update() {
        Player owner = this.photonView.Owner;

        if (owner != null) {
            RenderedUserName.text = string.IsNullOrEmpty(owner.NickName) ? owner.UserId : owner.NickName;
        } else {
            RenderedUserName.text = "Un-named";
        }
    }

    /* void UpdateUserName() {
        // photonView.IsMine ---> Todos los clientes ejecutan el script
        //                        con isMine, la entrada de un cliente
        //                        permite que solo se ejecute en su instancia

        RenderedUserName.text = photonManager.GetComponent<ChatGui>().UserName;
    } */
}
