using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkSprite : MonoBehaviour {

	Animator anim;

	GameObject Dink;

	public string move_H = "Horizontal_P2";
	public string move_V = "Vertical_P2";

	public string headbutt = "Fire3_P2";

	public int facing;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		Dink = GameObject.FindWithTag ("Dink");

	}
	
	// Update is called once per frame
	void Update () {

		var x = Input.GetAxis(move_H);
		var z = Input.GetAxis(move_V);


		//Walk left 
		if (Input.GetKeyDown (KeyCode.LeftArrow) || x == -1) {
			anim.SetBool ("Left", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			facing = 2;


			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", true);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", false);
			}
		}

		//Walk right
		if (Input.GetKeyDown (KeyCode.RightArrow) || x == 1) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			facing = 1;

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", true);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", false);
			}
		}

		//Walk down
		if (Input.GetKeyDown (KeyCode.DownArrow) ||	 z == -1) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", true);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			facing = 0;

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", true);
			}
		}

		//Walk up
		if (Input.GetKeyDown (KeyCode.UpArrow) || z == 1) {

			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", true);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			facing = 3;

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", true);
				anim.SetBool ("DB_D", false);
			}

		}




		//IDLE

		//idle left
		if (facing == 2 &&  x == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", true);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", true);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", false);
			}
		}

		//Walk right
		if (facing == 1 &&  x == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", true);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", true);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", false);
			}
		}

		//Walk down
		if (facing == 0 &&  z == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", true);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", false);
				anim.SetBool ("DB_D", true);
			}
		}

		//Walk up
		if (facing == 3 &&  z == 0) {

			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", true);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("DB_L", false);
			anim.SetBool ("DB_R", false);
			anim.SetBool ("DB_U", false);
			anim.SetBool ("DB_D", false);

			if (Input.GetButtonDown (headbutt)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("DB_L", false);
				anim.SetBool ("DB_R", false);
				anim.SetBool ("DB_U", true);
				anim.SetBool ("DB_D", false);
			}
		}
	}
}
