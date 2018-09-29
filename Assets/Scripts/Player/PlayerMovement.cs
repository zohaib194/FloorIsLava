using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// IClient config.
	public PlayerConfig config;
	private bool onGround = true;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidbody;
		
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Input handling
		if(Input.GetKey(KeyCode.A)){
			this.rigidbody.velocity = new Vector2(Mathf.Min(this.rigidbody.velocity.x,
																	 -config.velocity.x), this.rigidbody.velocity.y);

	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		} else if(Input.GetKey(KeyCode.D)){
			this.rigidbody.velocity = new Vector2(Mathf.Max(this.rigidbody.velocity.x,
																	 config.velocity.x), this.rigidbody.velocity.y);

	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		} 
		if(Input.GetButton("Jump") && onGround){
			onGround = false;
			
			this.rigidbody.AddForce(new Vector2(0, Mathf.Max(this.rigidbody.velocity.y,
																 config.velocity.y))  * 30);
	        if ((spriteRenderer.flipX ? (Input.GetAxis("Horizontal") > 0.01f) : (Input.GetAxis("Horizontal") < 0.01f))) 
	        {
	            spriteRenderer.flipX = !spriteRenderer.flipX;
	        }
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Cube"){
			onGround = true;
		}
	}
}
