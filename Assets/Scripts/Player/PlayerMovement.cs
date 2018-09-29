using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// IClient config.
	public PlayerConfig config;
	private bool onGround = true;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidbody;

	private AnimationManager animationManager;
		
	// Use this for initialization
	void Start () {
		animationManager = GetComponent<AnimationManager>();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Input handling
		if(Input.GetKey(KeyCode.A)){
	        this.animationManager.setAnimation("isRun");
			this.rigidbody.velocity = new Vector2(Mathf.Min(this.rigidbody.velocity.x,
																	 -config.velocity.x), this.rigidbody.velocity.y);

	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		} else if(Input.GetKey(KeyCode.D)){
	        this.animationManager.setAnimation("isRun");
			this.rigidbody.velocity = new Vector2(Mathf.Max(this.rigidbody.velocity.x,
																	 config.velocity.x), this.rigidbody.velocity.y);

	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		} else {
	        this.animationManager.setAnimation("isIdle");
		}
		if(Input.GetButton("Jump") && onGround){
	        this.animationManager.setAnimation("isJump");
			onGround = false;
			
			this.rigidbody.AddForce(new Vector2(0, Mathf.Max(this.rigidbody.velocity.y,
																 config.velocity.y))  * 70);
	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		} else if(!onGround){
			this.rigidbody.AddForce(new Vector2(0, -19.62f));
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Square"){
			onGround = true;
	        this.animationManager.setAnimation("isIdle");
		}
	}
}
