using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetCamera : MonoBehaviour {
	public List<Transform> targets;

	public Vector3 offset;

	public float smoothTime = .5f;

	private Vector3 velocity;

	public float maxZoom = 40f;
	public float minZoom = 10f;
	public float zoomLimiter = 50f;

	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (targets.Count == 0){
			return;
		}

		Zoom();
		Move();
	}

	void Zoom(){
		float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

	float GetGreatestDistance(){
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for(int i = 0; i < targets.Count; i++){
			bounds.Encapsulate(targets[i].position);
		}

		return bounds.size.y;
	}

	void Move(){
		Vector3 centerPoint = GetCenterPoint();
		
		Vector3 newPosition = centerPoint + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}

	Vector3 GetCenterPoint(){
		if(targets.Count == 1){
			return targets[0].position;
		}

		var bounds = new Bounds(targets[0].position, Vector3.zero);

		for(int i = 0; i < targets.Count; i++){
			bounds.Encapsulate(targets[i].position);
		}

		return bounds.center;
	}
}
