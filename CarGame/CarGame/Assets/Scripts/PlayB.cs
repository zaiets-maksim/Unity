using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayB : MonoBehaviour, IPointerUpHandler {
	public Canvas CanvasMainMenu;
	// Use this for initialization
	public Canvas CanvasPanelGame;
	public GameObject DieCanvas;
	void Start(){
	DieCanvas.SetActive(false);
	Time.timeScale = 0f;
	CanvasPanelGame.enabled = false;
	}

	public void OnPointerUp(PointerEventData eventData){
	Time.timeScale = 1f;
	CanvasMainMenu.enabled = false;
	CanvasPanelGame.enabled = true;
	}

		

}
