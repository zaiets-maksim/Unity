using UnityEngine;
using System.IO;
using Structs;
using System;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour {
    
public Slider EnemiesMovementSpeed;
public Slider MovementSpeedHippo;
public Slider TheNumberOfHitPointsToWin;
public Slider SnowballReloadSpeedHippo;
public Slider PeriodicityOfEnemyShots;
public Text PointsForHittingTheWeakEnemy;
public Text PointsForHittingTheMiddleEnemy;
public Text PointsForHittingTheStrongEnemy;
    [SerializeField] private int _enemiesMovementSpeed;
	[SerializeField] private int _movementSpeedHippo;
	[SerializeField] private int _theNumberOfHitPointsToWin;
	[SerializeField] private int _snowballReloadSpeedHippo;
	[SerializeField] private int _periodicityOfEnemyShots;
	[SerializeField] private int _pointsForHittingTheWeakEnemy;
	[SerializeField] private int _pointsForHittingTheMiddleEnemy;
	[SerializeField] private int _pointsForHittingTheStrongEnemy;

    [Header("Save config")]
    [SerializeField] private string savePath;
    [SerializeField] private string saveFileName = "data.json";

    public void SaveToFile(){
        StructData gameData = new StructData{
            _enemiesMovementSpeed2 = this._enemiesMovementSpeed,
            _movementSpeedHippo2 = this._movementSpeedHippo,
            _theNumberOfHitPointsToWin2 = this._theNumberOfHitPointsToWin,
            _snowballReloadSpeedHippo2 = this._snowballReloadSpeedHippo, 
            _periodicityOfEnemyShots2 = this._periodicityOfEnemyShots,
            _pointsForHittingTheWeakEnemy2 = this._pointsForHittingTheWeakEnemy,
            _pointsForHittingTheMiddleEnemy2 = this._pointsForHittingTheMiddleEnemy,
            _pointsForHittingTheStrongEnemy2 = this._pointsForHittingTheStrongEnemy
        };
        string json = JsonUtility.ToJson(gameData, true);
        try{
        File.WriteAllText(savePath, json);
        }
        catch(Exception e){
            Debug.Log("Exception: " + e);
        }
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

            EnemiesMovementSpeed.value = DataFromJson._enemiesMovementSpeed2;   //Установка UI-компонентам(Slder и Text) параметров считанных из .json
            MovementSpeedHippo.value = DataFromJson._movementSpeedHippo2;
            TheNumberOfHitPointsToWin.value = DataFromJson._theNumberOfHitPointsToWin2;
            SnowballReloadSpeedHippo.value = DataFromJson._snowballReloadSpeedHippo2;
            PeriodicityOfEnemyShots.value = DataFromJson._periodicityOfEnemyShots2;
            PointsForHittingTheWeakEnemy.text = DataFromJson._pointsForHittingTheWeakEnemy2.ToString();
            PointsForHittingTheMiddleEnemy.text = DataFromJson._pointsForHittingTheMiddleEnemy2.ToString();
            PointsForHittingTheStrongEnemy.text = DataFromJson._pointsForHittingTheStrongEnemy2.ToString();
        }
        catch(Exception e){
            Debug.Log("Exception: " + e);
        }
    }
	private void Awake() {
#if UNITY_ANDROID && !UNITY_EDITOR
    savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
    savePath = Path.Combine(Application.dataPath, saveFileName);
#endif

    LoadFromFile();
    }

    public void ToStart(){
        ReadCurrentData();
        SaveToFile();
    }
    public void ReadCurrentData () {        //Установка сериализационным данным(.json) знайчений считанных с UI-компонентов
	_enemiesMovementSpeed = (int)EnemiesMovementSpeed.value;
	_movementSpeedHippo = (int)MovementSpeedHippo.value;
	_theNumberOfHitPointsToWin = (int)TheNumberOfHitPointsToWin.value;
	_snowballReloadSpeedHippo = (int)SnowballReloadSpeedHippo.value;
	_periodicityOfEnemyShots = (int)PeriodicityOfEnemyShots.value;
	_pointsForHittingTheWeakEnemy = Convert.ToInt32(PointsForHittingTheWeakEnemy.text);
	_pointsForHittingTheMiddleEnemy = Convert.ToInt32(PointsForHittingTheMiddleEnemy.text);
	_pointsForHittingTheStrongEnemy = Convert.ToInt32(PointsForHittingTheStrongEnemy.text);
	}
}
   

