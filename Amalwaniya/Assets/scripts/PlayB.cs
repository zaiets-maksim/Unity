using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject Play;
	// Use this for initialization

	public void OnPointerDown(PointerEventData eventData){
		//Play.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);
		Play.transform.localScale = new Vector2 (2.05f, 2.05f);
	}

	public void OnPointerUp(PointerEventData eventData){
		//Play.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		Play.transform.localScale = new Vector2 (2f, 2f);
		SceneManager.LoadScene("demo", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}

		

}
