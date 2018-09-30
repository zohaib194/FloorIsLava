using UnityEngine;
using System.Collections;


public class MonsterToss : MonoBehaviour
{
    public float timeBetweenAttacks = 2.0f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    GameObject player;                   // Reference to the player GameObject.

    private float launchAngle;
    public GameObject fireBallPrefab;

    Animator anim;                              // Reference to the animator component.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.


    void Awake ()
    {
        // Setting up the references.
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter (Collider other)
    {
        // If the entering collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if(timer >= timeBetweenAttacks  /* && enemyHealth.currentHealth > 0*/)
        {
            // ... attack.
            Attack ();
            timer = 0.0f;
        }

        // If the player has zero or less health...
        if(playerHealth.currentHealth <= 0)
        {
        }
    }


    void Attack ()
    {	


        // Reset the timer.
        timer = 0f;
        Vector2 launchVel = GetLaunchVel();
        this.launchAngle = getTrajectoryAngle(this.transform.position, launchVel);

        launchVel = new Vector2(Mathf.Cos(launchAngle), Mathf.Sin(launchAngle)) * launchVel.magnitude;
        

    	GameObject fireBall = Instantiate(fireBallPrefab);
    	fireBall.name = "FireBall";
    	fireBall.transform.position = this.transform.position;

    	fireBall.GetComponent<Rigidbody2D>().AddForce(launchVel, ForceMode2D.Impulse);

    }

    float getTrajectoryAngle(Vector2 position, Vector2 launchVector){
    	float launchVel = launchVector.magnitude;
    	float angle = Mathf.Atan(
    				(Mathf.Pow(launchVel, 2) - Mathf.Sqrt(Mathf.Pow(launchVel, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(launchVector.x, 2)) + (2 * launchVector.y * Mathf.Pow(launchVel, 2)))))

    				) / (Physics.gravity.y * launchVector.x));
    	print(angle);
    	Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + launchVector);
    	Debug.DrawLine(this.transform.position, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
    	return angle; //- Vector2.Angle(launchVector, Vector2.right);
    }

    Vector2 GetLaunchVel(){
    	return (this.player.transform.position - this.transform.position);
    }
}