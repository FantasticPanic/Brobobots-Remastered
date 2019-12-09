using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove_Dink : MonoBehaviour {

	public float speed;// = 3f;
	public float jumpSpeed = 5f;

	public string move_H = "Horizontal_P2";
	public string move_V = "Vertical_P2";

	public Rigidbody rb;

	public bool controlAI;

	public KeyCode lastkey;

	public float velo;

//	Animator anim;

	public bool canMove;

	// Use this for initialization
	void Start () {
//		anim = GetComponent<Animator> ();
		controlAI = false;
	}

	// Update is called once per frame
	void Update () {
		Movement ();


	}

	//Method that takes care of all the moving around (only left to right ATM) 
	void Movement () {

		if (!controlAI) {
			rb.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;


//			//Walk left 
//			if (Input.GetKey (KeyCode.LeftArrow)) {
//				transform.Translate (Vector3.left * speed * Time.deltaTime); 
//				lastkey = KeyCode.LeftArrow;
//
//				rb.velocity = Vector3.left * velo;
////				float translation = Input.GetAxis("Vertical") * speed;
////				float rotation = Input.GetAxis ("Horizontal") * 2;
////				translation *= Time.deltaTime;
////
////				transform.Translate (0, 0, translation);
////				transform.Rotate (0, rotation, 0);
//			}
//
//			//Walk right
//			if (Input.GetKey (KeyCode.RightArrow)) {
//				transform.Translate (Vector3.right * speed * Time.deltaTime); 
//				lastkey = KeyCode.RightArrow;
//
//				rb.velocity = Vector3.right * velo;
//			}
//
//			//Walk down
//			if (Input.GetKey (KeyCode.DownArrow)) {
//				transform.Translate (Vector3.back * speed * Time.deltaTime); 
//				lastkey = KeyCode.DownArrow;
//
//				rb.velocity = Vector3.back * velo;
//			}
//
//			//Walk up
//			if (Input.GetKey (KeyCode.UpArrow)) {
//				transform.Translate (Vector3.forward * speed * Time.deltaTime); 
//				lastkey = KeyCode.UpArrow;
//
//				rb.velocity = Vector3.forward * velo;
//			}

			var x = Input.GetAxis(move_H) * Time.deltaTime * speed;
			var z = Input.GetAxis(move_V) * Time.deltaTime * speed;

			transform.Translate(x * velo, 0, z * velo);


		} else if (controlAI) {
			rb.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;	
		}
	}
}
