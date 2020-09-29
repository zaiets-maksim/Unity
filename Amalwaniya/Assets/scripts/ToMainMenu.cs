using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject ToMainMenuB;
	public Animation anim;

	public void OnPointerDown(PointerEventData eventData){
		ToMainMenuB.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.03f);
	}

	public void OnPointerUp(PointerEventData eventData){
		ToMainMenuB.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.03f);
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
