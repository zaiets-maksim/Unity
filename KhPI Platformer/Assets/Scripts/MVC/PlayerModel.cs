using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
	private Rigidbody2D _rb;

	[Range(1, 10)]
	[SerializeField] private int _speed;
	public int Speed { get {return _speed; } set { _speed = value; }}
	private float _movement;
    public float Movement { get {return _movement; } set { _movement = value; }}

	void Start () {
		_rb = GetComponent<Rigidbody2D>();
	}

	public void Move(){
		_rb.velocity = new Vector2(_movement * _speed, _rb.velocity.y); 
	}
}


