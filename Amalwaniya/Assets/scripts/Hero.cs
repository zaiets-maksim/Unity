using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hero : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject cat;
	new public Camera camera;
	bool rotate = false;
	bool IsGround;
	float Run;
	string pressingR;
	string pressingL;
	string pressingJ;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		
		pressingR = PlayerPrefs.GetString ("pressingKeyR");
		pressingL = PlayerPrefs.GetString ("pressingKeyL");
		pressingJ = PlayerPrefs.GetString ("pressingKeyJ");
		camera.transform.position = new Vector3 (cat.transform.position.x, (cat.transform.position.y + 3.33f), camera.transform.position.z);

		if (pressingR == "true") {
			if (!rotate)
				cat.transform.Rotate (0, 180, 0);
			rotate = true;
			rb.velocity = new Vector2 (5, rb.velocity.y);

		} else if (pressingL == "true") {
			if (rotate)
				cat.transform.Rotate (0, 180, 0);
			rotate = false;
			rb.velocity = new Vector2 (-5, rb.velocity.y);

		}
		if (pressingJ == "true"  && IsGround) {
			rb.velocity = new Vector2 (rb.velocity.x, 5);
			IsGround = false;
		}
	}

		//Jump();
		/*if (Input.touchCount > 0){//Input.GetKey (KeyCode.D)) {
			Touch MyTouch = Input.GetTouch(0);
			if(MyTouch.position.x >= 1440){

			if(!rotate)
				cat.transform.Rotate(0, 180, 0);
			rotate = true;
			
			rb.AddForce (new Vector3 (7, 0,-10));
				IsGround = true;
				Jump();
			}
			//camera.transform.position += new Vector3 (0.075f, 0, 0);
		}
		if (Input.touchCount > 0){//Input.GetKey (KeyCode.A)) {
			Touch MyTouch = Input.GetTouch(0);
			if(MyTouch.position.x <= 480){
			if(rotate)
				cat.transform.Rotate(0, 180, 0);
			rotate = false;
			rb.AddForce (new Vector3 (-7, 0, 10));
				IsGround = true;
				Jump();
			}
			//camera.transform.position += new Vector3 (-0.075f, 0, 0);

		}
	}*/
	public void IsJump(){
		IsGround = false;
	}
		
	private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("ground") || collision.gameObject.CompareTag ("rock")) {
			IsGround = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D myTrigger) 
	{
		if (myTrigger.gameObject.CompareTag ("fruit")) {
			myTrigger.gameObject.SetActive(false);
		}
	}

}
	/*void Jump(){
		if (Input.touchCount > 0 && IsGround) {
			IsGround = false;
			Touch MyTouch = Input.GetTouch(0);
			//if(MyTouch.position.x >= 480 && MyTouch.position.x <= 1440){
			if(MyTouch.position.x > 1646 && MyTouch.position.y < 225){
				rb.AddForce (new Vector3 (0, 25, -10));
			}
		}
	}*/
