using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splitscreen_CameraPan : MonoBehaviour {

	GameObject Dink, DCam;
	GameObject MP, MPCam;

	public GameObject Empty;

	Vector3 lastpos;

	Transform dink_pos;
	Transform mp_pos;

	public Image line;

	float newX, newZ;

	public float val;




	bool pan;
	public bool normal;
	//	Canvas line;

	public int MinDist;

	// Use this for initialization
	void Start () {
		//		Dink = GameObject.FindGameObjectWithTag ("dinkCam");
		//		MP = GameObject.FindGameObjectWithTag ("mpCam");

		DCam = GameObject.FindGameObjectWithTag ("dinkCam");
		MPCam = GameObject.FindGameObjectWithTag ("mpCam");

		Dink = GameObject.Find ("DinkBall");
		MP = GameObject.Find ("MPBall");

		dink_pos = Dink.transform;
		mp_pos = MP.transform;
		//		line = GameObject.FindGameObjectWithTag ("SplitLine");

		normal = true;
	}

	// Update is called once per frame
	void Update () {

		if (normal) {
			findMid ();
			//		} else if(!normal){
			//			val = 0.6f;
			//
			//			Vector3 mid_to_dink = dink_pos.position - transform.position;
			//			Vector3 mid_to_mp = mp_pos.position - transform.position;
			//			Empty.transform.position = Vector3.Lerp(mp_pos.position, dink_pos.position, 0.5f);
			//			newX = Empty.transform.position.x;
			//			newZ = Empty.transform.position.z;
			//			Vector3 pans = new Vector3 (lastpos.x += val*Time.deltaTime, 8.81f,newZ - 2f);
			//
			//			transform.position = pans;


		}

		//		findMid ();
		//
		//		Vector3 mid_to_dink = dink_pos.position - transform.position;
		//		Vector3 mid_to_mp = mp_pos.position - transform.position;
		//
		//		Vector3 mid = new Vector3 ((mid_to_dink.x + mid_to_mp.x) / 2.0f, (mid_to_dink.y + mid_to_mp.y) / 2.0f, (mid_to_dink.z + mid_to_mp.z) / 2.0f);

		//		this.transform.position = mid;


		if (Vector3.Distance (Dink.transform.position, MP.transform.position) <= MinDist) {
			Debug.Log ("They are close");

			//			findMid ();

			this.GetComponent<Camera> ().enabled = true;
			DCam.GetComponent<Camera> ().enabled = false;
			MPCam.GetComponent<Camera> ().enabled = false;
			line.GetComponent<Image> ().enabled = false;
			//			findMid ();
		} else {
			this.GetComponent<Camera> ().enabled = false;
			DCam.GetComponent<Camera> ().enabled = true;
			MPCam.GetComponent<Camera> ().enabled = true;
			line.GetComponent<Image> ().enabled = true;
		}

		//		if (transform.position.x >= 93.5f) {
		////			pan = true;
		//			normal = false;
		//		}

		//		if(pan){
		//			panning ();
		////			transform.position += new Vector3 (0.5f,0,0);
		////			Debug.Log ("Camera is Panning");
		//		}
	}


	void findMid (){
		Vector3 mid_to_dink = dink_pos.position - transform.position;
		Vector3 mid_to_mp = mp_pos.position - transform.position;



		//		Vector3 mid = new Vector3 ((mid_to_dink.x + mid_to_mp.x) / 2.0f, (mid_to_dink.y + mid_to_mp.y) / 2.0f, (mid_to_dink.z + mid_to_mp.z) / 2.0f);
		//		float midX = (mid_to_dink.x + mid_to_mp.x) / 2.0f;
		//		float midY = (mid_to_dink.y + mid_to_mp.y) / 2.0f;
		//		float midZ = (mid_to_dink.z + mid_to_mp.z) / 2.0f;



		//		this.transform.position = new Vector3 (midX, midY, midZ);
		//		Vector3 newPos = Vector3.Lerp(dink_pos.position, mp_pos.position, 0.5f);
		Empty.transform.position = Vector3.Lerp(mp_pos.position, dink_pos.position, 0.5f);

		//		float newX = Empty.transform.position.x;
		//		float newZ = Empty.transform.position.z;
		newX = Empty.transform.position.x;
		newZ = Empty.transform.position.z;


		transform.position = new Vector3 (newX, 8.81f, newZ-2f);
		lastpos = transform.position;
	}


	//	void zmovement(){
	//		Vector3 mid_to_dink = dink_pos.position - transform.position;
	//		Vector3 mid_to_mp = mp_pos.position - transform.position;
	//
	//		float midX = (mid_to_dink.x + mid_to_mp.x) / 2.0f;
	//		float midY = (mid_to_dink.y + mid_to_mp.y) / 2.0f;
	//		float midZ = (mid_to_dink.z + mid_to_mp.z) / 2.0f;
	//
	//		Empty.transform.position = Vector3.Lerp(mp_pos.position, dink_pos.position, 0.5f);
	//
	//		//		float newX = Empty.transform.position.x;
	//		//		float newZ = Empty.transform.position.z;
	//		newX = Empty.transform.position.x;
	//		newZ = Empty.transform.position.z;
	//
	//
	////		transform.position = new Vector3 (newX, 8.81f, newZ-2f);
	//		transform.position += new Vector3(0,0,newZ-2f);
	////		lastpos = transform.position;
	//	}




	//	void panning(){
	//		float val = 0.2f;
	//		transform.position = lastpos;
	//		transform.position += new Vector3 (val * Time.deltaTime,0,0);
	////		transform.Translate(Vector3.right * Time.deltaTime);
	//		Debug.Log ("Camera is Panning");
	//	}
}
