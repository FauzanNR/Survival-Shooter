using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager: MonoBehaviour {

	public Transform[] spawnPositions;
	public Item item;
	public float spawnDelay;
	PlayerHealth playerHealth;

	void Awake() {
		playerHealth = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<PlayerHealth>();
	}

	void Start() {
		InvokeRepeating( "spawnItem", spawnDelay, spawnDelay + 10 );
	}

	void Update() {
		if(item.isTriggered) {
			spawnItem();
		}
	}

	public void spawnItem() {
		if(playerHealth.currentHealth <= 0f) {
			return;
		}
		int randomPosition = Random.Range( 0, spawnPositions.Length );
		//Instantiate( item, spawnPositions[randomPosition] );
		item.transform.position = spawnPositions[randomPosition].position;
	}


}
