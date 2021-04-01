using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	[Range(0, 30)] 
	[SerializeField] private int _timeLeft;
	private readonly int _step = 1;
	[SerializeField] Text _timerText;
	[SerializeField] GameObject _resultCanvas;
	[SerializeField] Button _resultButton;
	[SerializeField] Text _resultText;
	
	private void Start() {
		_timerText.text = _timeLeft.ToString();
		StartCoroutine("СountDown");
	}


	private IEnumerator СountDown(){
		yield return new WaitForSeconds(_step);
		
		if(_timeLeft > 0 && !_resultCanvas.activeInHierarchy){
			_timeLeft -= _step;
			_timerText.text = _timeLeft.ToString();
			StartCoroutine("СountDown");
		}
		if(_timeLeft.Equals(0)){
			_resultButton.name = "ExitToGAK";
			_resultButton.GetComponentInChildren<Text>().text = "Exit";
			_resultText.text = "You missed the exam!";
			_resultCanvas.SetActive(true);
		}
			
	}
}
