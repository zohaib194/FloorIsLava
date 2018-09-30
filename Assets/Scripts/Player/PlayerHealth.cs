using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int startingMana = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public int currentMana;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Slider manaSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


	private AnimationManager animationManager;

    private PlayerMovement playerMovement;                              // Reference to the player's movement.
    //PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake ()
    {
        // Setting up the references.
		animationManager = GetComponent<AnimationManager>();
        playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;

        currentMana = startingMana;
        manaSlider.value = currentMana;

    }


    void Update ()
    {
        // If the player has just been damaged...
        if(damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if(currentHealth < 0.01f){
            Death();
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if(currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death ();
        }
    }


    void Death ()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
       // playerShooting.DisableEffects ();

        // Tell the animator that the player is dead.
	    this.animationManager.setAnimation("isDead");
	    currentHealth = 0;
        healthSlider.value = currentHealth;

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
       // playerShooting.enabled = false;
    }   

    void OnCollisionEnter2D(Collision2D other){
    	if(other.gameObject.name == "HpPotion"){
			Destroy(other.gameObject);
			currentHealth += 10;
			currentHealth = (int)Mathf.Clamp(currentHealth, 0.0f, 100.0f);
        	healthSlider.value = currentHealth;

		} else if(other.gameObject.name == "ManaPotion"){
			Destroy(other.gameObject);
			currentMana += 10;
			currentMana = (int)Mathf.Clamp(currentMana, 0.0f, 100.0f);
			manaSlider.value = currentMana;

		} else if(other.gameObject.name == "Ground" || other.gameObject.name == "Monster") {
			print("Should be dead");

	        Death();
		}
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.gameObject.name == "FireBall"){
    		currentHealth -= 10;
			currentHealth = (int)Mathf.Clamp(currentHealth, 0.0f, 100.0f);
        	healthSlider.value = currentHealth;
    	}
    }
}



/*


// If the player has health to lose...
        if(playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage (attackDamage);
        }



        */