using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Resume : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject ButtonResume;
	public GameObject ButtonPause;
	public Canvas canvas;
	
	
	public void OnPointerDown(PointerEventData eventData){
		ButtonResume.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);

	}

	public void OnPointerUp(PointerEventData eventData){
		ButtonResume.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		//ButtonResume.SetActive (false);
		canvas.enabled = false;
		ButtonPause.SetActive (true);
		PauseScript.check = 1;
		Time.timeScale = 1f;
	}
}
