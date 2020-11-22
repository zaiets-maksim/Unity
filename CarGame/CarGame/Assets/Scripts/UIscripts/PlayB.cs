﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Canvas CanvasMainMenu;
	// Use this for initialization
	public Canvas CanvasPanelGame;
	public GameObject DieCanvas;
	public Camera Camera3D;
	public Canvas Canvas3D;
	Animation _anim;
	Animation _anim1;
	public GameObject Wall;
	public GameObject Wall1;

	void Start(){
	DieCanvas.SetActive(false);
	Time.timeScale = 0f;
	
	CanvasPanelGame.enabled = false;
	_anim = Wall.GetComponent<Animation>();
	_anim1 = Wall1.GetComponent<Animation>();

	}
	public void OnPointerDown(PointerEventData eventData){
	this.transform.localScale = new Vector2 (0.97f, 0.97f);
	}

	public void OnPointerUp(PointerEventData eventData){
	this.transform.localScale = new Vector2 (1f, 1f);
	
	_anim.Play("ClosingTheWall");
	_anim1.Play("ClosingTheWall1");

	Time.timeScale = 1f;
	Invoke("OtherActions",1.7f);
	
	}
	void OtherActions(){
	
	CanvasMainMenu.enabled = false;
	Camera3D.enabled = false;
	Canvas3D.enabled = false;
	CanvasPanelGame.enabled = true;
	}

		

}
