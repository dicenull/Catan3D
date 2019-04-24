using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PunNetwork : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
		PhotonNetwork.ConnectUsingSettings();
    }
	
	public override void OnConnectedToMaster()
	{
		PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("join");
	}
}
