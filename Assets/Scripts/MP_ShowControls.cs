using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_ShowControls : MonoBehaviour {

	public string show = "Select_P1";

	public GameObject controls;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton (show) || Input.GetKey (KeyCode.Q)) {
			controls.SetActive (true);
		} else {
			controls.SetActive (false);
		}
	}
}
