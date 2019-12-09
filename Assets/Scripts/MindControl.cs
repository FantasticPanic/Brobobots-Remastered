using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class MindControl : MonoBehaviour {

	GameObject Dink;
	GameObject splitscreen;

	Camera enemyCamera;

	public string MCButton = "Fire2_P2";


	public playerMove_Dink player;

    public AudioSource ctrlAudio;    

	bool controlled;
//	bool moveCam;

	Sprite sprite;

	GameObject controlBot;
	enemyAI[] bots;
	GameObject currentBot;

	public float distance;

	public float rayDistance;

	public float time;
	public float ControlTime;

	int MinDist;

	// Use this for initialization
	void Start () {
//		Dink = GameObject.FindWithTag ("Dink");
		Dink = this.gameObject;
		this.GetComponent<playerMove_Dink> ().controlAI = false;
		time = 0;

		bots = FindObjectsOfType<enemyAI> ();

		MinDist = 2;

//		moveCam = false;
		splitscreen = GameObject.Find("SplitScreen");

        ctrlAudio = GetComponent<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        ctrlAudio = audios[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (controlled) {
			mindControlBot (controlBot);
			checkDrop ();
		} else {
			canControl ();
		}

//		if (moveCam) {
////			Debug.Log ("HELOOW");
//			enemyCamera = GetComponentInChildren<enemyCam> ().GetComponent<Camera> ();
//
//			Vector3 newPos = enemyCamera.transform.position - Dink.GetComponentInChildren<DinkCamera> ().GetComponent<Camera> ().transform.position;
//			newPos = newPos.normalized;
//
//			transform.Translate (newPos.x * Time.deltaTime * 3f, 
//				newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);
//		}
	}

	void mindControlBot(GameObject g){
		g.GetComponent<enemyAI> ().mindControl = true;
		g.GetComponent<enemyAI> ().canMove = false;
		this.GetComponent<playerMove_Dink>().controlAI = true;
		this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

		Quaternion target = Quaternion.Euler (new Vector3 (0, 0, 0));
		this.transform.rotation = target;



		if(controlled == false){
			g.GetComponent<enemyAI> ().mindControl = false;
		}
	}

	void canControl(){
//		if (Input.GetKeyDown (KeyCode.K)) {
		if (Input.GetButtonDown (MCButton)) {

			foreach (enemyAI bot in bots) {
//				RaycastHit hit;
//			Ray ray = new Ray (Dink.transform.position, Vector3.right); //shoot ray infront of Dink
//				Ray ray = new Ray (Dink.transform.position, Vector3.left);
				if (bot != null) {
					if (Vector3.Distance (transform.position, bot.transform.position) <= MinDist) { //Physics.Raycast (ray, out hit, rayDistance)
//					Debug.Log ("K was pressed");

//					canBeControlled b = hit.collider.GetComponent<canBeControlled> ();

//					if (b != null) {
						controlled = true;
						ctrlAudio.Play ();
						controlBot = bot.gameObject;
						splitscreen.GetComponent<voronoi_Split> ().player2 = bot.transform;
//					bot.moveCamera = true;


//					moveCamera = true;


//					this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;	
//					b.gameObject.GetComponent<Rigidbody>().isKinematic = true;
//					}
					}
				} 

				if (bot == null) {
					time = 0;

					Dink.GetComponent<playerMove_Dink> ().controlAI = false;

					Dink.GetComponentInChildren<DinkCamera> ().GetComponent<Camera> ().enabled = true;

					splitscreen.GetComponent<voronoi_Split> ().player2 = Dink.transform;

					this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
					bot.GetComponent<enemyAI> ().mindControl = false;
					bot.GetComponent<enemyAI> ().canMove = true;
					//		g.GetComponent<enemyAI> ().moveCamera = false;
					// 		g.GetComponent<Camera> ().enabled = false;


					bot.GetComponentInChildren<enemyCam>().GetComponent<Camera>().enabled = false;


					controlled = false;
				}
			}
		}
	}


	void checkDrop(){
		time += Time.deltaTime;
//		if (time >= ControlTime || Input.GetKeyDown (KeyCode.K)) { //Input.GetKeyDown (KeyCode.U)
		if (time >= ControlTime || Input.GetButtonDown (MCButton)) { //Input.GetKeyDown (KeyCode.U)
			normalAI (controlBot);
		}
	}

	void normalAI(GameObject g){
		time = 0;

		Dink.GetComponent<playerMove_Dink> ().controlAI = false;

		Dink.GetComponentInChildren<DinkCamera> ().GetComponent<Camera> ().enabled = true;

		splitscreen.GetComponent<voronoi_Split> ().player2 = Dink.transform;

		this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		g.GetComponent<enemyAI> ().mindControl = false;
		g.GetComponent<enemyAI> ().canMove = true;
//		g.GetComponent<enemyAI> ().moveCamera = false;
// 		g.GetComponent<Camera> ().enabled = false;


		g.GetComponentInChildren<enemyCam>().GetComponent<Camera>().enabled = false;


		controlled = false;
	}


}
