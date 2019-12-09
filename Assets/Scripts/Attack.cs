using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public Collider[] attackHitboxes;
    //
//	GameObject enemy;
	public string MP_Melee = "Fire2_P1";

	//Left Joystick for Player 1
	public string move_H = "Horizontal_P1";
	public string move_V = "Vertical_P1";

	public float hitforce;

	bool left,right,up,down;

	int hitCounter;


	// Use this for initialization
	void Start () {
//		hitCounter = 0;

	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis(move_H);
		var z = Input.GetAxis(move_V);

//		if (Input.GetKey (KeyCode.C)) {
		if (Input.GetButtonDown (MP_Melee)) {

//			LaunchAttack (attackHitboxes [0]);

			if (Input.GetKey (KeyCode.D) || x == 1) {
				LaunchAttack (attackHitboxes [0]);
				right = true;
//				hitCounter+=1;
			}

			if (Input.GetKey (KeyCode.A) || x == -1) {
				LaunchAttack (attackHitboxes [1]);
				left = true;
//				hitCounter+=1;
			}

			if (Input.GetKey (KeyCode.W) || z == 1) {
				LaunchAttack (attackHitboxes [2]);
				up = true;
//				hitCounter+=1;
			}

			if (Input.GetKey (KeyCode.S) || z == -1) {
				LaunchAttack (attackHitboxes [3]);
				down = true;
//				hitCounter+=1;

			}

		}
	}

	private void LaunchAttack (Collider col){
		Collider[] cols = Physics.OverlapBox (col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask ("Hitbox"));

//		hitCounter = 0;
		foreach (Collider c in cols) 
		{
			Debug.Log (c.name);
			hitCounter = 0;


			if (left) {
				c.GetComponentInParent<Rigidbody> ().AddForce (-c.transform.right * hitforce);
				hitCounter+=1;
				c.GetComponentInParent<enemyAI> ().bothealth -= 20f;


				//kill enemy
//				c.GetComponentInParent<enemyAI> ().killed = true;
//				c.transform.parent.parent.gameObject.SetActive (false);
			}

			if (right) {
				c.GetComponentInParent<Rigidbody> ().AddForce (c.transform.right * hitforce);
				hitCounter+=1;
//				c.transform.parent.parent.gameObject.SetActive (false);
				c.GetComponentInParent<enemyAI> ().bothealth -= 20f;
			}

			if (up) {
				c.GetComponentInParent<Rigidbody> ().AddForce (c.transform.forward * hitforce);
				hitCounter+=1;
//				c.transform.parent.parent.gameObject.SetActive (false);
				c.GetComponentInParent<enemyAI> ().bothealth -= 20f;
			}

			if (down) {
				c.GetComponentInParent<Rigidbody> ().AddForce (-c.transform.forward * hitforce);
				hitCounter+=1;
//				c.transform.parent.parent.gameObject.SetActive (false);
				c.GetComponentInParent<enemyAI> ().bothealth -= 20f;
			}

//			if (c.transform.parent==transform)
//				continue;
//			Debug.Log (c.name);
//			if (hitCounter > 3) {
//				//				c.GetComponentInParent
//				Debug.Log("Kill this fool!");
////				c.GetComponentInParent<GameObject> ().SetActive(false);
////				Destroy(c.GetComponentInParent<GameObject>().gameObject);
//				c.transform.parent.parent.gameObject.SetActive (false);
//			}
		}
	}
}
