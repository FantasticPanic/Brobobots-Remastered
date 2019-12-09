using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpPunch : MonoBehaviour {

	public GameObject mp;

	GameObject bot;

	public float dist;
	public float hitForce;

	// Use this for initialization
	void Start () {
		bot = GameObject.FindWithTag ("CopBot");
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (mp.transform.position, bot.transform.position) < dist) {
			if(Input.GetKeyDown(KeyCode.C)){
				Debug.Log ("Punch is punched");

//				bot.GetComponent<Rigidbody> ().AddForce (mp.GetComponent<Rigidbody>().transform.forward * hitForce);
				bot.GetComponent<Rigidbody> ().AddForce (mp.GetComponent<Rigidbody>().transform.forward * hitForce);
			}
		}

	}
}
