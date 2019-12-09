using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_unlock : MonoBehaviour {
    public bool DoorCycle;
    // Use this for initialization
    private Animator anim;
    private GameObject player;
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
       anim.SetBool("DoorCycle", true);
    }

    void OnTriggerExit(Collider other)
    {
      anim.SetBool("DoorCycle", false);
    }
}
