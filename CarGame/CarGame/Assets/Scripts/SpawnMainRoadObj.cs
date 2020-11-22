using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainRoadObj : MonoBehaviour {

	// Use this for initialization
	public GameObject[] ArrayRoads = new GameObject[2];
	public float _positionSpawnZ;
	public GameObject Car;
	Transform _CarTransform;
	int _lastElement;
	int _nextElement;
	int _swap;
	void Start () {
		_lastElement = 0;
		_nextElement = 1;
	}
	
	void LateUpdate () {
		_CarTransform = Car.GetComponent<Transform>();

	if(_CarTransform.position.z > ArrayRoads[_lastElement].transform.position.z + 325f){
	_positionSpawnZ += 790f;
	//ArrayRoads[_lastElement].transform.position.z
	ArrayRoads[_nextElement].SetActive(true);
	ArrayRoads[_nextElement].transform.position = new Vector3(ArrayRoads[_nextElement].transform.position.x,ArrayRoads[_nextElement].transform.position.y,_positionSpawnZ);

	if(_CarTransform.position.z > ArrayRoads[_lastElement].transform.position.z + 800f)
	ArrayRoads[_lastElement].SetActive(false);

	_swap = _lastElement;
	_lastElement = _nextElement;
	_nextElement = _swap;

		}
	}
}
