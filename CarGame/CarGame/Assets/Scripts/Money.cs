using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Money : MonoBehaviour {

	public Text TextNumberOfCoinsInMenu;
	public Text TextNumberOfCoinsInGame;
	public Text TextNumberOfCoinsInDieMenu;
	public static int _numberOfCoins;
	public GameObject Car;

	void Start(){
		_numberOfCoins = PlayerPrefs.GetInt("_numberOfCoins");
		TextNumberOfCoinsInGame.text = _numberOfCoins.ToString();
	}
	void OnTriggerEnter(Collider _money) {
		if (_money.gameObject.CompareTag("Car")){
		++_numberOfCoins;
		TextNumberOfCoinsInMenu.text = _numberOfCoins.ToString();
		TextNumberOfCoinsInGame.text = _numberOfCoins.ToString();
		TextNumberOfCoinsInDieMenu.text = _numberOfCoins.ToString();
		PlayerPrefs.SetInt("_numberOfCoins", _numberOfCoins);
		this.gameObject.SetActive(false);
        }
    }

	void LateUpdate() {
		this.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
		
		if((Car.transform.position.z - 15) > this.transform.position.z)
		this.gameObject.SetActive(false);
	}
}
