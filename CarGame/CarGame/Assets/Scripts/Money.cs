using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Money : MonoBehaviour {

	public Text TextNumberOfCoinsInMenu;
	public Text TextNumberOfCoinsInGame;
	private int _numberOfCoins;

	void OnTriggerEnter(Collider _money) {
		if (_money.gameObject.CompareTag("Car")){
		++_numberOfCoins;
		TextNumberOfCoinsInMenu.text = _numberOfCoins.ToString();
		TextNumberOfCoinsInGame.text = _numberOfCoins.ToString();
        Destroy(this.gameObject);}
    }
}
