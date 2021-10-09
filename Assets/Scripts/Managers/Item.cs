using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour {
	public bool isTriggered = false;
	private void OnTriggerEnter(Collider other) {
		float itemDistance = Vector3.Distance( transform.position, other.transform.position );
		if(other.tag == "Player" && itemDistance < 3) {
			Debug.Log( "a" );
			isTriggered = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			Debug.Log( "a" );
			isTriggered = false;
		}
	}
}
