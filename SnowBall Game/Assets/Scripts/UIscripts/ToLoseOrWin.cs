	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToLoseOrWin : MonoBehaviour {

	public Canvas CanvasFinalResult;
	public Canvas CanvasUI;
	public GameObject ButtonMenu;
	public GameObject ButtonRestart;
	public Text InformationalText;
	public Text FinalResultText;
	private int _countStars;
	public GameObject NotificationBox;
	private static int _pointsRequiredToWin;
	public GameObject[] Stars = new GameObject[3];
	public GameObject[] StarNonActive = new GameObject[3];
	public GameObject[] BrokenHearts = new GameObject[3];
	public GameObject[] Hearts = new GameObject[3];
	
	void LateUpdate () {
		if(SnowballThrower.Points == _pointsRequiredToWin || SnowballThrower.Points > _pointsRequiredToWin){
			StartCoroutine("GoWinWindow");
			this.enabled = false;
		}
		if(!Hearts[0].activeInHierarchy)
			StartCoroutine("GoLoseWindow");
	}

	public int GetPointsRequiredToWin{
		get {return _pointsRequiredToWin;}
		set{_pointsRequiredToWin = value;}
	}

	IEnumerator GoWinWindow(){
		NotificationBox.SetActive(false);
		CanvasUI.enabled = false;
		CanvasFinalResult.enabled = true;
		ButtonRestart.SetActive(false);
		FinalResultText.text = "Victory!";

			for(int i = 0; i < Hearts.Length; i++){
				if(Hearts[i].activeInHierarchy){
					yield return new WaitForSeconds(.5f);
					Stars[i].SetActive(true);
					_countStars++;
				}
			}
		yield return new WaitForSeconds(.4f);
		InformationalText.text = "You got " + _countStars + " stars!"+ "\n" + "You got " + SnowballThrower.Points + " points";
		StopCoroutine("GoWin");
	}

	IEnumerator GoLoseWindow(){
		NotificationBox.SetActive(false);
		CanvasUI.enabled = false;
		CanvasFinalResult.enabled = true;
		ButtonMenu.SetActive(false);
		FinalResultText.text = "Game Over";

			for(int i = 0; i < BrokenHearts.Length; i++){
				StarNonActive[i].SetActive(false);
				BrokenHearts[i].SetActive(true);
			}
		yield return new WaitForSeconds(.4f);
		InformationalText.text = "You got " + SnowballThrower.Points + " points";
		StopCoroutine("GoWin");
	}
}
