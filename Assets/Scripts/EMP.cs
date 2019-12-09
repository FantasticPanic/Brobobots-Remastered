using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Timers;


public class EMP : MonoBehaviour {

	enemyAI[] bots;
	ParticleSystem exp;
	enemyAI enemy;
	bool canMoveAI;
	bool EMPHit;
	Vector3[] enemy_transform;
	GameObject Dink;
	int MinDist;

	public string EMPButton = "Fire1_P2";

	public float time;
	public float totalTime;

	public float cool_time, cool_totalTime;

	bool coolDown;

	bool frozen;


	// Use this for initialization
	void Start () {
		MinDist = 3;

		time = 0;

		bots = FindObjectsOfType<enemyAI> ();

		enemy = Object.FindObjectOfType<enemyAI>();

		Dink = GameObject.FindGameObjectWithTag ("Dink");
		frozen = false;

		exp = GetComponent<ParticleSystem> ();
		exp.Stop ();

		totalTime = 18f;

		cool_totalTime = 3f;
		cool_time = 0;

		coolDown = false;

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (cool_time);



		if (!coolDown) {
			foreach (enemyAI bot in bots) {


			
				if (Vector3.Distance (transform.position, bot.transform.position) <= MinDist) {
//					if (Input.GetKeyDown (KeyCode.J)) {
					if (Input.GetButtonDown (EMPButton)) {
//					Debug.Log ("J is pressed");

//					time += Time.deltaTime;

						bot.GetComponent<enemyAI> ().canMove = false;
						time = 0;
						cool_time = 0;
						frozen = true;
					
						exp.Play ();

						coolDown = true;
					}

				} 
			
//				if (frozen) {
//					time += Time.deltaTime * 0.2f;
//
//					if (time > totalTime) {
//						bot.GetComponent<enemyAI> ().canMove = true;
//
//					}
//				}
			}
		}

		foreach (enemyAI bot in bots) {
			if (frozen) {
				time += Time.deltaTime * 0.2f;

				if (time > totalTime) {
					bot.GetComponent<enemyAI> ().canMove = true;

				}
			}
		}

		if (coolDown) {
			cool_time += Time.deltaTime * 0.2f;

			if (cool_time > cool_totalTime) {
				coolDown = false;
			}
		}
	}
}
