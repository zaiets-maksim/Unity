using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryB : MonoBehaviour, IPointerUpHandler {

	// Use this for initialization
	public GameObject Car;
	public GameObject DieCanvas;

	void Start(){

	Time.timeScale = 0f;
	DieCanvas.SetActive(true);
	}
	public void OnPointerUp(PointerEventData eventData) {
		Time.timeScale = 1f;
		DieCanvas.SetActive(false);

	SceneManager.LoadScene("GamePlay1", LoadSceneMode.Single);
	}
}
