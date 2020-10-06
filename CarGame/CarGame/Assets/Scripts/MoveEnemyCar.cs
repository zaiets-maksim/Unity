using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCar : MonoBehaviour {

	// Use this for initialization
	Transform _myTransform;
	Transform _cameraTransform;
	Rigidbody _rb;
	Quaternion _rotationCenter;

	public float speed;
	void Start () {
		_cameraTransform = Camera.main.GetComponent<Transform>();
		_myTransform = GetComponent<Transform>();
		_rb = GetComponent<Rigidbody>();
		_rotationCenter = new Quaternion (0, 180, 0, 0);
		_myTransform.rotation = _rotationCenter;
	}
	
	void FixedUpdate () {
		//speed += 0.0002f;
		_rb.velocity = new Vector3 (0, _rb.velocity.y, speed);
		if(_myTransform.position.z < _cameraTransform.position.z)
		Destroy(_rb.gameObject);
	}
}
