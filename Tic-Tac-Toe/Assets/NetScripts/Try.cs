using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour {
	[SerializeField]
	GameObject StartField;

	void Update () {
		PlayerScript [] ps = FindObjectsOfType<PlayerScript> ();
		if (ps.Length == 2) {
			ps[0].side = "X";
			ps [0].canTurn = true;
			ps[1].side = "O";
			ps [1].canTurn = false;
			GetComponent<netController> ().SetScore ();
			StartField.SetActive (false);
			enabled = false;
		}
	}
}
