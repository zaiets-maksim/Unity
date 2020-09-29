using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyHelper : MonoBehaviour{

	public Transform SpawnPos;
	public GameObject Sky;
	public float X;
	new string name = ("sky");

	void FixedUpdate(){
		if (Sky.transform.position.x < X){
			SpawnEnemy ();
		}
	}

	void SpawnEnemy(){
		//Sky.transform.Rotate (180, 180, 0);
		Instantiate (Sky, SpawnPos.position, Quaternion.identity);
		name += ("(Clone)");
		Sky = GameObject.Find (name);

	}

}