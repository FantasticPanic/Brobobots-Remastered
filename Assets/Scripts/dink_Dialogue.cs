using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class dink_Dialogue : MonoBehaviour {

	public GameObject box;

	public float time, totalTime;

	public bool timer;

	// Use this for initialization
	void Start () {
		time = 0;
		totalTime = 3.5f;

		timer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer) {
			time += Time.deltaTime * 0.8f;

			if (time > totalTime) {
				timer = false;
				box.SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Dink")){
			time = 0;
			box.SetActive(true);
			timer = true;
			Destroy (this.GetComponent<BoxCollider>());
		}

	}

	void OnTriggerExit(Collider other)
	{

//	if (other.CompareTag("Dink")){
//			box.SetActive(false);
//		}
	}

}
