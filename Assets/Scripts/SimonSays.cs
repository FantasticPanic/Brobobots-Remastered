using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour {

	public GameObject top,left,bottom,right;

	Collider topCol,bottomCol,leftCol,rightCol;

	public Renderer rend;

	public GameObject LaserHolder;

	private Animator anim; 
//	SimonSays_Blocks block;

	public float time, time2,time3;
	public float standTime;

	bool stopSequence;

	// Use this for initialization
	void Start () {
//		rend = GetComponent<Renderer> ();

		top.GetComponent<Renderer> ().material.color = Color.white;
		left.GetComponent<Renderer> ().material.color = Color.white;
		bottom.GetComponent<Renderer> ().material.color = Color.white;
		right.GetComponent<Renderer> ().material.color = Color.white;

		standTime = 3f;

		topCol = top.GetComponent<Collider>();
		bottomCol = bottom.GetComponent<Collider>();
		leftCol = left.GetComponent<Collider>();
		rightCol = right.GetComponent<Collider>();

		stopSequence = false;

		anim = GetComponent<Animator>();

		LaserHolder = GameObject.Find ("Laser_Holder");
	}
	
	// Update is called once per frame
	void Update () {
//		rend.material.color = Color.red;
		if (!stopSequence) {
			sequence1 ();
		} else {
			checkSequence1 ();
		}
//		top.GetComponent<Renderer> ().material.color = Color.red;
//		left.GetComponent<Renderer> ().material.color = Color.green;
//		bottom.GetComponent<Renderer> ().material.color = Color.blue;
//		right.GetComponent<Renderer> ().material.color = Color.yellow;



	}

	void OnTriggerEnter(Collider other)
	{
//		if (other.gameObject.CompareTag ("simon1")) {
//		if (topCol.isTrigger) {
//			Debug.Log ("Cube was hit");
////			this.GetComponent<Renderer> ().material.color = Color.red;
////			left.GetComponent<Renderer> ().material.color = Color.green;
////			bottom.GetComponent<Renderer> ().material.color = Color.blue;
////			right.GetComponent<Renderer> ().material.color = Color.yellow;
//		}

		if (other.gameObject.CompareTag ("Megapixel")) {
//			Debug.Log ("Cube was hit");
			stopSequence = true;
			//			this.GetComponent<Renderer> ().material.color = Color.red;
			//			left.GetComponent<Renderer> ().material.color = Color.green;
			//			bottom.GetComponent<Renderer> ().material.color = Color.blue;
			//			right.GetComponent<Renderer> ().material.color = Color.yellow;
			top.GetComponent<Renderer> ().material.color = Color.white;
			left.GetComponent<Renderer> ().material.color = Color.white;
			bottom.GetComponent<Renderer> ().material.color = Color.white;
			right.GetComponent<Renderer> ().material.color = Color.white;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Megapixel")) {
//			top.GetComponent<Renderer> ().material.color = Color.white;
//			left.GetComponent<Renderer> ().material.color = Color.white;
//			bottom.GetComponent<Renderer> ().material.color = Color.white;
//			right.GetComponent<Renderer> ().material.color = Color.white;
			stopSequence = false;
		}
	}

	void sequence1(){
		time += Time.deltaTime * 1.6f;
		if (time < standTime) {
			left.GetComponent<Renderer> ().material.color = Color.green;
		} else if (time > standTime) {
			left.GetComponent<Renderer> ().material.color = Color.white;

			time2 += Time.deltaTime * 1.6f;
			if (time2 < standTime) {
				right.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (time2 > standTime) {
				right.GetComponent<Renderer> ().material.color = Color.white;

				time3 += Time.deltaTime * 1.6f;
				if (time3 < standTime) {
					bottom.GetComponent<Renderer> ().material.color = Color.blue;
				} else if (time3 > standTime) {
					bottom.GetComponent<Renderer> ().material.color = Color.white;

					time = 0;
					time2 = 0;
					time3 = 0;
				}
			}
		}


	}



	void checkSequence1 (){
		
		if (left.GetComponent<SimonSays_Blocks> ().block_Hit == 4){
//			Debug.Log ("LEFT HIT");
			left.GetComponent<Renderer> ().material.color = Color.green;

			if (right.GetComponent<SimonSays_Blocks> ().block_Hit == 2){
//				Debug.Log ("LEFT HIT");
				right.GetComponent<Renderer> ().material.color = Color.yellow;
//				left.GetComponent<SimonSays_Blocks> ().block_Hit == 0;

				if (bottom.GetComponent<SimonSays_Blocks> ().block_Hit == 3){
//					Debug.Log ("LEFT HIT");
					bottom.GetComponent<Renderer> ().material.color = Color.blue;
					Debug.Log ("OPEN DOOR");
//					anim.SetBool("Doorbtn",true);

					LaserHolder.GetComponent<TurnOnLaser> ().count = 1;
				}

			}


		}
	}
}
