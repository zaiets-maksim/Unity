using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
public static int _var; //суперглобальная переменная
public Text Counter;
public GameObject Car;
Transform _myTransform;
	void Start () {
		_myTransform = Car.GetComponent<Transform>();
	}
	
	void FixedUpdate(){
		_var = (int)(_myTransform.position.z);
		 Counter.text = _var.ToString();
		 //PlayerPrefs.SetInt("newRecord", _var);
	}
}
