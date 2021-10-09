using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory: MonoBehaviour, IEnemyFactory {

	[SerializeField]
	GameObject[] enemy;

	public GameObject enemyFactory(int tag, Vector3 position, Quaternion rotation) => Instantiate( enemy[tag], position, rotation );
}
