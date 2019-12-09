using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Sprite : MonoBehaviour {

	Animator anim;

	GameObject MP;

	public string move_H = "Horizontal_P1";
	public string move_V = "Vertical_P1";

	public string punch = "Fire2_P1";
	public string magno = "Fire1_P1";
	public string pressB = "Fire3_P1";

	public int x_last,z_last;

	public int facing;

	public bool carry, toss;

	//check when A has been pressed and punch animation has happened
	public bool punched;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

//		GameObject.FindWithTag ("Megapixel");//MP = this.gameObject;//GameObject.FindWithTag ("Megapixel");
//		MP = this.gameObject;
		MP = GameObject.Find("MPBall");
		x_last = 0;
		z_last = 0;

		punched = false;

//		holding = this.GetComponentInParent<pickupObject> ().carrying;
	}
	
	// Update is called once per frame
	void Update () {
		carry = this.GetComponentInParent<pickupObject> ().carrying;
		toss = this.GetComponentInParent<pickupObject> ().tossed;

		var x = Input.GetAxis(move_H);
		var z = Input.GetAxis(move_V);



		Debug.Log ("Holding is "+carry);

		//Walk left 
		if (Input.GetKeyDown (KeyCode.A) || x == -1) {
			anim.SetBool ("Left", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			x_last = -1;
			facing = 2;

			punched = false;
//			Debug.Log ("MP_Left");

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", true);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", true);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - Left
			if (carry) {
					anim.SetBool ("Left", false);
					anim.SetBool ("Right", false);
					anim.SetBool ("Up", false);
					anim.SetBool ("Down", false);

					anim.SetBool ("Idle_L", false);
					anim.SetBool ("Idle_R", false);
					anim.SetBool ("Idle_U", false);
					anim.SetBool ("Idle_D", false);

					anim.SetBool ("Left_Punch", false);
					anim.SetBool ("Right_Punch", false);
					anim.SetBool ("Down_Punch", false);
					anim.SetBool ("Up_Punch", false);

					anim.SetBool ("Magno_U", false);
					anim.SetBool ("Magno_D", false);
					anim.SetBool ("Magno_L", false);
					anim.SetBool ("Magno_R", false);

					anim.SetBool ("PickUp_Left", true);
					anim.SetBool ("PickUp_Right", false);
					anim.SetBool ("PickUp_Up", false);
					anim.SetBool ("PickUp_Down", false);
			}
		}

		//idle left
		if (facing == 2 && x == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", true);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			punched = false;

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", true);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", true);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - Left
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", true);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

		}

		//Walk right
		if (Input.GetKeyDown (KeyCode.D) || x == 1) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			x_last = 1;
			facing = 1;
//			Debug.Log ("MP_Right");
			punched = false;

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", true);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", true);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - right
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", true);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}
		}

		//idle right
		if (facing == 1 && x == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", true);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			punched = false;

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", true);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", true);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - right
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", true);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}
		}

		//Walk down
		if (Input.GetKeyDown (KeyCode.S) || z == -1) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", true);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			z_last = -1;
			facing = 0;
			punched = false;
//			Debug.Log ("MP_Down");

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", true);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", true);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

			}


			//pickup - down
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", true);
			}
		}



		//idle down
		if (facing == 0 && z == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", true);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			punched = false;

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", true);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", true);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - down
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", true);
			}

		}

		//Walk up
		if (Input.GetKeyDown (KeyCode.W) || z == 1) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", true);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", false);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			z_last = 1;
			facing = 3;
			punched = false;
//			 Debug.Log ("MP_Up");

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", true);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", true);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - up
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", true);
				anim.SetBool ("PickUp_Down", false);
			}
		}


		//idle up
		if (facing == 3 && z == 0) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);

			anim.SetBool ("Idle_L", false);
			anim.SetBool ("Idle_R", false);
			anim.SetBool ("Idle_U", true);
			anim.SetBool ("Idle_D", false);

			anim.SetBool ("Left_Punch", false);
			anim.SetBool ("Right_Punch", false);
			anim.SetBool ("Down_Punch", false);
			anim.SetBool ("Up_Punch", false);

			anim.SetBool ("Magno_U", false);
			anim.SetBool ("Magno_D", false);
			anim.SetBool ("Magno_L", false);
			anim.SetBool ("Magno_R", false);

			anim.SetBool ("PickUp_Left", false);
			anim.SetBool ("PickUp_Right", false);
			anim.SetBool ("PickUp_Up", false);
			anim.SetBool ("PickUp_Down", false);

			punched = false;

			if (Input.GetButton (punch)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", true);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);

				punched = true;
			}

			if (Input.GetButton (magno)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", true);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", false);
				anim.SetBool ("PickUp_Down", false);
			}

			//pickup - up
			if (carry) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Down", false);

				anim.SetBool ("Idle_L", false);
				anim.SetBool ("Idle_R", false);
				anim.SetBool ("Idle_U", false);
				anim.SetBool ("Idle_D", false);

				anim.SetBool ("Left_Punch", false);
				anim.SetBool ("Right_Punch", false);
				anim.SetBool ("Down_Punch", false);
				anim.SetBool ("Up_Punch", false);

				anim.SetBool ("Magno_U", false);
				anim.SetBool ("Magno_D", false);
				anim.SetBool ("Magno_L", false);
				anim.SetBool ("Magno_R", false);

				anim.SetBool ("PickUp_Left", false);
				anim.SetBool ("PickUp_Right", false);
				anim.SetBool ("PickUp_Up", true);
				anim.SetBool ("PickUp_Down", false);
			}

		}


	}
}
