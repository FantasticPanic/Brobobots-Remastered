using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_controller : MonoBehaviour {
    // The sphere collidee in DoorLocked will need to be moved to wherever the button is
    // when the player get near the button, Debug will log  "BUTTON CONTACT"
    // Interact with the button by pressing E

    public bool hasPlayer;                       //variable hasPlayer to detect the player inside the the collider
    public bool Pressbtn;                         // determines whether or not to play the Doorbtn animation
                                                 // if true, a locked door will now open. If false, it will close
                                                 // Use this for initialization
    public Animator anim;                       // variable for the animator
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        anim = GetComponent<Animator>();
        if (hasPlayer && Input.GetKeyDown("e"))                                 // if the button collider is true and the player presses E
        {
              // locked door animation will now play
            anim.SetBool("Pressbtn", true);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BUTTON CONTACT");
        if (other.CompareTag("Megapixel"))
        {
            hasPlayer = true;
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Megapixel"))
        {
            hasPlayer = true;
        }
    }
}
