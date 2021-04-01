using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	GameObject ListButtons;
	public GameObject listAnimationsInMenu;
	public GameObject ButtonOutline;
	private int _numberThisChild;
	GameObject _window;

	// public GameObject WindowInfo;
	// public GameObject Menu;

	void Start(){
	ListButtons = this.transform.parent.gameObject;
	}
	
	public void OnPointerDown(PointerEventData eventData) {

		this.transform.localScale = new Vector2 (0.97f, 0.97f);
		this.gameObject.GetComponent<Button>().interactable = false;

		for(int i = 0; i < ListButtons.transform.childCount; i++){
			if(ListButtons.transform.GetChild(i).name == this.gameObject.name)
			_numberThisChild = i;

			else
			ListButtons.transform.GetChild(i).GetComponent<Button>().interactable = true;
		}

		// Settings.interactable = true;
		// Menu.interactable = true;
		// Shop.interactable = true;
		// Info.interactable = false;
	}
	public void OnPointerUp(PointerEventData eventData) {

		this.transform.localScale = new Vector2 (1f, 1f);

		ButtonOutline.transform.position = this.gameObject.transform.position;

		if(this.gameObject.name == "Menu")
		return;

		_window = listAnimationsInMenu.transform.GetChild(_numberThisChild).gameObject;
		_window.gameObject.SetActive(true);
		_window.GetComponent<Animation>().Play();

		// WindowInfo.SetActive(true);
		// _anim.Play("Pop-upWindowInfo");
	}

    [System.Obsolete]
    public void ReturnToBack(){
		for(int i = 0; i < ListButtons.transform.childCount; i++){
			if(ListButtons.transform.GetChild(i).name == "Menu")
			ListButtons.transform.GetChild(i).GetComponent<Button>().interactable = true;
			else
			ListButtons.transform.GetChild(i).GetComponent<Button>().interactable = false;
		}
		// ButtonOutline.transform.position = Menu.transform.position;
		//_window.GetComponent<Animation>().Stop();
		ButtonOutline.transform.position = ListButtons.transform.FindChild("Menu").gameObject.transform.position;
}
}
