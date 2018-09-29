using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command {


	public override void Execute(IClient client){
		SpriteRenderer spriteRenderer;
		
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis("Horizontal");

		spriteRenderer = client.GetComponent<SpriteRenderer> ();
		client.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Min(client.GetComponent<Rigidbody2D>().velocity.x,
																 -client.config.velocity.x), client.GetComponent<Rigidbody2D>().velocity.y);

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite) 
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
	}

}
