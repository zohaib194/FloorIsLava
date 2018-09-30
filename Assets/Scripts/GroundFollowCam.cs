
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollowCam : MonoBehaviour {
	public GameObject camera; 
	public bool resetZAxis;
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(camera.transform.position.x, transform.position.y, ((resetZAxis) ? 0.0f : transform.position.z));
	}
}
