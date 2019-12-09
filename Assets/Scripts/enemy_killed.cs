using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_killed : MonoBehaviour {

//	public Collider[] attackHitboxes;

//	public float hitforce;

//	bool left,right,up,down;

	int hitCounter;

	GameObject MP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hitCounter > 4) {
//			Destroy (gameObject);
			this.enabled = false;
		}
	}


	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Megapixel")){

			Debug.Log("CONTACT FOR HIT");

			if (Input.GetKeyDown(KeyCode.C)) {
//				hitCounter++;
//				Debug.Log ("Hit + 1");
				this.enabled = false;
			}
		}

	}

//	void OnTriggerExit(Collider other)
//	{
//
//		if (other.CompareTag("Dink")){
//			box.SetActive(false);
//		}
//	}
}
