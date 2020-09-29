using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class biasL : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	string pressingL;
	public void OnPointerDown(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);
		pressingL = "true";
		PlayerPrefs.SetString ("pressingKeyL", pressingL);
	}

	public void OnPointerUp(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		pressingL = "false";
		PlayerPrefs.SetString ("pressingKeyL", pressingL);
	}
}
