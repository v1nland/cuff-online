using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Transform PlayerCameraPrefab;

    public void GameConnect() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {  MaxPlayers = 4 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        // instantiate player
        GameObject player = PhotonNetwork.Instantiate("Player_Witch", transform.position, Quaternion.identity);
        // instantiate player camera
        GameObject playerCamera = Instantiate(PlayerCameraPrefab, transform.position, Quaternion.identity).gameObject;
        // follow player with the camera
        playerCamera.GetComponent<BasicCameraFollow>().followTarget = player.transform;
        // set player camera to followMousePosition component
        player.GetComponentInChildren<FollowMousePosition>().playerCamera = playerCamera.GetComponent<Camera>();
    }
}
