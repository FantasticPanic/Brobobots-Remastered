using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI_COPY : MonoBehaviour {

	GameObject test;

	public Material m;

	public Transform Player;

	public GameObject Dink;

	public float speed;
	int MoveSpeed = 3;
	int MaxDist = 2;
	int MinDist = 5;

	public bool canMove;

	public bool mindControl;

	GameObject RobotCamera;
	GameObject DinkCam;

	private bool CamDink;
	private bool CamBot;

	// Use this for initialization
	void Start () {
		//		m = GetComponent<Renderer> ().material;
		speed = Random.Range(0.3f, 1f);
		canMove = true;
		mindControl = false;

		//		Dink = GameObject.FindGameObjectWithTag ("Dink");

		//		botCam = this.GetComponent<Camera> ();//.enabled = false;
		//		botCam = GameObject.FindGameObjectWithTag("BotCam");
		//		CamBot = GetComponentInChildren<Camera>().enabled = false;
		DinkCam = GameObject.FindGameObjectWithTag ("dinkCam");//.GetComponent<Camera> ();//.enabled = true;
		CamBot = false;
		CamDink = true;

		this.GetComponent<Camera> ().transform.position = this.transform.position;//new Vector3 (-1.18f,24.54f,-10.77f);

		//ASSING DINK AND MP VALUES OF 1 OR 2 AND HAVE AI CHASE WHATEVER IS CLOSER
	}

	// Update is called once per frame
	void Update () {

		if (mindControl) {
			//			BotCamera ();
			//			botCam.SetActive(true);
			//			DinkCam.SetActive (false);
			//			BotCamera();
			//			CamBot = GetComponentInChildren<Camera>().enabled = true;

			//			GameObject.Find ("BotCam").GetComponent<Camera> ().enabled = true;
			//			test = this.GetComponentInChildren<BotCam>


			transform.rotation = Quaternion.identity;
			//Walk left 
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (Vector3.left * speed * Time.deltaTime); 
			}

			//Walk right
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}

			//Walk down
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (Vector3.back * speed * Time.deltaTime);
			}

			//Walk up
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}

		} else if (!mindControl || (this.GetComponent<Rigidbody>() == null)) {
			//			DinkCamera ();
			//			botCam.SetActive(false);
			//			DinkCam.SetActive (true);
			//			DinkCamera();

			if (canMove) {
				//				transform.LookAt (Player);

				if (Vector3.Distance (transform.position, Player.position) <= MinDist) {

					Vector3 localPos = Player.transform.position - transform.position ;//+ new Vector3(Random.Range(Random.Range(-0.5f,-0.3f),Random.Range(0.5f,0.3f)),
					//Random.Range(Random.Range(-0.5f,-0.3f),Random.Range(0.5f,0.3f)),Random.Range(Random.Range(-0.5f,-0.3f),Random.Range(0.5f,0.3f)));

					localPos = localPos.normalized;

					transform.Translate(localPos.x * Time.deltaTime * speed, 
						localPos.y * Time.deltaTime * speed, localPos.z * Time.deltaTime * speed);


					//					Dink.GetComponent<playerMove_Dink> ().controlAI = false;


					//
					//					transform.position += transform.forward * MoveSpeed * Time.deltaTime;
					//
					//
					//					//Then the AI gets close to the player make it punch
					//					if (Vector3.Distance (transform.position, Player.position) <= MaxDist) {
					//						
				}
				//
				//				}
				//				Vector3 localPos = Player.transform.position - transform.position;
				//
				//				localPos = localPos.normalized;
				//
				//				transform.Translate(localPos.x * Time.deltaTime * speed, 
				//					localPos.y * Time.deltaTime * speed, localPos.z * Time.deltaTime * speed);

			} else if (!canMove) {

			}



		}
	}

	//	void DinkCamera(){
	////		DinkCam.SetActive (true);
	////		botCam.SetActive(false);
	//
	////		if (CamDink == true) {
	////			this.GetComponent<Camera> ().enabled = false;
	////			GameObject.Find ("Dink").GetComponent<Camera> ().enabled = true;
	////			GameObject.FindWithTag("Dink").GetComponent<Camera>().enabled = true;
	////		}
	//	}

	//	void BotCamera(){
	////		botCam.SetActive (true);
	////		DinkCam.SetActive (false);
	////		if (CamBot == true) {
	////			this.GetComponent<Camera> ().enabled = true;
	////			GameObject.Find ("Dink").GetComponent<Camera> ().enabled = false;
	////		}
	//	}
}
