﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (ChatGui))]
public class NamePickGui : MonoBehaviour
{
    public const string UserNamePlayerPref = "NamePickUserName";

    public ChatGui chatNewComponent;
    public PhotonManager photonManager;

    public InputField idInput;

    public void Start()
    {
        this.chatNewComponent = GetComponent<ChatGui>();
        this.photonManager = GetComponent<PhotonManager>();

        string prefsName = PlayerPrefs.GetString(NamePickGui.UserNamePlayerPref);
        if (!string.IsNullOrEmpty(prefsName))
        {
            this.idInput.text = prefsName;
        }
    }


    // new UI will fire "EndEdit" event also when loosing focus. So check "enter" key and only then StartChat.
    public void EndEditOnEnter()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.StartChat();
        }
    }

    public void StartChat()
    {
        ChatGui chatNewComponent = FindObjectOfType<ChatGui>();
        chatNewComponent.UserName = this.idInput.text.Trim();
		chatNewComponent.Connect();
        photonManager.GameConnect();
        enabled = false;

        PlayerPrefs.SetString(NamePickGui.UserNamePlayerPref, chatNewComponent.UserName);
    }
}