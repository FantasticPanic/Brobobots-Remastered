using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickupSound : MonoBehaviour {


    public AudioClip healClip;
    public AudioSource healSource;
	// Use this for initialization
	void Start () {
		healSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider tag) {
        if (tag.gameObject.CompareTag("Dink") || tag.gameObject.CompareTag("Megapixel")) {
            healSource.PlayOneShot(healClip, 1.0f); 
        }
    }
}
