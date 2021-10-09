using UnityEngine;
public interface IEnemyFactory {
	GameObject enemyFactory(int tag, Vector3 position, Quaternion rotation);
}
