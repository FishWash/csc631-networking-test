using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FighterGameLauncher : MonoBehaviourPunCallbacks {

	string gameVersion = "1.0";

	#region UNITY CALLBACKS

	void Awake() {
		PhotonNetwork.NetworkingClient.AddCallbackTarget(this);
	}

	void Start() {
		Connect();
	}

	#endregion

	#region PUN CALLBACKS

	override public void OnConnectedToMaster() {
		Debug.Log("CONNECTED TO MASTER!!");
		PhotonNetwork.JoinOrCreateRoom("Test", new Photon.Realtime.RoomOptions(), Photon.Realtime.TypedLobby.Default);
	}

	override public void OnJoinedRoom() {
		Debug.Log("JOINED ROOM!!");
		PhotonNetwork.Instantiate("Fighter", Vector3.zero, Quaternion.identity);
	}

	#endregion

	public void Connect() {
		PhotonNetwork.NetworkingClient.AppId = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
		PhotonNetwork.ConnectToBestCloudServer();
	}
}
