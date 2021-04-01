using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToPause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	// Use this for initialization
	public Canvas Canvas;
	public GameObject ButtonPause;
	public GameObject ButtonResume;
	
	void Start () {
		Canvas.enabled = false;
	}

	public void OnPointerDown(PointerEventData eventData){
		ButtonPause.transform.localScale = new Vector2 (0.95f, 0.95f);
	}
	
	public void OnPointerUp(PointerEventData eventData){
		ButtonPause.transform.localScale = new Vector2 (1f, 1f);
		Canvas.enabled = true;
		ButtonResume.SetActive (true);
		Time.timeScale = 0f;

	}
	
}
