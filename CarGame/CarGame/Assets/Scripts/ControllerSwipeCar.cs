using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerSwipeCar : MonoBehaviour, IBeginDragHandler, IDragHandler {
	public GameObject Car;
		int SwipeR = 0;
		int SwipeL = 0;
		
	void Start () {
		PlayerPrefs.SetInt("swipeR",SwipeR);
		PlayerPrefs.SetInt("swipeL",SwipeL);
	}
	public void OnBeginDrag(PointerEventData eventData){
		if((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y))){

		if(eventData.delta.x > 0){

		SwipeR = 1;
		PlayerPrefs.SetInt("swipeR",SwipeR);
		}else{
			SwipeR = 0;
		PlayerPrefs.SetInt("swipeR",SwipeR);
		}
		

		if(eventData.delta.x < 0){
			
		SwipeL = 1;
		PlayerPrefs.SetInt("swipeL",SwipeL);
		}else{
			SwipeL = 0;
		PlayerPrefs.SetInt("swipeL",SwipeL);
			}
		}
	}
		

	public void OnDrag(PointerEventData eventData){

	}
}
