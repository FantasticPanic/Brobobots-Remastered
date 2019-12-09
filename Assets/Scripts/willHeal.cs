using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class willHeal : MonoBehaviour {

    public AudioClip healClip;
    public AudioSource healAudio;  

    public bool isHealing;                        // If this is true, the asset with this script will inflict heal
    
    public float heal = 20;					// base multiple for damage. can be increase or decreased via inspector

   // public float timeBetweenHeal = 5.5f;     // The time in seconds between each attack.         0.5f  
    bool dInRange;
    bool mpInRange;
    float timer;



	// Use this for initialization
	void Start () {
        healAudio = GetComponent<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        healAudio = audios[0];
	}
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;                       //counts up the timer in increments
	}

    public void OnTriggerStay(Collider col)
    {   
        
        


        if (col.tag == "Dink")                    // checks if the asset has the Dink tag
        {
            Debug.Log("Dink hit");
            // Dink is in range of the asset



            dInRange = true;

            // If the timer exceeds the time between attacks and the player is in range and this enemy is alive...
            if ( dInRange /*&& enemyHealth.currentHealth > 0*/)
            {


                // check tag

                //does this asset deal damage or heal damage?
                col.SendMessage((isHealing) ? "healDamage" : "takeDamage", heal);
                //reset timer back to 0
                //timer = 0f;
                
            }


        }
        if (col.tag == "Megapixel")                       // checks if the asset has the Megapixel tag
        {
            Debug.Log("Megapixel hit");

            mpInRange = true;                           //Megapixel is in range of the asset


            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (mpInRange  /*&& enemyHealth.currentHealth > 0*/)
            {
                // check tag 
                //does this asset deal damage or heal damage?
                col.SendMessage((isHealing) ? "healDamage" : "takeDamage", heal);
                //reset timer back to 0
                //timer = 0f;
                
            }

        }
        

    }




    public void OnTriggerExit(Collider col)
    {


        
        //If the exiting collider is the Dink...
        if (col.tag == "Dink")
        {
            // ... Dink is no longer in range.
            dInRange = false;
            Destroy(this.gameObject);
        
        }

        // If the exiting collider is the MegaPixel...
        if (col.tag == "Megapixel")
        {
            // ... Megapixel is no longer in range.
            mpInRange = false;
            Destroy(this.gameObject);
        }
       
    }
}
