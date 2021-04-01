using Spine.Unity;
using UnityEngine;

public class MainPlayer : MonoBehaviour {
	public GameObject Player;
	public SkeletonAnimation SkeletonAnimation;
	public AnimationReferenceAsset Idle, run, jump_idle;
	[SerializeField]
	private string _currentState;
	[SerializeField]
	private string _previousState;
	[SerializeField]
	private string _currentAnimation;
	new public Camera camera;
	[Range(0,5)]
	public int JumpForce;
	private static int _speed;
	[SerializeField]
	private float _movement;
	private Rigidbody2D _rb;
	public bool _isTouchGround;
	public static int isRotate;
	public RectTransform ButtonLeft;
	public RectTransform ButtonRight;
	public RectTransform ButtonJump;
	
	
	private void Start () {
		_currentState = "Idle";
		isRotate = 1;
		_rb = GetComponent<Rigidbody2D>();
		SetCharacterState(_currentState);
	}

	private void FixedUpdate () {
		Move();
		camera.transform.position = new Vector3 (Player.transform.position.x  + 0.5f + _movement / 1.7f, (Player.transform.position.y + 4.23032f) / 3, camera.transform.position.z);
		//Слежение камеры за главным персонажем
	}

	public int GetSpeed{
		get {return _speed;}
		set{_speed = value;}
	}

	public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale){

		if(animation.name.Equals(_currentAnimation))
			return;
		
		Spine.TrackEntry animationEntry = SkeletonAnimation.state.SetAnimation(0, animation, loop);
		animationEntry.TimeScale = timeScale;
		_currentAnimation = animation.name;
		animationEntry.Complete += AnimationEntry_Complete;
	}

    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry){

        if(_currentState.Equals("jump_idle"))
    		SetCharacterState(_previousState);
    }

    public void SetCharacterState(string state){

		if(state.Equals("run") && _isTouchGround){
			SetAnimation(run, true, 1f);
		}
		else if(state.Equals("jump_idle")){
			SetAnimation(jump_idle, false, 0.64f);
			_isTouchGround = false;
		}
		else if(state.Equals("Idle") &&_isTouchGround){
			SetAnimation(Idle, true, 1f);
		}
		_currentState = state;
	}

	public void Move(){
		_movement = SimpleInput.GetAxis("Horizontal");
		_rb.velocity = new Vector2(_movement * _speed, _rb.velocity.y);
		ButtonLeft.localScale = new Vector2(1.7f, 1.7f);
		ButtonRight.localScale = new Vector2(1.7f, 1.7f);

		if(_movement != 0){
			if(!_currentState.Equals("jump_idle"))
				SetCharacterState("run");
			
			if(_movement > 0){
				transform.localScale = new Vector3(0.7f, 0.7f);
				ButtonRight.localScale = new Vector2(1.63f, 1.63f);
				isRotate = 1;
			}
			else{
				transform.localScale = new Vector3(-0.7f, 0.7f);
				ButtonLeft.localScale = new Vector2(1.63f, 1.63f);
				isRotate = -1;
			}
		}
		else{
		
			if(!_currentState.Equals("jump_idle"))
				SetCharacterState("Idle");
		}
	}
	public void Jump(){
		if(_isTouchGround){
			_rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
			ButtonJump.localScale = new Vector2(1.63f, 1.63f);
		
			if(!_currentState.Equals("jump_idle"))
				_previousState = _currentState;
		
			SetCharacterState("jump_idle");
		}
	}

	private void OnCollisionEnter2D(Collision2D player) {
		if (player.gameObject.CompareTag("Ground"))
			_isTouchGround = true;
			
		ButtonJump.localScale = new Vector2(1.7f, 1.7f);
	}
}
