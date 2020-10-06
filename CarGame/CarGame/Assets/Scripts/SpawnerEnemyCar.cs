using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyCar : MonoBehaviour {
	
	public GameObject EnemyCar;
	public int RandomSecond;
	Vector3[] _arrayPositionsEnemy = new Vector3[3];
	public int IndexArrayPosEnemy;
	public GameObject Car;
	float _positionSpawnZ;
	Transform _carTransform;
	Transform _enemyCarTransform;
	float difference;
	void Start () {
	_carTransform = Car.GetComponent<Transform>();
	_enemyCarTransform = EnemyCar.GetComponent<Transform>();
	StartCoroutine("DoSpawn");
	}
	
	void FixedUpdate(){
		_positionSpawnZ = _carTransform.position.z + 425;
	_arrayPositionsEnemy[0] = new Vector3(0.21f,-2.31001f,_positionSpawnZ);            
 	_arrayPositionsEnemy[1] = new Vector3(-5.79f,-2.31001f,_positionSpawnZ);
 	_arrayPositionsEnemy[2] = new Vector3(6.21f,-2.31001f,_positionSpawnZ);
	}
	void OnBecameVisible (){
        Destroy(EnemyCar);
	}
	IEnumerator DoSpawn() {
	yield return new WaitForSeconds(RandomSecond);
	IndexArrayPosEnemy = Random.Range(0,3);
		RandomSecond = Random.Range(1,3);
	Instantiate (EnemyCar, _arrayPositionsEnemy[IndexArrayPosEnemy], Quaternion.identity);
	StartCoroutine("DoSpawn");
	}
}
