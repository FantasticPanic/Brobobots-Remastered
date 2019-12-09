using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller_emp : MonoBehaviour {

	public bool hasPlayer;                       //variable hasPlayer to detect the player inside the the collider
	public bool Doorbtn;                         // determines whether or not to play the Doorbtn animation
	// if true, a locked door will now open. If false, it will close
	// Use this for initialization
	public Animator anim;                       // variable for the animator
	public GameObject player;

	public string EMP = "Fire1_P2";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator>();
		if (hasPlayer && Input.GetKeyDown(KeyCode.J) || hasPlayer && Input.GetButton(EMP))                                 // if the button collider is true and the player presses E
		{
			anim.SetBool("Doorbtn",true);    // locked door animation will now play
//			GameObject.Find("SplitScreen").GetComponent<SplitScreen>().normal = false;
			GameObject.Find("SplitScreen").GetComponent<countdown>().count = true;
//			GameObject.Find ("DinkBall").GetComponent<EMP> ();
		}
	}


	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Dink"))
		{
			hasPlayer = true;
		}

	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("Dink"))
		{
			hasPlayer = false;
		}
	}


}
