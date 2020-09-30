using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
bool _isTimerWork;
float _memTime;
float _timer;
int _var;
public Text Counter;
public GameObject Car;
	void Start () {
		_isTimerWork = true;
		_memTime = Time.timeSinceLevelLoad;
	}
	

	void Update () {
//Где-то на карутине или апдейте
	if (_isTimerWork) {
   //var = (int)((Time.time - _memTime)*17.5f);
   _timer = (Time.timeSinceLevelLoad - _memTime)*17.5f;
   _var = (int)_timer;
   //Counter.text = Timer.ToString();
   Counter.text = _var.ToString();
   if (Car.transform.position.y <= -10f) {
      _isTimerWork = false;
	_timer = Time.timeSinceLevelLoad - _memTime;
    		}
		}
	}
}
