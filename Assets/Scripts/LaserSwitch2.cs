using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch2 : MonoBehaviour {

	public bool hasPlayer; 

	public string Y_Dink = "Fire4_P2";
	public string Y_MP = "Fire4_P1";
	public GameObject LaserHolder;

	// Use this for initialization
	void Start () {
		LaserHolder = GameObject.Find ("Laser_Holder");
	}

	// Update is called once per frame
	void Update () {


//		if (hasPlayer && Input.GetKeyDown("m") || hasPlayer && Input.GetButtonDown(Y_MP) || hasPlayer && Input.GetButtonDown(Y_Dink))                         // if the button collider is true and the player presses M
//		{
//			LaserHolder.GetComponent<TurnOnLaser> ().count = 3;
//		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("crate"))
		{
			hasPlayer = true;
			LaserHolder.GetComponent<TurnOnLaser> ().count = 3;
		}

	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("crate"))
		{
			hasPlayer = false;
		}
	}

}
