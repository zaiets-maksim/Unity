using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth;
using UnityEngine;
using UnityEngine.EventSystems;

public class SquareControl : MonoBehaviour, IDragHandler, IBeginDragHandler {
 [SerializeField] private FollowTouch _followTouch;
 string _currentLybyrinth;
 private char [,] Grid;
 private Touch touch;
 [SerializeField] private GameObject _square;
 private int _indexX;
 private int _indexY;
 private Vector2 _currentPositionSquare;
 char _emptySymbol = '0';
 private Vector3 _startPosition;
 private Vector3 _finishPosition;
 [SerializeField] private GameObject WinnerCanvas;
 private Vector2 _endPosition;
 Vector2 _currentPosition;
 [SerializeField] ParticleSystem _particleSystem;

	void Start () {
		// Debug.Log(_followTouch.IndexLabyrinthArray);
		// Debug.Log(_followTouch.ArrayOfScriptableObjects.Length);
		// Debug.Log(_followTouch.ArrayOfScriptableObjects[_followTouch.IndexLabyrinthArray].Labyrinth);
		InitGrid();
		_startPosition = _followTouch.ArrayOfScriptableObjects[_followTouch.IndexLabyrinthArray].StartPositionSquare;
		_finishPosition = _followTouch.ArrayOfScriptableObjects[_followTouch.IndexLabyrinthArray].EndPositionSquare;
		 _square.gameObject.transform.position = _startPosition;
		 _particleSystem.Stop();
	}

    private void InitGrid(){
		Grid = new char[_followTouch.Height,_followTouch.Weight];
		int _currentLibyrinthSymbol = 0;
		_currentLybyrinth = _followTouch.ArrayOfScriptableObjects[_followTouch.IndexLabyrinthArray].Labyrinth;

		for(int i = 0; i < _followTouch.Height; i++){
			for(int j = 0; j < _followTouch.Weight; j++){
				Grid[i,j] = _currentLybyrinth[_currentLibyrinthSymbol];
				_currentLibyrinthSymbol++;
			}
		}
		// Debug.Log("Invalid entered array range !!!!!!!!!!!!!!!"); i fix it :)
    }

	private void OnEndedPosition(){
		if(_square.transform.position.Equals(_finishPosition))
		WinnerCanvas.SetActive(true);
	}

	private void InitPositions(){
		_indexX = (int)_square.gameObject.transform.position.x;
		_indexY = (int)_square.gameObject.transform.position.y;
		_currentPosition = _square.transform.position;
	}

	private IEnumerator MoveSquare(Vector2 targetPosition){
		_currentPosition = _square.transform.position;
		while(!_currentPosition.Equals(targetPosition)){
			 InitPositions();
			_square.transform.position = Vector2.MoveTowards(_currentPosition, targetPosition, 0.8f);
			// yield return new WaitForSeconds(0.01f);
			yield return null;
		}
		OnEndedPosition();
		StartCoroutine(ShowEffect());
	}
	private Vector2 UpMoving(){
		InitPositions();
		
		for(; _indexY < 1; _indexY++){
			
			if(Grid[System.Math.Abs(_indexY), _indexX].Equals(_emptySymbol)){
			_endPosition = new Vector2(_square.gameObject.transform.position.x, _indexY);
			}

			else{
				_endPosition = new Vector2(_square.gameObject.transform.position.x, _indexY - 1);
				// Debug.Log(_endPosition);
				// Debug.Log(_indexY-1);
				return _endPosition;
			}
		}
		return _endPosition;
	}

	private Vector2 DownMoving(){
		InitPositions();

		for(; _indexY > -10; _indexY--){
			
			if(Grid[System.Math.Abs(_indexY), _indexX].Equals(_emptySymbol)){
			_endPosition = new Vector2(_square.gameObject.transform.position.x, _indexY);
			}

			else{
				_endPosition = new Vector2(_square.gameObject.transform.position.x, _indexY + 1);
				// Debug.Log(_endPosition);
				// Debug.Log(_indexY+1);
				return _endPosition;
			}
		}
		return _endPosition;
	}

	private Vector2 LeftMoving(){
		InitPositions();
		
		for(; _indexX > -1; _indexX--){
			
			if(Grid[System.Math.Abs(_indexY), _indexX].Equals(_emptySymbol)){
			_endPosition = new Vector2(_indexX, _square.gameObject.transform.position.y);
			}

			else{
				_endPosition = new Vector2( _indexX + 1, _square.gameObject.transform.position.y);
				// Debug.Log(_endPosition);
				// Debug.Log(_indexY-1);
				return _endPosition;
			}
		}
		return _endPosition;
	}

	private Vector2 RightMoving(){
		InitPositions();
		
		for(; _indexX < 14; _indexX++){
			
			if(Grid[System.Math.Abs(_indexY), _indexX].Equals(_emptySymbol)){
			_endPosition = new Vector2(_indexX, _square.gameObject.transform.position.y);
			}

			else{
				_endPosition = new Vector2( _indexX - 1, _square.gameObject.transform.position.y);
				// Debug.Log(_endPosition);
				// Debug.Log(_indexY-1);
				return _endPosition;
			}
		}
		return _endPosition;
	}

	private IEnumerator ShowEffect(){
		if(_particleSystem.isPlaying)
		_particleSystem.Clear();
		
		_particleSystem.Play();

		// yield return new WaitForSeconds(0.6f);
		yield return null;
	}


	public void OnBeginDrag(PointerEventData eventData){

    	if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)){

        	if (eventData.delta.x > 0) 
			StartCoroutine(MoveSquare(RightMoving()));
            else StartCoroutine(MoveSquare(LeftMoving()));
     	}

    	else{
            if (eventData.delta.y > 0) 
			StartCoroutine(MoveSquare(UpMoving()));
            else StartCoroutine(MoveSquare(DownMoving()));
     	}

	}
	public void OnDrag(PointerEventData eventData){}
}

