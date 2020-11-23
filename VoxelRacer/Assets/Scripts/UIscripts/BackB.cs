using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject Back;
		public void OnPointerDown(PointerEventData eventData) {
			this.transform.localScale = new Vector2 (0.97f, 0.97f);
	
}
	public void OnPointerUp(PointerEventData eventData) {
		this.transform.localScale = new Vector2 (1f, 1f);
}

	public void CloseWindow(){
	Back.SetActive(false);
	}
}
