using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    // PLAYER HEALTH BAR WILL ONLY WORK IF THIS SCRIPT IS ATTACHED TO A ENEMY OR HAZARD
    // 


    public pickupObject isCarried;
    HealthBar heal;
    public bool isDamaging;                     // If this is true, the asset with this script will inflict damage
    public bool isLifted;
    public float damage = 10;					// base multiple for damage. can be increase or decreased via inspector

    public float timeBetweenAttacks;// = 5.5f;     // The time in seconds between each attack.         0.5f  
    bool dInRange;
    bool mpInRange;
    float timer;

    //public Transform player;
    //spublic Transform respawnLocation;

    // Use this for initialization
    void Start()
    {
        isCarried = GetComponent<pickupObject>();
		timeBetweenAttacks = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
        timer += Time.deltaTime;                   // increments the timer 
        

    }


    public void OnTriggerStay(Collider col)
    {
        
        if (col.tag == "Dink")                    // checks if the asset has the Dink tag
        {
           // Debug.Log("Dink hit");
            // Dink is in range of the asset



            dInRange = true;

            // If the timer exceeds the time between attacks and the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && dInRange /*&& enemyHealth.currentHealth > 0*/)
            {


                // check tag

                //does this asset deal damage or heal damage?
                col.SendMessage((isDamaging) ? "takeDamage" : "healDamage", damage);
                //reset timer back to 0
                timer = 0f;

            }
            //killPlayer();

        }

        if (col.tag == "Megapixel")                       // checks if the asset has the Megapixel tag
        {
          //  Debug.Log("Megapixel hit");

            mpInRange = true;                           //Megapixel is in range of the asset


            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && mpInRange  /*&& enemyHealth.currentHealth > 0*/)
            {
                // check tag 
                //does this asset deal damage or heal damage?
                col.SendMessage((isDamaging) ? "takeDamage" : "healDamage", damage*0.25);
                //reset timer back to 0
                timer = 0f;

            }
          //  killPlayer();
        }
    }




    public void OnTriggerExit(Collider col)
    {
        //If the exiting collider is the Dink...
        if (col.tag == "Dink")
        {
            // ... Dink is no longer in range.
            dInRange = false;
        }

        // If the exiting collider is the MegaPixel...
        if (col.tag == "Megapixel")
        {
            // ... Megapixel is no longer in range.
            mpInRange = false;
        }
    }

 /*public void killPlayer(){
     player.transform.position = respawnLocation.position;
 }*/
}
