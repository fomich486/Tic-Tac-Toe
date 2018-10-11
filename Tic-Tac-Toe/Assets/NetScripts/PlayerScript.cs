using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {
	[SyncVar]
	public string side;
	[SyncVar]
	public int score = 0;
	[SyncVar]
	public bool canTurn = false;
	[SyncVar]
	public bool readyToRematch;
	netController controller;
	void Start () {
		NetworkIdentity identety = GetComponent<NetworkIdentity>();
		controller = FindObjectOfType<netController> ();
		if (isLocalPlayer)
			controller.CurrentPlayer = this;
	}

	[Command]
	public void Cmd_Send(GameObject gam)
	{
		//print ("CMD " + gam.name);
		Rpc_Send (gam);
	}
	[ClientRpc]
	public void Rpc_Send(GameObject g)
	{
		//print ("RPCSend " + g.name);
		controller.SetButton (g, side);
	}

}
