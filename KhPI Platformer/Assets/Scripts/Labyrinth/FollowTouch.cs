
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Labyrinth{
public class FollowTouch : MonoBehaviour {
 [SerializeField] private Camera cam;
 [SerializeField] private GameObject _gridObject;
 private static int _height;
  public int Height { get {return  _height; }}
 private static int _weight;
 public int Weight { get {return  _weight; }}

 
 [SerializeField] private GameObject[,] _blocksArray;


 [Space] [Header("Scriptable objects")]
 [SerializeField] private LabyrinthData[] _arrayOfScriptableObjects;
 public LabyrinthData[] ArrayOfScriptableObjects { get {return  _arrayOfScriptableObjects; }}
 [Space] [Space]

 [SerializeField] private GameObject _block;

 private readonly float _startingPositionX = 0;
 private readonly float _startingPositionY = 0;

 [SerializeField] private GameObject _nullObject;
 private string _currentLybyrinth;


 [SerializeField] private GameObject _blocks;//////////////
 [SerializeField] private GameObject _Eobjects;/////////////
   //???????????

 private int _indexLabyrinthArray;
 public int IndexLabyrinthArray { get {return  _indexLabyrinthArray; }}


        private void Start() {
	
		_weight = (int)_gridObject.transform.localScale.x;
		_height = (int)_gridObject.transform.localScale.y;
		
		_blocksArray = new GameObject[_height,_weight];

		
		RandomizeMazeGrid();
		DrawingMaze(_startingPositionX, _startingPositionY);
		
		
		
		// Debug.Log(_blocksArray[0,12].transform.position);
	
 	}

    private void RandomizeMazeGrid(){
		_indexLabyrinthArray = Random.Range(0, _arrayOfScriptableObjects.Length);
		_currentLybyrinth = _arrayOfScriptableObjects[_indexLabyrinthArray].Labyrinth;
    }

    private void DrawingMaze(float StartingPositionX, float StartingPositionY){
		
		int _indexCurrentLabyrinth = 0;
		char _currentLibyrinthSymbol;
		char _emptySymbol = '0';
		StartingPositionY = _startingPositionY;
		for(int i = 0; i < _height; i++){
			
			StartingPositionX = _startingPositionX;
			for (int j = 0; j < _weight; j++){
				_currentLibyrinthSymbol = _currentLybyrinth[_indexCurrentLabyrinth];
				_indexCurrentLabyrinth++;

				if(_currentLibyrinthSymbol.Equals(_emptySymbol)){
					_blocksArray[i,j] = _nullObject.gameObject;
					_blocksArray[i,j].gameObject.transform.localPosition = new Vector2(StartingPositionX, StartingPositionY);
					_nullObject.gameObject.name = (i + " " + j);////////////////////////////////////////////////////////////
					var child = Instantiate(_blocksArray[i,j], new Vector2(_blocksArray[i,j].gameObject.transform.position.x, _blocksArray[i,j].gameObject.transform.position.y), Quaternion.identity);
					child.transform.SetParent(_Eobjects.transform);
					
				}
				
				else{
					_blocksArray[i,j] = _block.gameObject;
					_blocksArray[i,j].gameObject.transform.localPosition = new Vector2(StartingPositionX, StartingPositionY);
					var child = Instantiate(_blocksArray[i,j], new Vector2(_blocksArray[i,j].gameObject.transform.position.x, _blocksArray[i,j].gameObject.transform.position.y), Quaternion.identity);
					child.transform.SetParent(_blocks.transform);
				}

				StartingPositionX++;
			}
			StartingPositionY--;
		}
	}
	
}
}
