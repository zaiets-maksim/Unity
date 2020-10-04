using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreRecord : MonoBehaviour {

	int _oldRecprd;
	int _newRecord;
	public Text RecordScore;
	void Start () {
		_newRecord = PlayerPrefs.GetInt("newRecord");
		RecordScore.text = "Record: "+_newRecord.ToString();
	}
}
