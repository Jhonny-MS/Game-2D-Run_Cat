using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {


	private Rigidbody2D rb2d;
	public int scoreValue;
	private GameObject gameC;

	public enum Type {cactus1, cactus2, cactus3, cactus4, goodItem, badItem}
	public Type tipe = new Type ();


	public void MoveTheObject(){
		rb2d.AddForce (Vector2.left * gameC.GetComponent<GameController> ().objectSpeed);
	}

	void Start () {
		gameC = GameObject.Find ("GameController");
		rb2d = GetComponent<Rigidbody2D> ();
		MoveTheObject ();
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			gameC.GetComponent<GameController> ().score = gameC.GetComponent<GameController> ().score + scoreValue;
			GetComponent<BoxCollider2D> ().enabled = false;
		}
	}

	void Update () {
		
	}
}
