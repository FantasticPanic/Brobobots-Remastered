using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLaser : MonoBehaviour {

	public int count,totalCount;

	public GameObject laser1, laser2, laser3;

	// Use this for initialization
	void Start () {
		laser1 = GameObject.Find ("Laser1");
		laser2 = GameObject.Find ("Laser2");
		laser3 = GameObject.Find ("Laser3");

		laser1.SetActive (false);
		laser2.SetActive (false);
		laser3.SetActive (false);

		count = 0;
		totalCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 1) {
			laser1.SetActive (true);
//			totalCount++;
			plusOne();
		}

		if (count == 2) {
			laser2.SetActive (true);
//			totalCount++;
			plusOne();
		}

		if (count == 3) {
			laser3.SetActive (true);
//			totalCount++;
			plusOne();
		}

		Debug.Log (totalCount);


	}

	void plusOne(){
		totalCount ++;
	}
}
