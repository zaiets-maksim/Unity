using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour {
	public GameObject[] ArrayMainCars;
	private bool _isScrolling;
	private RectTransform _contentRect;
	private Vector2[] _pansPos;
	public static int _selectedID;
	private Vector2 _contentVector;
	[Range(0f, 20f)]
	public float BindingSpeed;
	public ScrollRect ScrollRect;
	public Image ArrowR;
	public Image ArrowL;
	void Start () {
	_contentRect = GetComponent<RectTransform>();
	_pansPos = new Vector2[ArrayMainCars.Length];
	for(int i = 0; i < ArrayMainCars.Length; i++){
		_pansPos[i] = -ArrayMainCars[i].transform.localPosition;
		_pansPos[i].x += 40f;
	}
	}
	void LateUpdate(){
		float _nearestPos = float.MaxValue;
		for(int i = 0; i < ArrayMainCars.Length; i++){
			float distance = Math.Abs(_contentRect.anchoredPosition.x - _pansPos[i].x);
			if(distance < _nearestPos){
				_nearestPos = distance;
				_selectedID = i;
			}

		}
		float _scrollVelocity = Mathf.Abs(ScrollRect.velocity.x);
		//Debug.Log(_scrollVelocity);
		if(_scrollVelocity > 400 && !_isScrolling) ScrollRect.inertia = false;
		if(_isScrolling || _scrollVelocity > 400){
			ArrowR.enabled = false;
			ArrowL.enabled = false;
			return;}else{
			ArrowR.enabled = true;
			ArrowL.enabled = true;
			}
		_contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _pansPos[_selectedID].x, BindingSpeed * Time.fixedDeltaTime);
		_contentRect.anchoredPosition = _contentVector;
	}
	public void Scrolling(bool scroll){
		_isScrolling = scroll;
	}
}
