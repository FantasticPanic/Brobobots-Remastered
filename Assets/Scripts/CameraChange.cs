using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {





	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Dink"))
		{
			Quaternion target = Quaternion.Euler (new Vector3 (0, -90f, 0));
			other.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);//new Vector3 (0, -90f, 0);
//			foreach (enemyAI bot in bots) {
//				bot.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);//new Vector3 (0, -90f, 0);
//			}

		}


	}


	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("Dink"))
		{
			Quaternion target = Quaternion.Euler (new Vector3 (0, 0, 0));
			other.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);//new Vector3 (0, -90f, 0);
//			foreach (enemyAI bot in bots) {
//				bot.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);//new Vector3 (0, -90f, 0);
//			}
		}
	}
}
