using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb2d;
	bool isJumping, aux;
	public bool catInDanger;
	public Vector2 JumpHeight;



	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		isJumping = false;
		aux = false;
		catInDanger = false;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Floor") {
			anim.SetBool ("jumping", false);
		}
		if (coll.gameObject.tag == "Object") {
			catInDanger = true;
		}
			
	}

	IEnumerator JumpSystem(){
		if (Input.GetKeyDown (KeyCode.Z) && isJumping == false && aux == false) {
			rb2d.AddForce (JumpHeight, ForceMode2D.Impulse);
			anim.SetBool ("jumping", true);
			isJumping = true;
			aux = true;
		} 
		else if (isJumping == true && aux == true) 
		{
			isJumping = false;
			yield return new WaitForSeconds (0.7f);
			aux = false;
		}
			
	}

	void JumpSystemAtWork()
	{
		StartCoroutine (JumpSystem ());
	}

	void FixedUpdate()
	{
		JumpSystemAtWork ();
	}


			

	void Update () {
		
	}
}
