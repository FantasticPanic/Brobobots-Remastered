	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copBot_Sprites : MonoBehaviour {

	Animator anim;

	GameObject enemy;

	public float currPosX, oldPosX, currPosZ, oldPosZ;

	bool punched;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

//		enemy = GameObject.FindWithTag ("CopBot");
		enemy = this.gameObject;
		oldPosX = transform.position.x;
		oldPosZ = transform.position.z;

		punched = GetComponentInParent<enemyAI> ().punch;
	}
	
	// Update is called once per frame
	void Update () {
//		oldPos = transform.position.x;

		currPosX = GetComponentInParent<enemyAI> ().transform.position.x;
		currPosZ = GetComponentInParent<enemyAI> ().transform.position.z;

		if (currPosX > oldPosX) {	 //moving left
//		if (Input.GetKey(KeyCode.Space)) {
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", true);

			anim.SetBool ("Punch_L", false);
			anim.SetBool ("Punch_R", false);

			if (Input.GetKey(KeyCode.Space)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);

				anim.SetBool ("Punch_L", true);
				anim.SetBool ("Punch_R", false);
			}
		} 

		if (currPosX < oldPosX) { //moving right
//		if (Input.GetKey(KeyCode.T)) {
			anim.SetBool ("Left", true);
			anim.SetBool ("Right", false);

			anim.SetBool ("Punch_L", false);
			anim.SetBool ("Punch_R", false);

			if (Input.GetKey(KeyCode.Space)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Right", false);

				anim.SetBool ("Punch_L", false);
				anim.SetBool ("Punch_R", true);
			}
		}
	}
}
