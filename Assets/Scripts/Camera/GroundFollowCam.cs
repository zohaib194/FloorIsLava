using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollowCamera : MonoBehaviour {
	public GameObject camera; 
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(camera.transform.position.x, transform.position.y, 0.0f);
		
	}
}
