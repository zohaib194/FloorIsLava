﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLook : MonoBehaviour {
	private SpriteRenderer spriteRenderer;

	public Transform target;
	public float speed = 3f;


	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update(){

		spriteRenderer.flipX = (target.position.x < transform.position.x);
		

		/*	Vector3 targ = target.position;
	             targ.z = 0f;
	 
	             Vector3 objectPos = transform.position;
	             targ.x = targ.x - objectPos.x;
	             targ.y = targ.y - objectPos.y;
	 
	             float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
	             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
*/
	}
}
