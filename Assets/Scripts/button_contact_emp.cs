using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_contact_emp : MonoBehaviour {

	public bool hasPlayer;                       //variable hasPlayer to detect the player inside the the collider
	public bool Pressbtn;                         // determines whether or not to play the Doorbtn animation
	// if true, a locked door will now open. If false, it will close
	// Use this for initialization
	public Animator anim;                       // variable for the animator
	public GameObject player;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator>();
		if (hasPlayer && Input.GetKeyDown("K"))                                 // if the button collider is true and the player presses E
		{
			// locked door animation will now play
			anim.SetBool("Pressbtn", true);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("BUTTON CONTACT");
		if (other.CompareTag("Megapixel") || other.CompareTag("Dink"))
		{
			hasPlayer = true;
		}

	}

	void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("Megapixel") || other.CompareTag("Dink"))
		{
			hasPlayer = true;
		}
	}
}
