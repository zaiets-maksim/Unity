using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour {

	public float speed;
	public Vector2 dir;
	public float X;

	void FixedUpdate () {

		transform.Translate (dir * speed, Space.World);
		if (gameObject.transform.position.x < X) {
			Destroy (gameObject);
		}

	}
}
