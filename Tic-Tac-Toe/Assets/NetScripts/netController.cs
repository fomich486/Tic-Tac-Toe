using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class netController : MonoBehaviour {

	[SerializeField]
	List<Text> txt;
	[SerializeField]
	GameObject gameOver;
	[SerializeField]
	Text txt_gameOver;
	[SerializeField]
	Text xScore;
	[SerializeField]
	Text oScore;

	private PlayerScript _currentPlayer;
	public PlayerScript CurrentPlayer
	{
		get{ return _currentPlayer;}
		set{ _currentPlayer = value;}
	}
	public void Send(GameObject g)
	{
		//print ("1Send" + g.name);
		if(CurrentPlayer.canTurn)
			CurrentPlayer.Cmd_Send (g);
	}
	public void SetButton(GameObject g,string s)
	{
		//print (g.name);
		PlayerScript [] ps = FindObjectsOfType<PlayerScript> ();
		ps [0].canTurn = !ps [0].canTurn;
		ps [1].canTurn = !ps [1].canTurn;
		Button b = g.GetComponent<Button> ();
		b.GetComponentInChildren<Text>().text = s;
		b.interactable = false;
		CheckForWin (s);
	}
	public void CheckForWin(string side)
	{
		//draw
		if (NoButtonInteractable ()) {
			GameOver("DRAW!");
		}
		//row Check
		if (txt [0].text == side && txt [1].text == side && txt [2].text == side) {
			GameOver (side);

		}
		if (txt [3].text == side && txt [4].text == side && txt [5].text == side) {
			GameOver (side);

		}
		if (txt [6].text == side && txt [7].text == side && txt [8].text == side) {
			GameOver (side);

		}
		//colum
		if (txt [0].text == side && txt [3].text == side && txt [6].text == side) {
			GameOver (side);

		}
		if (txt [1].text == side && txt [4].text == side && txt [7].text == side) {
			GameOver (side);

		}
		if (txt [2].text == side && txt [5].text == side && txt [8].text == side) {
			GameOver (side);

		}
		//Diagonals
		if (txt [0].text == side && txt [4].text == side && txt [8].text == side) {
			GameOver (side);

		}
		if (txt [6].text == side && txt [4].text == side && txt [2].text == side) {
			GameOver (side);
		}
	}

	void GameOver(string side)
	{
		if (side != "DRAW!") {
			PlayerScript [] ps = FindObjectsOfType<PlayerScript> ();
			if (ps [0].side == side) {
				ps [0].score++;
			}
			else if(ps [1].side == side){
				ps [1].score++;
				}
			side = side + " Wins!";
		}
		foreach (Text t in txt) {
			t.GetComponentInParent<Button>().interactable = false;
		}
		print ("SideWins = "+ side);
		gameOver.SetActive (true);
		txt_gameOver.text = side;
		SetScore ();
	}

	bool NoButtonInteractable()
	{
		bool check = false;
		for (int i = 0; i < txt.Count; i++) {
			if (txt [i].text == "") {
				check = false;
				break;
			}
			check = true;
		}
		return check;
	}
	public void SetScore()
	{
		PlayerScript [] ps = FindObjectsOfType<PlayerScript> ();
		if (ps [0].side == "X") {
			xScore.text = "X score: " + ps [0].score;
			oScore.text = "O score: " + ps [1].score;
		} else if (ps [0].side == "O") {
			xScore.text = "X score: " + ps [1].score;
			oScore.text = "O score: " + ps [0].score;
		}
	}
	public void RestartClick()
	{
		gameOver.SetActive (false);
		foreach (Text t in txt) {
			t.GetComponentInParent<Button> ().interactable = true;
			t.text = "";
		}
	}
}
