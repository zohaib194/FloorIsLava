using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLook : MonoBehaviour {
	private SpriteRenderer spriteRenderer;

	private GameObject target;


	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		target = GameObject.Find("Player");
	}

	void Update(){
		spriteRenderer.flipX = (target.transform.position.x < transform.position.x);
	}
}
