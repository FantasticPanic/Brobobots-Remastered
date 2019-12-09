using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mp_dialogue : MonoBehaviour {

	public GameObject box;

	public float time, totalTime;

	public bool timer;

	// Use this for initialization
	void Start () {
		time = 0;
		totalTime = 6f;

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
		if (other.CompareTag("Megapixel")){
			time = 0;
			box.SetActive(true);
			timer = true;
			Destroy (this.GetComponent<BoxCollider>());
		}

	}

	void OnTriggerExit(Collider other)
	{

//		if (other.CompareTag("Megapixel"))
//		{
////			hasPlayer = true;
////			control.GetComponent<SpriteRenderer>().enabled = false;
////			control.SetActive(false);
//			box.SetActive(false);
////			Debug.Log("Exited");
//		}
	}
}
