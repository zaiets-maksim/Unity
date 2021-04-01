using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStateSwitcher : MonoBehaviour {
	[SerializeField] private GameObject ButtonToEnter;
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player"))
			ButtonToEnter.name = this.gameObject.tag;
			ButtonToEnter.SetActive(true);
			OnBuildingExit();
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player"))
			ButtonToEnter.SetActive(false);
	}

	private void OnBuildingExit(){
		Regex regex = new Regex(@"\bExit\w+");

		string nameTag = this.gameObject.tag;
		if (regex.IsMatch(nameTag))
			ButtonToEnter.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Exit";
			else
			ButtonToEnter.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Enter";

		// if(nameTag.
		// 
		
	}
}
