using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject gameOverP, player, background;
	public int score;
	public Text scoreText;
	public int arrowKeyVar;
	public float objectSpeed;

	void Start () {
		Time.timeScale = 1;
		gameOverP.SetActive (false);
		arrowKeyVar = 0;

	}

	void SetScoreTextValue(){
		scoreText.text = score.ToString ();
	}

	public void RestartButton(){
		SceneManager.LoadScene ("RunCat");
	}
	public void QuitButton(){
		Application.Quit ();
	}
	void SetGameOver(){
		if (player.GetComponent<PlayerScript> ().catInDanger == true) {
			gameOverP.SetActive (true);
			Time.timeScale = 0;
		}
	}

	void ChangeArrowKeyVar(){
		if (Input.GetKeyDown (KeyCode.LeftArrow) && arrowKeyVar > -3 && arrowKeyVar <= 3) {
			arrowKeyVar--;
		} else if (Input.GetKeyDown (KeyCode.RightArrow) && arrowKeyVar >= -3 && arrowKeyVar < 3) {
			arrowKeyVar++;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && arrowKeyVar == -3) {
			arrowKeyVar = 3;
		} else if (Input.GetKeyDown (KeyCode.RightArrow) && arrowKeyVar == 3) {
			arrowKeyVar = -3;
		}
	}
	void SetSpeedGame(){
		switch (arrowKeyVar) {
		case 0:
			background.GetComponent<Scrolling> ().speed = 3.5f;
			objectSpeed = 250;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.5f);
			break;
		case 1:
			background.GetComponent<Scrolling> ().speed = 3.5f / 1.3f;
			objectSpeed = 250 * 1.3f;
			break;
		case 2:
			background.GetComponent<Scrolling> ().speed = 3.5f / 1.5f;
			objectSpeed = 250 * 1.5f;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.8f);
			break;
		case 3:
			background.GetComponent<Scrolling> ().speed = 3.5f / 2f;
			objectSpeed = 250 * 2f;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.8f);
			break;
		case -1:
			background.GetComponent<Scrolling> ().speed = 3.5f / 1.3f;
			objectSpeed = 250 * 1.3f;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.8f);
			break;
		case -2:
			background.GetComponent<Scrolling> ().speed = 3.5f / 1.5f;
			objectSpeed = 250 * 1.5f;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.8f);
			break;
		case -3:
			background.GetComponent<Scrolling> ().speed = 3.5f / 2f;
			objectSpeed = 250f * 2f;
			player.GetComponent<PlayerScript> ().JumpHeight = new Vector2 (0, 5.8f);
			break;
		}
	}

	void Update () {
		SetGameOver ();
		SetScoreTextValue ();
		ChangeArrowKeyVar ();
		SetSpeedGame ();
	}
}
