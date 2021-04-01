using System;
using Structs;
using System.IO;
using UnityEngine;


public class ReadData : MonoBehaviour {
	private MoveEnemy MoveEnemyObj = new MoveEnemy();
	private MainPlayer MainPlayerObj = new MainPlayer();
	ToLoseOrWin ToLoseOrWinObj = new ToLoseOrWin();
	SnowballThrower SnowballThrowerObj = new SnowballThrower();
	ManagerEnemies ManagerEnemiesObj = new ManagerEnemies();

	[SerializeField] private int _enemiesMovementSpeed;
	[SerializeField] private int _movementSpeedHippo;
	[SerializeField] private int _theNumberOfHitPointsToWin;
	[SerializeField] private int _snowballReloadSpeedHippo;
	[SerializeField] private int _periodicityOfEnemyShots;
	[SerializeField] private int _pointsForHittingTheWeakEnemy;
	[SerializeField] private int _pointsForHittingTheMiddleEnemy;
	[SerializeField] private int _pointsForHittingTheStrongEnemy;
	  [SerializeField] private string savePath;
	  [SerializeField] private string saveFileName = "data.json";

	  private void Awake() {
#if UNITY_ANDROID && !UNITY_EDITOR
    savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
    savePath = Path.Combine(Application.dataPath, saveFileName);
#endif
	LoadFromFile();

	MoveEnemyObj.GetSpeed = _enemiesMovementSpeed;	//Устанавливаем доспуп к переменным из классов и присваиваем сериализационные данные
	
	MainPlayerObj.GetSpeed = _movementSpeedHippo;

	ToLoseOrWinObj.GetPointsRequiredToWin = _theNumberOfHitPointsToWin;

	SnowballThrowerObj.GetReloadTime = _snowballReloadSpeedHippo;

	ManagerEnemiesObj.GetShotsPeriodicity = _periodicityOfEnemyShots;

	SnowballThrowerObj.GetPointsForWeakEnemy = _pointsForHittingTheWeakEnemy;

	SnowballThrowerObj.GetPointsForMiddleEnemy = _pointsForHittingTheMiddleEnemy;

	SnowballThrowerObj.GetPointsForStrongEnemy = _pointsForHittingTheStrongEnemy;

	  }

     public void LoadFromFile(){
        if(!File.Exists(savePath)){
            Debug.Log("File not found!");
            return;
        }
        string json = File.ReadAllText(savePath);

        try{
        StructData DataFromJson = JsonUtility.FromJson<StructData>(json);
            _enemiesMovementSpeed = DataFromJson._enemiesMovementSpeed2;
            _movementSpeedHippo = DataFromJson._movementSpeedHippo2;
            _theNumberOfHitPointsToWin = DataFromJson._theNumberOfHitPointsToWin2;
            _snowballReloadSpeedHippo = DataFromJson._snowballReloadSpeedHippo2;
            _periodicityOfEnemyShots = DataFromJson._periodicityOfEnemyShots2;
            _pointsForHittingTheWeakEnemy = DataFromJson._pointsForHittingTheWeakEnemy2;
            _pointsForHittingTheMiddleEnemy = DataFromJson._pointsForHittingTheMiddleEnemy2;
            _pointsForHittingTheStrongEnemy = DataFromJson._pointsForHittingTheStrongEnemy2;
        }
        catch(Exception e){
            Debug.Log("Exception: " + e);
        }
    }
}
