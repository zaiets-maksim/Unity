using System.Collections;
using Spine.Unity;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {
	private Rigidbody2D _rb;
	public SkeletonAnimation SkeletonAnimation;
	public AnimationReferenceAsset Idle, run;
	public GameObject Enemy;
	[SerializeField]
	private string _currentState;
	[SerializeField]
	private string _currentAnimation;
	public new BoxCollider2D collider2D;
	private int _randPositionX;
	private int _randomMove;
	private string _currentCoroutine;
	public Vector3 CurrentDirection;
	private static int _speed;
	private void Start () {
		_rb = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<BoxCollider2D>();
	}
	
	private void LateUpdate() {
		if(ManagerEnemies.SelectedEnemy == Enemy.name && Enemy.transform.position.x == 45){
			StopCoroutine(_currentCoroutine);
			StartCoroutine("MoveToStart");
		}
	}

	public int GetSpeed{
		get {return _speed;}
		set{_speed = value;}
	}

	public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale){

		if(animation.name.Equals(_currentAnimation)){
			return;
		}
		SkeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;;
		_currentAnimation = animation.name;
	}

	public void SetCharacterState(string state){

		if(state.Equals("run"))
		{
			SetAnimation(run, true, 1f);
		}
		else if(state.Equals("Idle"))
		{
			SetAnimation(Idle, true, 1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
	if (other.gameObject.CompareTag("SnowBall")){
		StopCoroutine(_currentCoroutine);
		StartCoroutine("MoveToExit");
		}
	}

	private void Stop(){
		_rb.velocity = Vector2.zero;
		SetCharacterState("Idle");		
	}
	private IEnumerator MoveToStart(){
		_currentCoroutine = "MoveToStart";
	
		_randPositionX = Random.Range(13, 24);
		transform.localScale = new Vector3(-0.7f, 0.7f);
		CurrentDirection= new Vector3(-0.7f, 0.7f);
		SetCharacterState("run");

		while(transform.position.x > _randPositionX){
		_rb.velocity = new Vector2(-_speed, _rb.velocity.y);
		yield return new WaitForSeconds(.5f);}
		
		_rb.velocity = Vector2.zero;
		if(_randPositionX > 22 || _randPositionX < 14)
			StartCoroutine("Stay");
				else
					StartCoroutine("Move");
	}

	private IEnumerator MoveToExit(){
		_currentCoroutine = "MoveToExit";

		transform.localScale = new Vector3(0.7f, 0.7f);
		CurrentDirection= new Vector3(0.7f, 0.7f);
		SetCharacterState("run");
		for(;transform.position.x < 45 ; ){
		_rb.velocity = new Vector2(_speed, _rb.velocity.y);
		yield return new WaitForSeconds(.5f);}
		_rb.velocity = Vector2.zero;
		transform.position = new Vector2(45, -4.336336f);
		Enemy.SetActive(false);
	}

	private IEnumerator Move(){
		_currentCoroutine = "Move";

		_randomMove = Random.Range(13, 32);

		if(transform.position.x < _randomMove){
		transform.localScale = new Vector3(0.7f, 0.7f);
		CurrentDirection = new Vector3(0.7f, 0.7f);
		SetCharacterState("run");

			for(;transform.position.x < _randomMove ; ){
			_rb.velocity = new Vector2(_speed, _rb.velocity.y);
			yield return new WaitForSeconds(.5f);
			}
		}
		else{
			transform.localScale = new Vector3(-0.7f, 0.7f);
			CurrentDirection = new Vector3(-0.7f, 0.7f);
			SetCharacterState("run");
			
			for(;transform.position.x > _randomMove ; ){
			_rb.velocity = new Vector2(-_speed , _rb.velocity.y);
			yield return new WaitForSeconds(.5f);
			}
		}

		_rb.velocity = Vector2.zero;
		if((_randomMove > 30 && _rb.velocity == Vector2.zero) || (_randomMove < 15 && _rb.velocity == Vector2.zero)){
			StartCoroutine("Stay");
			StopCoroutine("Move");}
		else
			StartCoroutine("Move");
	}

	private IEnumerator Stay(){
		_currentCoroutine = "Stay";
		Stop();
		int _randTime = Random.Range(1, 5);
		yield return new WaitForSeconds(_randTime);
		StartCoroutine("Move");
	}
}