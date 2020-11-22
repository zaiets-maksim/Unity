using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization
	public GameObject Car;
	public GameObject DieCanvas;

	void Start(){

	Time.timeScale = 0f;
	DieCanvas.SetActive(true);
	}
	public void OnPointerDown(PointerEventData eventData){
	this.transform.localScale = new Vector2 (0.97f, 0.97f);
	}
	
	public void OnPointerUp(PointerEventData eventData) {
		Time.timeScale = 1f;
		this.transform.localScale = new Vector2 (1f, 1f);
		DieCanvas.SetActive(false);

	SceneManager.LoadScene("GamePlay1", LoadSceneMode.Single);
	}
}
