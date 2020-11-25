﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToMenuB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	public Button Settings;
	public Button Menu;
	public Button Shop;
	public Button Info;
	public GameObject ButtonOutline;
		public void OnPointerDown(PointerEventData eventData) {
			this.transform.localScale = new Vector2 (0.97f, 0.97f);
	
		Settings.interactable = true;
		Menu.interactable = false;
		Shop.interactable = true;
		Info.interactable = true;
}
	public void OnPointerUp(PointerEventData eventData) {
		this.transform.localScale = new Vector2 (1f, 1f);
		ButtonOutline.transform.position = Menu.transform.position;
}

public void  ReturnToBack(){
		Settings.interactable = true;
		Menu.interactable = false;
		Shop.interactable = true;
		Info.interactable = true;
		ButtonOutline.transform.position = Menu.transform.position;
}
}