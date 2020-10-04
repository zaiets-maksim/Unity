using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCar : MonoBehaviour {

	// Use this for initialization
	Transform _myTransform;
	Transform _cameraTransform;
	Rigidbody _rb;
	Quaternion _rotationCenter;
	void Start () {
		_cameraTransform = Camera.main.GetComponent<Transform>();
		_myTransform = GetComponent<Transform>();
		_rb = GetComponent<Rigidbody>();
		_rotationCenter = new Quaternion (0, 180, 0, 0);
		_myTransform.rotation = _rotationCenter;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rb.velocity = new Vector3 (0, _rb.velocity.y, -50);
		if(_myTransform.position.z < _cameraTransform.position.z)
		Destroy(_rb.gameObject);
	}
}
