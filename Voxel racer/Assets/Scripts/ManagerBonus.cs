using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBonus : MonoBehaviour {
	Vector3[] _arrayPositionsBonus = new Vector3[3];
	public GameObject[] Bonuses = new GameObject[5];
	int IndexArrayPosEnemy;
	public int RandomSecond;
	float _positionSpawnZ;
	int _randomBonus;
	Transform _carTransform;
	public GameObject Car;

	void Start() {
		_carTransform = Car.GetComponent<Transform>();
		StartCoroutine("DoSpawn");
	}
	void LateUpdate() {
	_positionSpawnZ = _carTransform.position.z + 425;
	_arrayPositionsBonus[0] = new Vector3(0.21f,-2.31001f,_positionSpawnZ);            
 	_arrayPositionsBonus[1] = new Vector3(-5.79f,-2.31001f,_positionSpawnZ);
 	_arrayPositionsBonus[2] = new Vector3(6.21f,-2.31001f,_positionSpawnZ);
	}
	IEnumerator DoSpawn() {
		RandomSecond = Random.Range(3,12);

	link:
	// for(int i = 0; i < Bonuses.Length; i++)
	// if(Bonuses[i].activeInHierarchy)

	_randomBonus = Random.Range(0,Bonuses.Length);

		if(Bonuses[_randomBonus].gameObject.activeInHierarchy == false){

	IndexArrayPosEnemy = Random.Range(0,3);
	Bonuses[_randomBonus].transform.position = _arrayPositionsBonus[IndexArrayPosEnemy];
	Bonuses[_randomBonus].SetActive(true);
	yield return new WaitForSeconds(RandomSecond);
	
	}else
		goto link; //анитпаттерн
	StartCoroutine(DoSpawn());
	}
}
