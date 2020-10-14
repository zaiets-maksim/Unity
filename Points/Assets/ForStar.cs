using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForStar : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")){
			this.gameObject.SetActive (false);
		}
	}
}
