using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private PlayerModel Model;
	[SerializeField] private PlayerView View;
	private void FixedUpdate() {
		CharacterLogic();	
	}

	public void CharacterLogic(){
		Model.Movement = SimpleInput.GetAxis("Horizontal");
		View.SetAnimation();
	}
}
