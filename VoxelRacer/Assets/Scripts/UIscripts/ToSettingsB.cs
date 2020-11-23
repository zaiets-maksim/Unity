using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToSettingsB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Button Settings;
	public Button Menu;
	public Button Shop;
	public Button Info;
	public GameObject ButtonOutline;
	public GameObject WindowSettings;
	Animator _animator;
	public Toggle EnableShowFPSToggle;
	public Text FPStext;

	void Start(){
	_animator = WindowSettings.GetComponent<Animator>();	
	_animator.speed = 0;
	}
	void LateUpdate() {
		if(!EnableShowFPSToggle.isOn)
			FPStext.enabled = false;
			else
				FPStext.enabled = true;
	}

		public void OnPointerDown(PointerEventData eventData) {
			this.transform.localScale = new Vector2 (0.97f, 0.97f);

		Settings.interactable = false;
		Menu.interactable = true;
		Shop.interactable = true;
		Info.interactable = true;
		
}
	public void OnPointerUp(PointerEventData eventData) {
		this.transform.localScale = new Vector2 (1f, 1f);
		ButtonOutline.transform.position = Settings.transform.position;
		WindowSettings.SetActive(true);
		_animator.Play("Pop-upWindowSettings",0, 0f);
		_animator.speed = 1;
}
}
