using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScreenEdge : MonoBehaviour
{
	Camera cam;
	public GameObject player;
	public Vector3 offset;
	void Start ()
	{
		cam = Camera.main;
	}

	void Update ()
	{
		transform.position = new Vector3(cam.transform.position.x + ((Mathf.Tan((cam.fieldOfView / 2) * Mathf.Deg2Rad) * cam.farClipPlane) * cam.aspect) + offset.x, player.transform.position.y + offset.y, 0);
	}
}
