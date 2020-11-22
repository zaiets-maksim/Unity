using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour {
	
	public GameObject[] EnemyCars = new GameObject[6];
	public int RandomSecond;
	int _randomEnemy;
	Vector3[] _arrayPositionsEnemy = new Vector3[3];
	public int IndexArrayPosEnemy;
	public GameObject Car;
	float _positionSpawnZ;
	Transform _carTransform;

	void Start () {
	_carTransform = Car.GetComponent<Transform>();
	StartCoroutine("DoSpawn");
	//RandomSecond = 100;
	}
	
	void LateUpdate(){
		_positionSpawnZ = _carTransform.position.z + 425;
	_arrayPositionsEnemy[0] = new Vector3(0.21f,-2.31001f,_positionSpawnZ);            
 	_arrayPositionsEnemy[1] = new Vector3(-5.79f,-2.31001f,_positionSpawnZ);
 	_arrayPositionsEnemy[2] = new Vector3(6.21f,-2.31001f,_positionSpawnZ);
	}
	
	IEnumerator DoSpawn() {
		RandomSecond = Random.Range(1,3);
	yield return new WaitForSeconds(RandomSecond);


	link:
	_randomEnemy = Random.Range(0, EnemyCars.Length);

		if(EnemyCars[_randomEnemy].gameObject.activeInHierarchy == false){

	IndexArrayPosEnemy = Random.Range(0,3);
	EnemyCars[_randomEnemy].transform.position = _arrayPositionsEnemy[IndexArrayPosEnemy];
	EnemyCars[_randomEnemy].SetActive(true);
	
	
	}else
		goto link;
	StartCoroutine(DoSpawn());
	}

}
