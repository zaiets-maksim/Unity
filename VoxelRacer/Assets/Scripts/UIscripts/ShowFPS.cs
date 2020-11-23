using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour {
public static float fps;
public Text FpsText; 
	void Start(){
	StartCoroutine("DoCheck");
	}
	void LateUpdate () {
		if(fps < 30)
		FpsText.color = Color.red;
		if(fps > 30 && fps < 50)
		FpsText.color = Color.yellow;
		if(fps > 50)
		FpsText.color = Color.green;
	}

	IEnumerator DoCheck(){
		for(;;){
		fps = 1.0f / Time.deltaTime;
		FpsText.text = ((int)fps).ToString();
		yield return new WaitForSeconds(.5f);
		}
	
	}
}
