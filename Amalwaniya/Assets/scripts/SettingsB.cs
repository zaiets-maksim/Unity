using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject Settings;

	public void OnPointerDown(PointerEventData eventData){
		Settings.transform.localScale = new Vector2 (2.05f, 2.05f);
	}

	public void OnPointerUp(PointerEventData eventData){
		Settings.transform.localScale = new Vector2 (2f, 2f);
	}
}
