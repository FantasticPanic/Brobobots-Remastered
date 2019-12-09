using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public float speed;// = 3f;
	public float jumpSpeed = 5f;

	public string move_H = "Horizontal_P1";
	public string move_V = "Vertical_P1";

	public Rigidbody rb;

	public Camera cam;

	Animator anim;

	public float velo;

	//public bool canMove;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {


//		Movement ();

		var x = Input.GetAxis(move_H) * Time.deltaTime * speed;
		var z = Input.GetAxis(move_V) * Time.deltaTime * speed;

//		transform.Rotate(0, x, 0);
		transform.Translate(x * velo, 0, z * velo);

//		if (Input.GetAxis (move_H) == 1) {
//			Debug.Log ("hello esgfsdef");
//		}
		 
	}


	void Movement () {



		//Walk left 
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime); //Translates the character transform to the right
			rb.velocity = Vector3.left * velo;
		}

		//Walk right
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime); //Translates the character transform to the right
			rb.velocity = Vector3.right * velo;
		}

		//Walk down
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * speed * Time.deltaTime); //Translates the character transform to the right
			rb.velocity = Vector3.back * velo;
		}

		//Walk up
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime); //Translates the character transform to the right
			rb.velocity = Vector3.forward * velo;
		}


		if (GameObject.Find ("MegaPixel").transform.position.y <= 0.55) {

			if (Input.GetKey (KeyCode.Space)) {
				//transform.Translate (Vector3.forward * speed * Time.deltaTime); //Translates the character transform to the right
				//rb.AddForce(new Vector3(0,100,0), ForceMode.Impulse);
				rb.velocity += jumpSpeed * Vector3.up;
			}
		}
	}
}
