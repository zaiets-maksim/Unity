using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class biasJ : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	string pressingJ;
	public void OnPointerDown(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);
		pressingJ = "true";
		PlayerPrefs.SetString ("pressingKeyJ", pressingJ);
	}

	public void OnPointerUp(PointerEventData eventData){
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		pressingJ = "false";
		PlayerPrefs.SetString ("pressingKeyJ", pressingJ);
	}
}
