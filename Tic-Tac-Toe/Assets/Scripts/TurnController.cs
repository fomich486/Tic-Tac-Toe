using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour {
	string side ="X";
	[SerializeField]
	Text turn;
	Controller controller;
	void Start () {
		controller = GetComponent<Controller> ();  
		turn.text = side + " turn";
	}
	
	public void OnFieldClick(Button b)
	{
		b.GetComponentInChildren<Text>().text = side;
		b.interactable = false;
		SwitchSides ();
	}
	void SwitchSides()
	{
		controller.CheckForWin (side);
		side = side == "X" ? "O":"X";
		turn.text = side + " turn";
	}
}
