using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCar : MonoBehaviour {

	// Use this for initialization
	Transform _myTransform;
	Rigidbody _rb;
	public GameObject Car;
	public static bool ShowPrefabEnemy;

	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		_rb.velocity = new Vector3 (0, _rb.velocity.y, -50);
		
	}
	void LateUpdate(){
		if((Car.transform.position.z - 15) > this.transform.position.z)
		this.gameObject.SetActive(false);
	}
}

	

