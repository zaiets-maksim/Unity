using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllCar : MonoBehaviour {
	public ParticleSystem Smoke;
	public Rigidbody Rb;
	public GameObject Car;
	private Camera _camera;
	public Slider Slider;
	public float Speed;
	private Vector2 Position;
	public GameObject DieCanvas;
	public Canvas CanvasPanelGame;
	int _swipeR = 0;
	int _swipeL = 0;
	Quaternion _CameraQuaternion;
	Quaternion _rotationRight;
	Quaternion _rotationLeft;
	Quaternion _rotationCenter;
	Transform _myTransform;
	Transform _cameraTransform;
	void Start () {
		_camera = Camera.main;
		Rb = GetComponent<Rigidbody>();
		_CameraQuaternion = new Quaternion(46.731f, 0, 0, 180);
		_rotationRight = new Quaternion (0, 18, 0, 180);
		_rotationLeft = new Quaternion (0, -18, 0, 180);
		_rotationCenter = new Quaternion (0, 0, 0, 180);
		Car.transform.rotation = _rotationCenter;
		_myTransform = GetComponent<Transform>();
		_cameraTransform = _camera.GetComponent<Transform>();
	}
	void FixedUpdate ()
	{	Speed += 0.005f;
		_cameraTransform.position = new Vector3 (_myTransform.position.x/3, (_myTransform.position.y + 26.3f), _myTransform.position.z -21.7f);
		_cameraTransform.rotation = _CameraQuaternion;
		
		Rb.velocity = new Vector3 (0, Rb.velocity.y, Speed);
	

			_swipeR = PlayerPrefs.GetInt("swipeR");
			_swipeL = PlayerPrefs.GetInt("swipeL");
	
			 if(_swipeR == 1){
				 Vector3 Pos2 = new Vector3 (6f, _myTransform.position.y, _myTransform.position.z);
				 
				 if(_myTransform.position.x < 0){
					 Vector3 Pos1 = _myTransform.position;
					Pos2 = new Vector3 (0f, _myTransform.position.y, _myTransform.position.z);
					_myTransform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);
					_myTransform.rotation = _rotationRight;
					if(_myTransform.position.x >= -0.1f){
			 _myTransform.rotation = _rotationCenter;
			 	 _swipeR = 0;
		PlayerPrefs.SetInt("swipeR",_swipeR);
				}
			}
				else{
				Vector3 Pos1 = _myTransform.position;
        _myTransform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);

			 _myTransform.rotation = _rotationRight;
			 if(_myTransform.position.x >= 5.9f)
			 _myTransform.rotation = _rotationCenter;}
			 }

	
				if(_swipeL == 1){
				 Vector3 Pos2 = new Vector3 (-6f, _myTransform.position.y, _myTransform.position.z);
				 
				 if(_myTransform.position.x > 0){
					 Vector3 Pos1 = _myTransform.position;
					Pos2 = new Vector3 (0f, _myTransform.position.y, _myTransform.position.z);
					_myTransform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);
					_myTransform.rotation = _rotationLeft;
					if(_myTransform.position.x <= 0.1f){
			 _myTransform.rotation = _rotationCenter;
			 	 _swipeL = 0;
			PlayerPrefs.SetInt("swipeL",_swipeL);
					}
			}
				else{
				Vector3 Pos1 = _myTransform.position;
        _myTransform.position = Vector3.MoveTowards (Pos1, Pos2, Time.deltaTime *17);

			 _myTransform.rotation = _rotationLeft;
			 if(_myTransform.position.x <= -5.9f)
			 _myTransform.rotation = _rotationCenter;
			 }
		}

			 
	}

	void LateUpdate(){
		if(_myTransform.position.y < -10f){
		Die();
		}
	}

	private void Die(){
		int _oldRecord = PlayerPrefs.GetInt("newRecord");

		if(_oldRecord < ScoreCounter._var)
		PlayerPrefs.SetInt("newRecord", ScoreCounter._var);
		
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
