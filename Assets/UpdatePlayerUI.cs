using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerUI : MonoBehaviour
{
    PhotonManager photonManager;
    public Text RenderedUserName;

    void Start()
    {
        photonManager = GameObject.FindObjectOfType<PhotonManager>();
    }

    void Update()
    {
        RenderedUserName.text = photonManager.GetComponent<ChatGui>().UserName;
    }
}
