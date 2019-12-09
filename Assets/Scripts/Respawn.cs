using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

//	public GameObject Dink, MP;
	public GameObject player;
	public GameObject spawnPoint;

	public float health;
	public bool isDead;


	// Use this for initialization
	void Start () {
		player = this.gameObject;


		isDead = this.gameObject.GetComponent<HealthBar> ().isDead;
		health = this.gameObject.GetComponent<HealthBar> ().hitPoint;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y <= 2.5) {
//			Dink.transform.position = new Vector3 (0,0,0);
//			Dink.transform.position = new Vector3(-83.94f,6.79f,-4.4f);
//			Dink.transform.position = new Vector3(55.02f,5.5f,37.11f);
//			killed();
//			isDead = true;
			this.gameObject.GetComponent<HealthBar>().isDead = true;
			this.gameObject.GetComponent<HealthBar>().Death();
			this.gameObject.GetComponent<HealthBar> ().hitPoint = 100f;
		} 

//		if (health < 0) {
//			killed ();
////			health = 100;
//		}


//		if (player.transform.position.y <= 2) {
//			//Dink.transform.position = new Vector3 (0,0,0);
////			MP.transform.position = new Vector3(-92.45999f,7.14f,-4.3f);
//			player.transform.position = new Vector3(55.85f,5.5f,40.46f);
//		}
	}


	public void killed(){
		player.transform.position = spawnPoint.transform.position;
//		health = 100f;
	}
}
