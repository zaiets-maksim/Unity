using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreRecord : MonoBehaviour {

	int _newRecord;
	public Text RecordScore;
	public Text TextNumberOfCoinsInMenu;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		_newRecord = PlayerPrefs.GetInt("newRecord");
		RecordScore.text = "Record: "+_newRecord.ToString();

		Money._numberOfCoins = PlayerPrefs.GetInt("_numberOfCoins");
		TextNumberOfCoinsInMenu.text = Money._numberOfCoins.ToString();
		

	}
}
