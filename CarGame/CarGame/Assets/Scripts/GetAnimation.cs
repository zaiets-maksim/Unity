using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnimation : MonoBehaviour {

	Animation _anim;
	int _newRecord;
	void Start () {
		_newRecord = PlayerPrefs.GetInt("newRecord");
		_anim = GetComponent<Animation>();
	}
	
	void LateUpdate () {
		if(ScoreCounter._var > _newRecord){
		_anim.Play("NewRecordAnim");
		}
	}
}
