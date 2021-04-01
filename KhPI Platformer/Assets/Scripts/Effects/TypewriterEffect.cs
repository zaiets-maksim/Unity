using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class TypewriterEffect : MonoBehaviour {
	[Range(0, 0.5f)]
	[SerializeField] private float _step;
	private string _text;
	private char[] _symblols;
	
	void Start () {
		_text = this.GetComponent<Text>().text;
		this.GetComponent<Text>().text = null;
		_symblols = _text.ToCharArray();
		StartCoroutine(TypeWriter());
	}

	private IEnumerator TypeWriter(){
		for(int i = 0; i < _symblols.Length; i++){
			this.GetComponent<Text>().text += _symblols[i].ToString();
			yield return new WaitForSeconds(_step);
		}
	}
}
