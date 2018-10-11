using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Controller :MonoBehaviour {
	const int size = 3;
	[SerializeField]
	List<Text> txt;
	[SerializeField]
	Image gameOver;
	[SerializeField]
	Text gameOverText;
	void Start () {
		GameStart ();
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
		if(side != "DRAW!")
			side = side + " Wins!";
		foreach (Text t in txt) {
			t.GetComponentInParent<Button>().interactable = false;
		}
		gameOver.gameObject.SetActive (true);
		gameOverText.text = side;
	}
	void GameStart()
	{
		gameOver.gameObject.SetActive (false);
		foreach (Text t in txt) {
			t.GetComponentInParent<Button> ().interactable = true;
			t.text = " ";
		}
	}

	public void Restart()
	{
		GameStart ();
	}

	bool NoButtonInteractable()
	{
		bool check = false;
		for (int i = 0; i < txt.Count; i++) {
			if (txt [i].GetComponentInParent<Button> ().interactable) {
				check = false;
				break;
			}
			check = true;
		}
		return check;
	}
}
