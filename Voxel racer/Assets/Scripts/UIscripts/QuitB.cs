using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public void OnPointerDown(PointerEventData eventData){
	this.transform.localScale = new Vector2 (0.97f, 0.97f);
	}
	public void OnPointerUp(PointerEventData eventData) {
	this.transform.localScale = new Vector2 (1f, 1f);
	Application.Quit();
	}
	
}
