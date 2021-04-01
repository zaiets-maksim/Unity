using System;
using UnityEngine;

public class EnemySnowball : MonoBehaviour {

	public GameObject[] Hearts = new GameObject[3];
	private int _counterDestroyedHearts;

	private void Start() {
		_counterDestroyedHearts = 0;
	}
	private void OnCollisionEnter2D(Collision2D collsion) { //При столкнвении вражеского снежка с главным героем отнимаем сердце
		if(collsion.gameObject.CompareTag("Player")){		
			this.gameObject.SetActive(false);				
			try{
			Hearts[_counterDestroyedHearts++].SetActive(false);
			}
			catch(Exception e){					//Так же отлавливаем ошибку при попытке выхода за рамки массива
				 Debug.Log("Exception: " + e);
        	}
		}
			if(collsion.gameObject.CompareTag("SnowMan"))
			this.gameObject.SetActive(false);
	}
}
