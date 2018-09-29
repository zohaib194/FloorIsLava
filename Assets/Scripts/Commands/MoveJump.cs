using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJump : Command {


	public override void Execute(IClient client){
		SpriteRenderer spriteRenderer;
		
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis("Horizontal");

		spriteRenderer = client.GetComponent<SpriteRenderer> ();
		client.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Max(client.GetComponent<Rigidbody2D>().velocity.y,
																 client.config.velocity.y) * 10 ));

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite) 
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
	}

}
