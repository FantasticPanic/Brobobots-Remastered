using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour {
	public Material m;
	//public Material red;
	//public Material green;
	//public Material blue;
	//public Material yellow;

	public Rigidbody player;

	// Use this for initialization
	void Start () {
		m = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			m.color = Color.green;
		}

		if (Input.GetKey (KeyCode.W)) {
			m.color = Color.red;
		}

		if (Input.GetKey (KeyCode.S)) {
			m.color = Color.blue;
		}

		if (Input.GetKey (KeyCode.D)) {
			m.color = Color.yellow;
		}
	}



}
