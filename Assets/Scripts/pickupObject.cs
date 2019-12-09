using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour {

	GameObject mp;

	public playerMove player;

	private float playerspeed;
	public bool carrying;

	GameObject carriedObject;

	public string PickUp = "Fire3_P1";
	public string Throw = "Fire3_P1";

	public string RS_H = "HorizontalRS_P1";
	public string RS_V = "VerticalRS_P1";

	public bool pickedUp, tossed;


	public float distance;
	public float rayDistance;
    
	public float throwingForce = 5f;
	public float gravityForce;

	float RS1, RS2, ThrowTrigger;

	Vector3 move, move2;

	float angle;

	Vector3 dir;

	// Use this for initialization
	void Start () {
		mp = GameObject.FindWithTag ("Megapixel");
		//playerspeed = mp.GetComponent<playerMove>().speed;

		playerspeed = player.speed;


		pickedUp = false;
		tossed = false;
	}
	
	// Update is called once per frame
	void Update () {

		RS1 = Input.GetAxis(RS_H);
		RS2 = Input.GetAxis(RS_V);

		ThrowTrigger = Input.GetAxis (Throw);

		angle = Mathf.Atan2 (RS1, RS2) * Mathf.Rad2Deg;
		Vector3 something = Quaternion.AngleAxis (angle, Vector3.up) * Vector3.down;
//		angle = Mathf.Atan2 (RS1, RS2) * Mathf.Rad2Deg;
		Quaternion angleThrow = Quaternion.Euler (RS1,0,RS2);
//		dir = angleThrow * Vector3.right;
		dir = Quaternion.AngleAxis (angle, Vector3.right) * Vector3.down;

//		Debug.Log ("dir ="+ dir);

		move = new Vector3 (RS1,0, RS2);
		move2 = new Vector3 (-RS1,0, -RS2);
//		Debug.Log (move);

//		Debug.Log (player.speed.ToString());
		if (carrying) {
			carry(carriedObject);
			checkDrop ();
			player.speed = 0.5f;
		} else {
			pickup ();
			player.speed = 1f;
		}
	}


	void carry(GameObject g){
		//g.GetComponent<Rigidbody>().isKinematic = true;
		g.transform.position = mp.transform.position + mp.transform.up * distance;


	}

	void pickup(){
//		if (Input.GetKeyDown (KeyCode.V)) {
		if (Input.GetButtonDown (PickUp)) {
			//Debug.Log ("pressed PICKUP");

			RaycastHit hit;
			Ray ray1 = new Ray (mp.transform.position, Vector3.right); // These will be one ray cast in the direction of the players movement
			Ray ray2 = new Ray (mp.transform.position, Vector3.left);
			Ray ray3 = new Ray (mp.transform.position, Vector3.forward);
			Ray ray4 = new Ray (mp.transform.position, Vector3.back);

//			if (Physics.Raycast (ray1, out hit, rayDistance) || Physics.Raycast (ray1, out hit, rayDistance) 
//				|| Physics.Raycast (ray1, out hit, rayDistance) || Physics.Raycast (ray1, out hit, rayDistance)) {
//
//				pickupAble p = hit.collider.GetComponent<pickupAble> ();
//				if(p != null){
//					Debug.Log ("PickUp");
//					carrying = true;
//					carriedObject = p.gameObject;
//					p.gameObject.GetComponent<Rigidbody>().isKinematic = false;
////					p.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
//				}
//			}

			if (Physics.Raycast (ray1, out hit, rayDistance)) {

				pickupAble p = hit.collider.GetComponent<pickupAble> ();
				if(p != null){
//					Debug.Log ("PickUp");
					carrying = true;
					tossed = false;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

//					pickedUp = true;
//					tossed = false;
					//					p.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
				}
			}

			if (Physics.Raycast (ray2, out hit, rayDistance)) {

				pickupAble p = hit.collider.GetComponent<pickupAble> ();
				if(p != null){
					Debug.Log ("PickUp");
					carrying = true;
					tossed = false;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

//					pickedUp = true;
//					tossed = false;
					//					p.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
				}
			}

			if (Physics.Raycast (ray3, out hit, rayDistance)) {

				pickupAble p = hit.collider.GetComponent<pickupAble> ();
				if(p != null){
					Debug.Log ("PickUp");
					carrying = true;
					tossed = false;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

//					pickedUp = true;
//					tossed = false;
					//					p.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
				}
			}

			if (Physics.Raycast (ray4, out hit, rayDistance)) {

				pickupAble p = hit.collider.GetComponent<pickupAble> ();
				if(p != null){
					Debug.Log ("PickUp");
					carrying = true;
					tossed = false;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

//					pickedUp = true;
//					tossed = false;
					//					p.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
				}
			}
		}
	}


	//drop object
	void checkDrop(){
//		if(Input.GetKeyDown (KeyCode.V)){
		if(Input.GetButtonDown (Throw)){
//		if(ThrowTrigger == -1){
			dropObject ();
		}
	}

	void dropObject(){
		carrying = false;
		tossed = true;
		carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
//		carriedObject.gameObject.GetComponent<Rigidbody> ().useGravity = true;

//		angle = Mathf.Atan2 (RS1, RS2) * Mathf.Rad2Deg;

//		transform.rotation = Quaternion.Euler (new Vector3 (0,angle,0));

//		angle = Mathf.Atan2 (RS1, RS2) * Mathf.Rad2Deg;

//		angle = Mathf.Atan2 (RS1, RS2);// * Mathf.Rad2Deg;

		Vector3 dir_TR_BR = Quaternion.AngleAxis (angle, Vector3.up) * Vector3.forward;
		Vector3 dir_TL_BL = Quaternion.AngleAxis (angle, Vector3.up) * Vector3.back;
//		Quaternion angleThrow = Quaternion.Euler (new Vector3 (0,angle,0));
//		Quaternion angleThrow = Quaternion.Euler (RS1,0,RS2);
//		Vector3 dir = angleThrow * Vector3.forward;

//		Debug.Log (angle);



//		Vector3 move = new Vector3 (RS1,0, RS2);

//		Quaternion newDir = Quaternion.LookRotation (Vector3.up, move);


		//up
		if (RS2 == 1 && RS1 == 0) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.up * throwingForce * 1.2f);
		}

		//down
		if (RS2 == -1 && RS1 == 0) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.forward * -throwingForce * 1.2f);
		}

		//right
		if (RS1 == 1 && RS2 == 0) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 90f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * 10f);
//			}
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * throwingForce * 1.2f);
		}

		//left
		if (RS1 == -1 && RS2 == 0) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 90f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * 10f);
//			}

			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce *2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * -throwingForce * 1.2f);
		} 

		//topright
		if (RS1 == 1 && RS2 == 1) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce *50f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce ( dir_TR_BR * throwingForce * 1.5f);
//			}

			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce ( dir_TR_BR * throwingForce * 1.2f);
		}

		//topleft
		if (RS1 == -1 && RS2 == 1) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 50f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TL_BL * -throwingForce  * 1.5f);
//			}

			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TL_BL * -throwingForce * 1.2f);
		}


		//bottomright
		if (RS1 == 1 && RS2 == -1) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 50f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TR_BR * throwingForce * 1.5f);
//			}

			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TR_BR * throwingForce * 1.2f);
		}

		//bottomleft
		if (RS1 == -1 && RS2 == -1) {
//			if (carriedObject.gameObject.CompareTag ("Dink")) {
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 50f);
//				carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TL_BL * -throwingForce * 1.5f);
//			}

			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (dir_TL_BL * -throwingForce  * 1.2f);
		}

		if (Input.GetKey (KeyCode.W)) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.up * throwingForce);
		}

		if (Input.GetKey (KeyCode.S)) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.forward * -throwingForce);
		}

		if (Input.GetKey (KeyCode.D)) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * throwingForce * 1.5f);
		}

		if (Input.GetKey (KeyCode.A)) {
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * gravityForce * 2.3f);
			carriedObject.gameObject.GetComponent<Rigidbody> ().AddForce (mp.transform.right * -throwingForce * 1.5f);
		}

		//diagonal

//		carriedObject.transform.position = carriedObject.transform.position + carriedObject.transform.right * Time.deltaTime*2;

		carriedObject = null; //make null after
	}
}
