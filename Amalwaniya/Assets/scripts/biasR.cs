using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class biasR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	string pressingR;
	public void OnPointerDown(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);
		pressingR = "true";
		PlayerPrefs.SetString ("pressingKeyR", pressingR);
	}

	public void OnPointerUp(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		pressingR = "false";
		PlayerPrefs.SetString ("pressingKeyR", pressingR);
	}
}
