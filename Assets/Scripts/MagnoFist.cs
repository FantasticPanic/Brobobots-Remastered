using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnoFist : MonoBehaviour {

	public Rigidbody Fist_U,Fist_D,Fist_L,Fist_R;
	public Transform shotpos,shotpos2,shotpos3;
	public float shotForce = 1000f;
	public float moveSpeed = 10f;

	//shotarea = down
	//shotarea2 = up
	//shotarea3 = left And Right
	public GameObject shotArea, shotArea2,shotArea3;

	public string ShootBullet = "Fire1_P1";

	public string move_H = "Horizontal_P2";
	public string move_V = "Vertical_P2";

	public float time;
	public float totalTime;

	bool coolDown;

	public float killTime;

	KeyCode lastKey;

	public int facing;


	// Use this for initialization
	void Start () {
		coolDown = false;

		time = 0;

		facing = 4;
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis(move_H);
		var z = Input.GetAxis(move_V);



		if (Input.GetButtonDown (ShootBullet)) {

			if (coolDown == false) {

				//Up
				if ((Input.GetKey (KeyCode.W)  || z == 1) && x == 0) {
					Rigidbody shot = Instantiate (Fist_U, shotpos2.position, Quaternion.Euler(-100f,0,0)) as Rigidbody;
					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
					shot.AddForce (-shotpos2.forward * shotForce);
					lastKey = KeyCode.W;

					time = 0;
					coolDown = true;

					Rigidbody.Destroy (shot.gameObject, killTime);

					facing = 3;
				}

//				//IDLE UP
//				if (facing == 3 && z == 0) {
//					Rigidbody shot = Instantiate (Fist_U, shotpos2.position, Quaternion.Euler(-100f,0,0)) as Rigidbody;
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
//
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
//					shot.AddForce (-shotpos2.forward * shotForce);
//					lastKey = KeyCode.W;
//
//					time = 0;
//					coolDown = true;
//
//					Rigidbody.Destroy (shot.gameObject, killTime);
//				}



				//Left
				if ((Input.GetKey (KeyCode.A) || x == -1) && z == 0) {
					Rigidbody shot = Instantiate (Fist_L, shotpos3.position, Quaternion.Euler(84f,0,90f)) as Rigidbody; //Fist_L.rotation
					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
					shot.AddForce (shotpos3.right * shotForce);
					lastKey = KeyCode.A;

					time = 0;
					coolDown = true;

					Rigidbody.Destroy (shot.gameObject, killTime);

					facing = 2;
				}

//				//IDLE LEFT
//				if (facing == 2 && x == 0) {
//					Rigidbody shot = Instantiate (Fist_L, shotpos3.position, Quaternion.Euler(84f,0,90f)) as Rigidbody; //Fist_L.rotation
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
//
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
//					shot.AddForce (shotpos3.right * shotForce);
//					lastKey = KeyCode.A;
//
//					time = 0;
//					coolDown = true;
//
//					Rigidbody.Destroy (shot.gameObject, killTime);
//				}



				//Down
				if ((Input.GetKey (KeyCode.S)  || z == -1) && x == 0) {
					Rigidbody shot = Instantiate (Fist_D, shotpos.position, Quaternion.Euler(243f,177f,181f)) as Rigidbody;
					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
					shot.AddForce (shotpos.forward * shotForce);
					lastKey = KeyCode.S;

					time = 0;
					coolDown = true;

					Rigidbody.Destroy (shot.gameObject, killTime);

					facing = 0;
				}

//				//IDLE DOWN
//				if (facing == 0 && z == 0) {
//					Rigidbody shot = Instantiate (Fist_D, shotpos.position, Quaternion.Euler(243f,177f,181f)) as Rigidbody;
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
//
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
//					shot.AddForce (shotpos.forward * shotForce);
//					lastKey = KeyCode.S;
//
//					time = 0;
//					coolDown = true;
//
//					Rigidbody.Destroy (shot.gameObject, killTime);
//				}



				//Right
				if ((Input.GetKey (KeyCode.D) || x == 1) && z == 0) {
					Rigidbody shot = Instantiate (Fist_R, shotpos3.position, Quaternion.Euler(74f,160f,247f)) as Rigidbody;
					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
					shot.AddForce (-shotpos3.right * shotForce);
					lastKey = KeyCode.D;

					time = 0;
					coolDown = true;

					Rigidbody.Destroy (shot.gameObject, killTime);

					facing = 1;
				}


//				//IDLE RIGHT
//				if (facing == 1 && x == 0) {
//					Rigidbody shot = Instantiate (Fist_R, shotpos3.position, Quaternion.Euler(74f,160f,247f)) as Rigidbody;
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
//
//					shot.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
//					shot.AddForce (-shotpos3.right * shotForce);
//					lastKey = KeyCode.D;
//
//					time = 0;
//					coolDown = true;
//
//					Rigidbody.Destroy (shot.gameObject, killTime);
//				}










			
			}



//			if (lastKey == KeyCode.W) {
//				Rigidbody shot = Instantiate (Fist, shotpos.position, shotpos.rotation) as Rigidbody;
//				shot.AddForce (-shotpos.forward * shotForce);
//			}
//
//			if (lastKey == KeyCode.A) {
//				Rigidbody shot = Instantiate (Fist, shotpos.position, shotpos.rotation) as Rigidbody;
//				shot.AddForce (shotpos.right * shotForce);
//			}
//
//			if (lastKey == KeyCode.S) {
//				Rigidbody shot = Instantiate (Fist, shotpos.position, shotpos.rotation) as Rigidbody;
//				shot.AddForce (shotpos.forward * shotForce);
//			}
//
//			if (lastKey == KeyCode.D) {
//				Rigidbody shot = Instantiate (Fist, shotpos.position, shotpos.rotation) as Rigidbody;
//				shot.AddForce (-shotpos.right * shotForce);
//			}

		}

		if (coolDown == true) {
			time  += Time.deltaTime;

			if (time > totalTime) {
				coolDown = false;

			}
		}
	}


}
