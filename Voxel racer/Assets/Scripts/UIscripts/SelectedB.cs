using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization
	public GameObject MainCar;
	public int _currentSelectedCar;
	MeshFilter _currentMeshMainCar;
	public Mesh[] ArrayMeshMainCars;
	public Button Selected;

	void Start () {
	_currentMeshMainCar = MainCar.GetComponent<MeshFilter>();

	}

		public void OnPointerDown(PointerEventData eventData){
	this.transform.localScale = new Vector2 (0.97f, 0.97f);
	}

	public void OnPointerUp(PointerEventData eventData){
	this.transform.localScale = new Vector2 (1f, 1f);
	_currentMeshMainCar.mesh = ArrayMeshMainCars[SnapScrolling._selectedID];
	_currentSelectedCar = SnapScrolling._selectedID;

	Selected.enabled = false;

	
	}
	void LateUpdate() {
		if(_currentSelectedCar != SnapScrolling._selectedID)
		Selected.enabled = true;
		else
		Selected.enabled = false;
	}
	
	// Update is called once per frame
}
