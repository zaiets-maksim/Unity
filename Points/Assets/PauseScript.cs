using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PauseScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Canvas canvas;
	public GameObject ButtonResume;
	public GameObject ButtonPause;
	public static int check = 1;

	void Start () {
		canvas.enabled = false;

	}

	public void OnPointerDown(PointerEventData eventData){
		ButtonPause.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);

	}

	public void OnPointerUp(PointerEventData eventData){
		ButtonPause.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		canvas.enabled = true;
		ButtonPause.SetActive (false);
		ButtonResume.SetActive (true);
		check = 0;
		Time.timeScale = 0f;

	}
}
