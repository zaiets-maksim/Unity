using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {
	[SerializeField] private PlayerModel Model{ get; set; }
	[SerializeField] private GameObject _player;
	private Animator _anim;
	public bool _isTouchGround;
	[SerializeField] private RectTransform ButtonLeft;
	[SerializeField] private RectTransform ButtonRight;
	private Vector2 _buttonScale;
	private void Start() {
		Model = _player.GetComponent<PlayerModel>();
		_anim = _player.GetComponent<Animator>();
		_buttonScale = new Vector2(ButtonRight.transform.localScale.x, ButtonRight.transform.localScale.y); 
	}
	
	public void SetAnimation(){
		ButtonLeft.localScale = new Vector2(1, 1);
		ButtonRight.localScale = new Vector2(1, 1);
		if(Model.Movement != 0){
			Model.Move();
			
			if(!_anim.GetBool("jump")){
				_anim.SetBool("isRunning", true);
				
				if(Model.Movement > 0){
					_player.transform.localScale = new Vector2(_player.transform.localScale.y, _player.transform.localScale.y);
					ButtonRight.transform.localScale = _buttonScale * 0.95f;
				}
				else{
					_player.transform.localScale = new Vector2(-_player.transform.localScale.y, _player.transform.localScale.y);
					ButtonLeft.transform.localScale = _buttonScale * 0.95f;
				}
			}
		}else{
		_anim.SetBool("isRunning", false);
		}
	}
}
