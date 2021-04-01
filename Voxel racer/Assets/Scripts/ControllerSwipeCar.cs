using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerSwipeCar : MonoBehaviour, IBeginDragHandler, IDragHandler {
	public GameObject Car;
	public static int SwipeR = 0;
	public static int SwipeL = 0;
		
	public void OnBeginDrag(PointerEventData eventData){
		if((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y))){

		if(eventData.delta.x > 0){
			SwipeR = 1;
		}else{
			SwipeR = 0;
		}
		

		if(eventData.delta.x < 0){
			SwipeL = 1;
		}else{
			SwipeL = 0;
			}
		}
	}
	public void OnDrag(PointerEventData eventData){}
}
