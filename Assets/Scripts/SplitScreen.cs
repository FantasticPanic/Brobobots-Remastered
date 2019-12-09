using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitScreen : MonoBehaviour {

	public GameObject MPCam, DCam;
	GameObject MP, Dink;

	enemyAI[] bot;

	public GameObject Empty;

	Vector3 lastpos;

	Transform dink_pos;
	Transform mp_pos;

	public Image line;

	float newX, newZ;

	public float val;


	public bool control;




	bool pan;
	public bool normal;
//	Canvas line;

	public float MinDist;

	// Use this for initialization
	void Start () {

//		DCam = GameObject.FindGameObjectWithTag ("dinkCam");
//		MPCam = GameObject.FindGameObjectWithTag ("mpCam");

		Dink = GameObject.Find ("DinkBall");
		MP = GameObject.Find ("MPBall");

		dink_pos = Dink.transform;
		mp_pos = MP.transform;

		normal = true;

		control = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (normal) {
			findMid ();
		}


		if (Vector3.Distance (Dink.transform.position, MP.transform.position) <= MinDist) {
//			Debug.Log ("They are close");

//			findMid ();

			this.GetComponent<Camera> ().enabled = true;
			DCam.GetComponent<Camera> ().enabled = false;
			MPCam.GetComponent<Camera> ().enabled = false;
			line.GetComponent<Image> ().enabled = false;

//			foreach (enemyAI bot in bot) {
//				if (bot.mindControl = true) {
//				
//					this.GetComponent<Camera> ().enabled = false;
//					MPCam.GetComponent<Camera> ().enabled = true;
//				}
//			}
//			findMid ();
		} else {
			this.GetComponent<Camera> ().enabled = false;
			line.GetComponent<Image> ().enabled = true;


			if (DCam.transform.position.x < MPCam.transform.position.x) {
				DCam.GetComponent<Camera> ().enabled = true;
				MPCam.GetComponent<Camera> ().enabled = true;

				DCam.GetComponent<Camera> ().rect = new Rect (0f, 0f, 0.5f, 1f);
				MPCam.GetComponent<Camera> ().rect = new Rect (0.5f, 0f, 0.5f, 1f);


			} else if (DCam.transform.position.x > MPCam.transform.position.x){
				DCam.GetComponent<Camera> ().enabled = true;
				MPCam.GetComponent<Camera> ().enabled = true;

				MPCam.GetComponent<Camera> ().rect = new Rect (0f, 0f, 0.5f, 1f);
				DCam.GetComponent<Camera> ().rect = new Rect (0.5f, 0f, 0.5f, 1f);
			}

//			DCam.GetComponent<Camera> ().enabled = true;
//			MPCam.GetComponent<Camera> ().enabled = true;
		}
	}


	void findMid (){
		Vector3 mid_to_dink = dink_pos.position - transform.position;
		Vector3 mid_to_mp = mp_pos.position - transform.position;

		Empty.transform.position = Vector3.Lerp(mp_pos.position, dink_pos.position, 0.5f);

		newX = Empty.transform.position.x;
		newZ = Empty.transform.position.z;


		transform.position = new Vector3 (newX, 8.81f, newZ-2f);
		lastpos = transform.position;
	}
}
