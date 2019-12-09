using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

	public Rigidbody Box;
	public Transform droppoint;

	public string Y_Dink = "Fire4_P2";
	public string Y_MP = "Fire4_P1";

	public bool hasPlayer; 
	public bool dropBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Input.GetKeyDown (KeyCode.T)) {
//			Rigidbody box = Instantiate (Box, box1.position, box1.rotation) as Rigidbody;
//		}
//
//		if (Input.GetKeyDown (KeyCode.Y)) {
//			Rigidbody box = Instantiate (Box, box2.position, box2.rotation) as Rigidbody;
//		}
//
//		if (Input.GetKeyDown (KeyCode.U)) {
//			Rigidbody box = Instantiate (Box, box3.position, box3.rotation) as Rigidbody;
//		}
		if (hasPlayer && Input.GetKeyDown("m") || hasPlayer && Input.GetButtonDown(Y_Dink))                         // if the button collider is true and the player presses M
		{
//			anim.SetBool("Doorbtn",true);    // locked door animation will now play
//			playerAudio.Play();
			Rigidbody box = Instantiate (Box, droppoint.position, droppoint.rotation) as Rigidbody;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("DROP THE BOX");
		if (other.CompareTag("Dink"))
		{
			hasPlayer = true;
		}

	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("Dink"))
		{
			hasPlayer = false;
		}
	}

}
