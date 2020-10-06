using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitB : MonoBehaviour, IPointerUpHandler {

	public void OnPointerUp(PointerEventData eventData) {
	Application.Quit();
	}
}
