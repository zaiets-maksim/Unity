using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class N2o : MonoBehaviour {

	public GameObject Car;
	public ParticleSystem Smoke;
	public Renderer _meshN2o; 

	[System.Obsolete]
	void OnTriggerEnter(Collider N2o) {
		if (N2o.gameObject.CompareTag("Car")){
		ControllCar.Speed = ControllCar.Speed*1.5f;
		Smoke.startColor = new Color(0,189,255,255);
		_meshN2o.enabled = false;

		StartCoroutine("DoCheck");
        }	
    }

[System.Obsolete]
IEnumerator DoCheck() {
	
	yield return new WaitForSeconds(4f);
	
		 ControllCar.Speed = ControllCar.Speed/1.5f;
		 Smoke.startColor = new Color(167,167,167,255);

		 _meshN2o.enabled = true;
	}

	void LateUpdate() {
		this.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);

		if((Car.transform.position.z - 15) > this.transform.position.z && _meshN2o.enabled){
		 this.gameObject.SetActive(false);}
	}
}
