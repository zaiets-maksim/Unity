using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainRoadObj : MonoBehaviour {

	// Use this for initialization
	public GameObject MainRoad;
	public float _positionSpawnRoadZ;
	Vector3 _positionSpawnRoad;
	string nameMainRoad = "RoadObj";
	Transform _myTransform;
	public GameObject Car;
	Transform _CarTransform;
	void Start () {
		_myTransform = MainRoad.GetComponent<Transform>();
		_CarTransform = Car.GetComponent<Transform>();
			
	}
	
	void FixedUpdate () {
	if(_CarTransform.position.z - _myTransform.position.z  > 810)
		Destroy(MainRoad);
	}
		void OnCollisionEnter(Collision collision){
		if(collision.collider.CompareTag("Car")){
			_positionSpawnRoadZ += 790f;
			_positionSpawnRoad = new Vector3 (-94.38092f,-106.1845f,_positionSpawnRoadZ);
			Instantiate (MainRoad, _positionSpawnRoad, Quaternion.identity);
			nameMainRoad += "(Clone)";
			MainRoad.name = nameMainRoad;
			}
		}
}
