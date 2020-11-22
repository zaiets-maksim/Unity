using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToInfoB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Button Settings;
	public Button Menu;
	public Button Shop;
	public Button Info;
	public GameObject ButtonOutline;
	public GameObject WindowInfo;
	Animator _animator;
	public Button Ok;
	void Start() {
	_animator = WindowInfo.GetComponent<Animator>();	
	_animator.speed = 0;
	}
		public void OnPointerDown(PointerEventData eventData) {
			this.transform.localScale = new Vector2 (0.97f, 0.97f);

		Settings.interactable = true;
		Menu.interactable = true;
		Shop.interactable = true;
		Info.interactable = false;
}
	public void OnPointerUp(PointerEventData eventData) {
		this.transform.localScale = new Vector2 (1f, 1f);
		ButtonOutline.transform.position = Info.transform.position;
		WindowInfo.SetActive(true);
		_animator.Play("Pop-upWindow",0, 0f);
		_animator.speed = 1;

}
}
