using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Three_Lasers : MonoBehaviour {

	public string Y_Dink = "Fire4_P2";
	public string Y_MP = "Fire4_P1";
	public int scene;
	public bool hasplayer;

	GameObject laser;

	// Use this for initialization
	void Start () {
		laser = GameObject.Find ("Laser_Holder");
	}
	
	// Update is called once per frame
	void Update () {
		if (laser.GetComponent<TurnOnLaser> ().totalCount >= 3) {

			if (hasplayer && Input.GetKeyDown ("m") || hasplayer && Input.GetButtonDown (Y_MP) || hasplayer && Input.GetButtonDown (Y_Dink)) {
				SceneManager.LoadScene (scene);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Megapixel") || other.gameObject.CompareTag ("Dink")) {
			hasplayer = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Megapixel") || other.gameObject.CompareTag ("Dink")) {
			hasplayer = false;
		}

	}
}
