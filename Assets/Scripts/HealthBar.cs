using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class HealthBar : MonoBehaviour {


   public  GameObject Dink, MP;


    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.                                 
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Image mpDamageImage;

    Animator anim;                                              // Reference to the Animator component.
    public AudioSource playerAudio;                                  // Reference to the AudioSource component.
    public AudioSource healAudio;
    playerMove playerMovement;                                  // Reference to the player's movement.
    mpPunch megapixelPunch;                                     // Reference to the PlayerShooting script.
    public bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    public Image health;   // references HP image 
    public Text hpVal;		// references numerical value of health

    //public  Respawn respawn;
    public float hitPoint = 100;   			// This will be the Character's HP upon launchin  the game
    public float maxPoint = 100;				// This will be the maximum amount of HP a character can have

    
	// Use this for initialization

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        healAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<playerMove>();
        megapixelPunch = GetComponentInChildren<mpPunch>();
       // respawn = GetComponent<Respawn>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }
    
    
    
    void Start () {
        updateHealthBar();                     // calls updateHealthBar method

 
        AudioSource[] audios = GetComponents<AudioSource>();
        playerAudio = audios[0];
        //healAudio = audios[1];
    }
	
	// Update is called once per frame
	void Update () {
        // If the player has just been damaged...
        if (damaged==true)
        {
            // ... set the colour of the mpdamageImage to the flash colour.
            mpDamageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            mpDamageImage.color = Color.Lerp(mpDamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

     
        // Reset the damaged flag.
        damaged = false;
	}

   public void updateHealthBar (){
      
       float ratio = hitPoint / maxPoint;                              // converts the current HP divided by maxium HP to a ratio
		health.rectTransform.localScale = new Vector3(ratio,1,1);		// resizes the health bar upon taking damage
		hpVal.text= (ratio*100).ToString() + '%';						// changes the numerical value upon taking damage
       
    }


    public void takeDamage(float damage)
    {
            playerAudio.Play(); 
		    hitPoint -= damage; // HP will decrease upon taking damage
            damaged = true;

            if (hitPoint < 0)
            {
                hitPoint = 0;
//                isDead = true;
                Death();
                Debug.Log("DEAD");
            }
				updateHealthBar();
       
    }

	public void healDamage(float heal)
	{
       // healAudio.PlayOneShot(deathClip, 0.9f); 												
		hitPoint += heal;

		if(hitPoint >maxPoint){
			hitPoint = maxPoint;

			//Debug.Log ("FULL HEALTH");
			updateHealthBar();
		}
     
        
	}

    public void Death()
    {
        // Set the death flag so this function won't be called again.
//       if( isDead == true){
//           Dink.transform.Translate(100, 100, 100);
			hitPoint = 100f;
			this.gameObject.GetComponent<Respawn> ().killed ();
//       }// respawn Dink or Megapixel


    }
}
