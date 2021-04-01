using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowballThrower : MonoBehaviour {
	public GameObject SnowBall;
	public GameObject Player;
	private Rigidbody2D _rb;
	private bool _isSnowBallReady;
	public GameObject CircleProgressBarReload;
	private Animation _anim;
	private Animation _anim1;
	private CircleCollider2D _snowBallCollider;
	public Image ProgressBarForceThrow;
	private static int _reloadTime;
	public static int Points;
	public GameObject NotificationBox;
	private Animation _anim2;
	public Text PointsText;
	private static int _pointsForWeakEnemy;
	private static int _pointsForMiddleEnemy;
	private static int _pointsForStrongEnemy;
	void Start () {
		Points = 0;
		_rb = GetComponent<Rigidbody2D>();
		_anim = CircleProgressBarReload.GetComponent<Animation>();
		_anim1 = ProgressBarForceThrow.GetComponent<Animation>();
		_anim2 = NotificationBox.GetComponent<Animation>();
		_snowBallCollider = SnowBall.GetComponent<CircleCollider2D>();
		SnowBall.SetActive(false);
		_isSnowBallReady = true;
		_anim1.Play("ProgressBarForceThrow");
	}

	public int GetReloadTime{
		get {return _reloadTime;}
		set{_reloadTime = value;}
	}

	public int GetPointsForWeakEnemy{
		get {return _pointsForWeakEnemy;}
		set{_pointsForWeakEnemy = value;}
	}

	public int GetPointsForMiddleEnemy{
		get {return _pointsForMiddleEnemy;}
		set{_pointsForMiddleEnemy = value;}
	}

	public int GetPointsForStrongEnemy{
		get {return _pointsForStrongEnemy;}
		set{_pointsForStrongEnemy = value;}
	}
	
	public void Throw(){
		if(_isSnowBallReady){
			_anim1.Stop("ProgressBarForceThrow");
			SnowBall.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 1.2f);
			SnowBall.SetActive(true);
			_rb.velocity = new Vector2(10 * MainPlayer.isRotate, ProgressBarForceThrow.fillAmount * 10);
			_isSnowBallReady = false;

			_anim["CircleProgressBarReload"].speed = 1f / _reloadTime;
			_anim.Play("CircleProgressBarReload");
		
			Invoke("Reload", _reloadTime);
		}
	}
	void Reload(){
		SnowBall.SetActive(false);
		_isSnowBallReady = true;
		_anim1.Play("ProgressBarForceThrow");
	}

	void Hit(){
		SnowBall.SetActive(false);
		PointsText.text = "Points: " + Points.ToString();
		_anim2.Stop();
		_anim2.Play("ShowNotificationBox");
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("EnemyWeak")){
			Points += _pointsForWeakEnemy;
			Hit();
		}
		if(other.gameObject.CompareTag("EnemyMiddle")){
			Points += _pointsForMiddleEnemy;
			Hit();
		}

		if(other.gameObject.CompareTag("EnemyStrong")){
			Points += _pointsForStrongEnemy;
			Hit();
		}		
		if(other.gameObject.CompareTag("Ground")){
		SnowBall.SetActive(false);}
	}
}
