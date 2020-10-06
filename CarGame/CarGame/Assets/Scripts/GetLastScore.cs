using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLastScore : MonoBehaviour {

	public Text TextLastScore; 
	void Start () {
		TextLastScore.text = ScoreCounter._var.ToString();
	}
}
