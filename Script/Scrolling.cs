using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public Renderer aux;
	public float speed;

	void Start () {
		
	}
	

	void Update () {
		Vector2 offset = new Vector2 (Time.time / speed, 0);
		aux.material.mainTextureOffset = offset;
	}
}
