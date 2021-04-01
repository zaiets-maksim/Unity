using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemies : MonoBehaviour {

	public GameObject[] Enemies = new GameObject[6];
	
	List<GameObject> _nonActiveInHierarchy = new List<GameObject>();
	List<GameObject> _activeInHierarchy = new List<GameObject>();
	public GameObject[] EnemySnowBalls = new GameObject[5];
	
	private static int _randomEnemy;
	public static string SelectedEnemy;
	private GameObject _enemySnowBall;
	private Rigidbody2D _rb;
	private static int _shotsPeriodicity;
	private void Start () {
		StartCoroutine("Check");
		StartCoroutine("Throw");
	}

	public int GetShotsPeriodicity{
		get {return _shotsPeriodicity;}
		set{_shotsPeriodicity = value;}
	}
	
	private IEnumerator Check(){
		
		for(int i = 0; i < Enemies.Length; i++) 	//Выполняем поиск всех врагов, которые сейчас не активны на сцене и заносим их в список.
			if(!Enemies[i].gameObject.activeInHierarchy)
				_nonActiveInHierarchy.Add(Enemies[i]);

		if(_nonActiveInHierarchy.Count > 3){   								//Выбираем рандомно обьект из неактивных и включаем его,
			_randomEnemy = Random.Range(0, _nonActiveInHierarchy.Count);	// когда на сцене противников становиться меньше чем 3
			_nonActiveInHierarchy[_randomEnemy].SetActive(true);
			SelectedEnemy = _nonActiveInHierarchy[_randomEnemy].name;	// и на этом обьекте в скрипте MoveEnemy(с проверкой) включаем стартовую корутину(MoveToStart)
		}	
		_nonActiveInHierarchy.Clear();
		yield return new WaitForSeconds(1);
		StartCoroutine("Check");	
	}

	private IEnumerator Throw(){
	for(int i = 0; i < EnemySnowBalls.Length; i++)
		if(!EnemySnowBalls[i].gameObject.activeInHierarchy){	//Выбираем первый неактивный снежок из массива, и выходим из цикла.
			_enemySnowBall = EnemySnowBalls[i].gameObject;		//(нужно для того, что бы снежки противников не исчезали в случае короткой периодичности их выстрелов)
			break;
		}
		_rb = _enemySnowBall.GetComponent<Rigidbody2D>();

		for(int i = 0; i < Enemies.Length; i++)		//Выполняем поиск всех врагов, которые сейчас активны на сцене и заносим их в список.
		if(Enemies[i].gameObject.activeInHierarchy)
			_activeInHierarchy.Add(Enemies[i]);
		
			_randomEnemy = Random.Range(0, _activeInHierarchy.Count); //Выбираем рандомно врага, который будет совершать бросок.

		if(_activeInHierarchy[_randomEnemy].transform.localScale == new Vector3(0.7f, 0.7f)){ //Если выбранный враг повернут в другую сторону от базы главного персонажа, 
			_activeInHierarchy[_randomEnemy].transform.localScale = new Vector3(-0.7f, 0.7f); // то разворачиваем его на 0.2 сек в сторону базы гп.
			_enemySnowBall.transform.position = new Vector2(_activeInHierarchy[_randomEnemy].transform.position.x, _activeInHierarchy[_randomEnemy].transform.position.y + 0.7f);
			_enemySnowBall.SetActive(true);
			_rb.velocity = new Vector2(-9, 0);
			yield return new WaitForSeconds(0.2f);
			_activeInHierarchy[_randomEnemy].transform.localScale = _activeInHierarchy[_randomEnemy].GetComponent<MoveEnemy>().CurrentDirection; 
			//Поворачиваем врага в сторону его текущего движения(нужно для того, что бы не случился баг с лунной походкой)
		}else{
			_enemySnowBall.transform.position = new Vector2(_activeInHierarchy[_randomEnemy].transform.position.x, _activeInHierarchy[_randomEnemy].transform.position.y + 0.7f);
			_enemySnowBall.SetActive(true);
			_rb.velocity = new Vector2(-9 , 0);
		}
		
		yield return new WaitForSeconds(_shotsPeriodicity);
		_activeInHierarchy.Clear();
		StartCoroutine("Throw");
	}
}
