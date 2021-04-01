using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToAddPoints : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Text HitPointsText;
	private int _currentHitPoints;
	public void OnPointerDown(PointerEventData eventData){
		this.transform.localScale = new Vector2 (0.95f, 0.95f);
	}

	public void OnPointerUp(PointerEventData eventData){
		this.transform.localScale = new Vector2 (1f, 1f);

		_currentHitPoints = Convert.ToInt32(HitPointsText.text);
		if(_currentHitPoints == 10)
			return;
			else
		HitPointsText.text = (++_currentHitPoints).ToString();
	}
}
