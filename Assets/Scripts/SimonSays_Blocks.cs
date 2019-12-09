using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays_Blocks : MonoBehaviour {

	public int block_Hit;
	public int value;

	public bool hit;

	// Use this for initialization
	void Start () {
		block_Hit = 0;
		hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Megapixel")) {
			block_Hit = value;
			hit = true;
			this.GetComponent<Renderer> ().material.color = Color.red;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Megapixel")) {
//			block_Hit = 5;
			hit = false;
			this.GetComponent<Renderer> ().material.color = Color.white;
		}

	}

}
