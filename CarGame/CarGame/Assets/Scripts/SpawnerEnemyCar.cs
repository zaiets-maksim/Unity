using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyCar : MonoBehaviour {
	
	public GameObject EnemyCar;
	public int randomSecond;
	 Vector3[] _arrayPositionsEnemy = new Vector3[3];

	public int _indexArrayPosEnemy;
	public GameObject Car;
	float _positionSpawnZ;
	Transform _carTransform;
	Transform _myTransform;
	void Start () {
	_carTransform = Car.GetComponent<Transform>();
	_myTransform = GetComponent<Transform>();
	StartCoroutine("DoSpawn");
	}
	
	void FixedUpdate(){
		_positionSpawnZ = _carTransform.position.z + 425;
		_arrayPositionsEnemy[0] = new Vector3(0.21f,_myTransform.position.y,_positionSpawnZ);            
 	_arrayPositionsEnemy[1] = new Vector3(-5.79f,_myTransform.position.y,_positionSpawnZ);
 	_arrayPositionsEnemy[2] = new Vector3(6.21f,_myTransform.position.y,_positionSpawnZ);

	if(_carTransform.position.z - EnemyCar.transform.position.z  > 810)
		Destroy(EnemyCar.gameObject);
	}
	IEnumerator DoSpawn() {
	yield return new WaitForSeconds(randomSecond);
	_indexArrayPosEnemy = Random.Range(0,3);
		randomSecond = Random.Range(1,3);
	Instantiate (EnemyCar, _arrayPositionsEnemy[_indexArrayPosEnemy], Quaternion.identity);
	StartCoroutine("DoSpawn");
	}
}
