using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private float timer;
	public Text RoundTimeText;
	
	private void LateUpdate () {
		timer = timer + 1 * Time.deltaTime;
		RoundTimeText.text = "Round time: " + ((int)timer).ToString();
	}
}
