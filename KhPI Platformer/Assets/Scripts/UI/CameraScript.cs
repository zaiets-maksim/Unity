using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	[SerializeField] private Transform _player;
	private float _movement;
	[Range(0.1f, 2f)]
	[SerializeField] private float _offset = 1.2f;

	[Range(0.1f, 4f)]
	[SerializeField] private float _smooth = 3; 
	private void LateUpdate() {
		_movement = SimpleInput.GetAxis("Horizontal");
		LookAtPlayer();
	}
		void LookAtPlayer(){
		this.transform.position = new Vector3 (_player.transform.position.x + (_movement * _offset), this.transform.position.y / _smooth, this.transform.position.z);
	}
}
