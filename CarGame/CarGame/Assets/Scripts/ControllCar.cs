using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllCar : MonoBehaviour {

public ParticleSystem Smoke;
	public Rigidbody Rb;
	public GameObject Car;
	new public Camera Camera;
	public Slider Slider;
	public float Speed;
	private Vector2 Position;
	public GameObject DieCanvas;
	public Canvas CanvasPanelGame;

	public int SwipeR = 0;
	public int SwipeL = 0;

	// Use this for initialization
	void Start () {
		Rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate ()
	{
		Camera.transform.position = new Vector3 (Car.transform.position.x/3, (Car.transform.position.y + 26.3f), Car.transform.position.z -21.7f);
		Camera.transform.rotation = new Quaternion(46.731f, 0, 0, 180);
		 Rb.velocity = new Vector3 (0, Rb.velocity.y, Speed);
		Car.transform.rotation = new Quaternion (0, 0, 0, 180);


			SwipeR = PlayerPrefs.GetInt("swipeR");
			SwipeL = PlayerPrefs.GetInt("swipeL");
 
			 if(SwipeR == 1){
				 Vector3 Pos2 = new Vector3 (6f, transform.position.y, transform.position.z);
				 
				 if(Car.transform.position.x < 0){
					 Vector3 Pos1 = transform.position;
					Pos2 = new Vector3 (0f, transform.position.y, transform.position.z);
					transform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);
					Car.transform.rotation = new Quaternion (0, 18, 0, 180);
					if(Car.transform.position.x >= -0.1f){
			 Car.transform.rotation = new Quaternion (0, 0, 0, 180);
			 	 SwipeR = 0;
		PlayerPrefs.SetInt("swipeR",SwipeR);
				}
			}
				else{
				Vector3 Pos1 = transform.position;
        transform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);

			 Car.transform.rotation = new Quaternion (0, 18, 0, 180);
			 if(Car.transform.position.x >= 5.9f)
			 Car.transform.rotation = new Quaternion (0, 0, 0, 180);}
			 }

			
				if(SwipeL == 1){
				 Vector3 Pos2 = new Vector3 (-6f, transform.position.y, transform.position.z);
				 
				 if(Car.transform.position.x > 0){
					 Vector3 Pos1 = transform.position;
					Pos2 = new Vector3 (0f, transform.position.y, transform.position.z);
					transform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);
					Car.transform.rotation = new Quaternion (0, -18, 0, 180);
					if(Car.transform.position.x <= 0.1f){
			 Car.transform.rotation = new Quaternion (0, 0, 0, 180);
			 	 SwipeL = 0;
			PlayerPrefs.SetInt("swipeL",SwipeL);
					}
			}
				else{
				Vector3 Pos1 = transform.position;
        transform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);

			 Car.transform.rotation = new Quaternion (0, -18, 0, 180);
			 if(Car.transform.position.x <= -5.9f)
			 Car.transform.rotation = new Quaternion (0, 0, 0, 180);
			 }
		}

			 
	}

	void LateUpdate(){
		if(Car.transform.position.y < -10f){
		Die();
		}
	}

	private void Die(){
		DieCanvas.SetActive(true);
		CanvasPanelGame.enabled = false;
	}

    [System.Obsolete]
    void OnTriggerEnter(Collider collider) {
	if (collider.gameObject.CompareTag("N2o")){
        Destroy(collider.gameObject);
		Speed = Speed*1.6f;
		Smoke.startColor = new Color(0,189,255,255);
		
		StartCoroutine("DoCheck");
		}
    }

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag("Enemy")){
		Die();
		}
	}
	
[System.Obsolete]
IEnumerator DoCheck() {
         yield return new WaitForSeconds(4f);
		 Speed = Speed/1.6f;
		 Smoke.startColor = new Color(167,167,167,255);
	}
}
