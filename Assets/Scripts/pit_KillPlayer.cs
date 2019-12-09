using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pit_KillPlayer : MonoBehaviour {

	public bool Dink_Dead,MP_Dead; 

	public GameObject Dink,MP;

	// Use this for initialization
	void Start () {
		Dink_Dead = false;
		MP_Dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Dink_Dead) {                                 // if the button collider is true and the player presses E
			Dink.GetComponent<Respawn>().killed();
			Dink_Dead = false;
		}


		if (MP_Dead) {                                 // if the button collider is true and the player presses E
			MP.GetComponent<Respawn>().killed();
			MP_Dead = false;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		//		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Dink"))
		{
			Dink_Dead = true;
		}


		if (other.CompareTag("Megapixel"))
		{
			MP_Dead = true;
		}

	}

	void OnTriggerExit(Collider other)
	{

//		if (other.CompareTag("Dink")  || other.CompareTag("Megapixel"))
//		{
//			hasPlayer = false;
//		}
	}
}
