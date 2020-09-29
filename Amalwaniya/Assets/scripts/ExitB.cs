using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject Exit;

	public void OnPointerDown(PointerEventData eventData){
		Exit.transform.localScale = new Vector2 (2.05f, 2.05f);
	}

	public void OnPointerUp(PointerEventData eventData){
		Exit.transform.localScale = new Vector2 (2f, 2f);
		StartCoroutine(ToExit());
	}
	public IEnumerator ToExit(){
		yield return new WaitForSeconds (0.1f);
		Application.Quit ();
	}
}
