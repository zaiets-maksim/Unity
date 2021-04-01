using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToResume : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Canvas Canvas;
	public GameObject ButtonPause;
	public GameObject ButtonResume;
	
	public void OnPointerDown(PointerEventData eventData){
		ButtonResume.transform.localScale = new Vector2 (0.95f, 0.95f);
	}

	public void OnPointerUp(PointerEventData eventData){
		ButtonResume.transform.localScale = new Vector2 (1f, 1f);
		Canvas.enabled = false;
		ButtonResume.SetActive (false);
		Time.timeScale = 1f;
	}
	
}
