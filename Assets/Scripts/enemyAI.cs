using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

	Camera test;
	GameObject split ,mpCam;

	public Transform Player;
	public Transform Dink;

	public float speed;
	public float playerSelect;

	public float bothealth;


	public string move_H = "Horizontal_P2";
	public string move_V = "Vertical_P2";
	string ChangeBack = "Fire2_P2";


	int MoveSpeed = 3;
	int MaxDist = 2;
	int MinDist = 5;

	public bool canMove;

	public bool moveCamera;

	public bool getcontrolledBool;

	public bool mindControl;

	public bool killed;

	GameObject RobotCamera;
	GameObject DinkCam;

	private bool CamDink;
	private bool CamBot;

	public float currPos, oldPos;

	public bool punch;

	// Use this for initialization
	void Start () {
		punch = false;
		speed = Random.Range(0.3f, 1f);
		playerSelect = Random.Range (-1f, 1f);
		canMove = true;
		mindControl = false;

		moveCamera = false;

		split = GameObject.FindGameObjectWithTag ("splitscreen");
		mpCam = GameObject.FindGameObjectWithTag ("mpCam");

		DinkCam = GameObject.FindGameObjectWithTag ("dinkCam");//.GetComponent<Camera> ();//.enabled = true;
		Dink = GameObject.Find("Dink").transform;
		CamBot = false;
		CamDink = true;

		bothealth = 100f;

		this.GetComponent<Camera> ().transform.position = this.transform.position;//new Vector3 (-1.18f,24.54f,-10.77f);

		//ASSING DINK AND MP VALUES OF 1 OR 2 AND HAVE AI CHASE WHATEVER IS CLOSER

		if (playerSelect < 0) {
			Player = GameObject.FindGameObjectWithTag ("Dink").transform;
		} else if (playerSelect > 0) {
			Player = GameObject.FindGameObjectWithTag ("Megapixel").transform;
		}

		test = GetComponentInChildren<enemyCam> ().GetComponent<Camera> ();

//		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		oldPos = transform.position.x;

		//Debug.Log ("punch");

		if (mindControl) {

			//THISSSS - Move cam to AI cam position
			if (Vector3.Distance (test.transform.position, DinkCam.transform.position) >= 0.3f) {

				Vector3 newPos = test.transform.position - DinkCam.transform.position;
				newPos = newPos.normalized;

				DinkCam.transform.Translate (newPos.x * Time.deltaTime * 3f, 
					newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);
				
			} else {
				test.enabled = true;
//				split.GetComponent<SplitScreen> ().control = true;

			}



		


		
//			Debug.Log ("CameraShift");


			transform.rotation = Quaternion.identity;

//			//Walk left 
//			if (Input.GetKey (KeyCode.LeftArrow)) {
//				transform.Translate (Vector3.left * speed * Time.deltaTime); 
//			}
//
//			//Walk right
//			if (Input.GetKey (KeyCode.RightArrow)) {
//				transform.Translate (Vector3.right * speed * Time.deltaTime);
//			}
//
//			//Walk down
//			if (Input.GetKey (KeyCode.DownArrow)) {
//				transform.Translate (Vector3.back * speed * Time.deltaTime);
//			}
//
//			//Walk up
//			if (Input.GetKey (KeyCode.UpArrow)) {
//				transform.Translate (Vector3.forward * speed * Time.deltaTime);
//			}

			var x = Input.GetAxis(move_H) * Time.deltaTime * speed;
			var z = Input.GetAxis(move_V) * Time.deltaTime * speed;

			transform.Translate(x, 0, z);

		} else if (!mindControl || (this.GetComponent<Rigidbody> () == null)) {
			

			//normal AI behaviour
			if (canMove) {
				
//				if (Vector3.Distance (GameObject.FindGameObjectWithTag ("DinkCamPos").transform.position, DinkCam.transform.position) >= 0.3f) {
//				if (Input.GetKey (KeyCode.K)) {
				if (Input.GetButton (ChangeBack)) {

					test.enabled = false;
					Vector3 newPos = GameObject.FindGameObjectWithTag ("DinkCamPos").transform.position - DinkCam.transform.position;
					newPos = newPos.normalized;

					DinkCam.transform.Translate (newPos.x * Time.deltaTime * 3f, 
						newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);


					Debug.Log ("GOBACKTODINK");
				}



				//move to player postion
				if (Vector3.Distance (transform.position, Player.position) <= MinDist) {

					//move player postion to follow player
					Vector3 localPos = Player.transform.position - transform.position;
					localPos = localPos.normalized;

					transform.Translate (localPos.x * Time.deltaTime * speed, 
						localPos.y * Time.deltaTime * speed, localPos.z * Time.deltaTime * speed);

					if (Vector3.Distance (transform.position, Player.position) <= 1f) {
						punch = true;
					} else if (Vector3.Distance (transform.position, Player.position) >= 1f){
						punch = false;
					}

					moveCamera = false;
						
					//cant move because bot is being mind controlled
				} else if (!canMove) {

				}



			}
		}

		//after they have taken enough damage
		if (bothealth < 0) {
			//killed sprite and not moving
			mindControl = false;
//			Destroy(this.gameObject);
			this.gameObject.SetActive(false);

		}
	}

	void shiftCam(){

//		if (Vector3.Distance (test.transform.position, DinkCam.transform.position) >= 0.3f) {
//
//			Vector3 newPos = DinkCam.transform.position - test.transform.position;
//			newPos = newPos.normalized;
//
//			test.transform.Translate (newPos.x * Time.deltaTime * 3f, 
//				newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);
//
//		} else {
//			test.enabled = true;
//		}

		if (Vector3.Distance (test.transform.position, DinkCam.transform.position) >= 0.3f) {

			Vector3 newPos = test.transform.position - DinkCam.transform.position;
			newPos = newPos.normalized;

			DinkCam.transform.Translate (newPos.x * Time.deltaTime * 3f, 
				newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);

		} else {
			test.enabled = true;
		}


	}

	void shiftCamBack(){
//		Vector3 newPos = GameObject.Find("DinkCamPos").transform.position - DinkCam.transform.position;
//		newPos = newPos.normalized;

		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("DinkCamPos").transform.position, DinkCam.transform.position) >= 0.3f) {

			Vector3 newPos = GameObject.FindGameObjectWithTag ("DinkCamPos").transform.position - DinkCam.transform.position;
			newPos = newPos.normalized;

			DinkCam.transform.Translate (newPos.x * Time.deltaTime * 3f, 
				newPos.y * Time.deltaTime * 3f, newPos.z * Time.deltaTime * 3f);
		} else {
			test.enabled = false;
		}
	}
}
