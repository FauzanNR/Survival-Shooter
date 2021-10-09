using UnityEngine;

public class EnemyManager: MonoBehaviour {
	public PlayerHealth playerHealth;
	public float spawnDelay = 3f;
	public Transform[] spawnPositions;
	[SerializeField]
	MonoBehaviour factory;
	IEnemyFactory Factory {
		get {
			return factory as IEnemyFactory;
		}
	}


	void Start() {
		InvokeRepeating( "Spawn", spawnDelay, spawnDelay );
	}


	void Spawn() {
		if(playerHealth.currentHealth <= 0f) {
			return;
		}

		int spawnPointIndex = Random.Range( 0, spawnPositions.Length );
		Factory.enemyFactory( spawnPointIndex, spawnPositions[spawnPointIndex].position, spawnPositions[spawnPointIndex].rotation );

	}
}
