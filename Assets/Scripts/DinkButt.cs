using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkButt : MonoBehaviour {

	public Collider[] attackHitboxes;

	public float hitforce;

	bool left,right,up,down;

	public string HeadButt = "Fire3_P2";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKey (KeyCode.L)) {
		if (Input.GetButtonDown (HeadButt)) {

//			LaunchAttack (attackHitboxes [0]);

			if (Input.GetKey (KeyCode.RightArrow)) {
				LaunchAttack (attackHitboxes [0]);
				right = true;
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				LaunchAttack (attackHitboxes [0]);
				left = true;
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				LaunchAttack (attackHitboxes [0]);
				up = true;
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				LaunchAttack (attackHitboxes [0]);
				down = true;
			}

		}
		
	}

	private void LaunchAttack (Collider col){
		Collider[] cols = Physics.OverlapBox (col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask ("Hitbox"));


		foreach (Collider c in cols) 
		{
			if (c.transform.parent==transform)
			continue;
			Debug.Log (c.name);
//			Debug.Log (c.name);

//			c.GetComponentInParent<Rigidbody> ().AddForce (c.transform.position * -hitforce);s

			if (left) {
				c.GetComponentInParent<Rigidbody> ().AddForce (-c.transform.right * hitforce);
			}

			if (right) {
				c.GetComponentInParent<Rigidbody> ().AddForce (c.transform.right * hitforce);
			}

			if (up) {
				c.GetComponentInParent<Rigidbody> ().AddForce (c.transform.forward * hitforce);
			}

			if (down) {
				c.GetComponentInParent<Rigidbody> ().AddForce (-c.transform.forward * hitforce);
			}



		}
	}

}
