using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour {

	public Transform target;
	public float smoothMove = 5f;
	public Vector3 targetCamPos;
	Vector3 offset;
	void Start() {
		offset = transform.position - target.position;
	}

	void FixedUpdate() {
		targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp( transform.position, targetCamPos, smoothMove * Time.deltaTime );
	}
}
