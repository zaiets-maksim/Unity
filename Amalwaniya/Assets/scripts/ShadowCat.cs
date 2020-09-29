using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCat : MonoBehaviour {

	public GameObject img;
	public GameObject cat;

	void FixedUpdate () {
		img.transform.position = new Vector2(cat.transform.position.x ,-4.926004f);
	}
}
