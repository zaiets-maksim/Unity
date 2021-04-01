using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ToExit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public void OnPointerDown(PointerEventData eventData){
		this.transform.localScale = new Vector2 (0.95f, 0.95f);
	}

	public void OnPointerUp(PointerEventData eventData){
		this.transform.localScale = new Vector2 (1f, 1f);
		Application.Quit();
	}
}
