using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamTicketManager : ExamsData {
    [SerializeField] private Text[] _answersText;
    [SerializeField] private QuestionList[] _questions;
    [SerializeField] private Text _questionText;
    private int _randQuestion;
    private List<object> _questionList;
    private List<Vector3> _arrayPositionsButtons = new List<Vector3>();
    private int _randPositionButton;
    private int _questionsLeftCount = 7;
    private readonly int _questionsCount = 7;
    private int _rightAnswerCount;
    [SerializeField] private Text _rightAnswerCountText;
    [SerializeField] private string key; // BETA

    [Space] [Header("Scriptable objects")]
    [SerializeField] private ExamTicketData[] _arrayOfScriptableObjects;

    [SerializeField] private GameObject ExamCanvas;
    [SerializeField] private GameObject ResultCanvas;
    [SerializeField] private Text output;

    
    // [SerializeField] private ExamTicketData ExamMath;
    // [SerializeField] private ExamTicketData ExamPhysics;
    // [SerializeField] private ExamTicketData ExamFundamentalsOfComputerEngineering;
    // [SerializeField] private ExamTicketData ExamUkrainianLanguage;
    // [SerializeField] private ExamTicketData ExamProgramming;
    

    private void Start() {
        // string key = "MathTicketData"; // BETA
        // PlayerPrefs.SetString("examKey", key); // in class ModelUI
        _questionList = new List<object>(CheckExam(PlayerPrefs.GetString("examKey")));
        
        NextQuestion();
        _rightAnswerCountText.text = _rightAnswerCount + "/" + _questionsCount;
    }
    
        private QuestionList[] CheckExam(string key){
        int index = -1;
        for(int i = 0; i < _arrayOfScriptableObjects.Length; i++){
            if(_arrayOfScriptableObjects[i].name.Equals(key))
                index = i;
            }
        return _arrayOfScriptableObjects[index].Questions;
    }

    void InitButtonPositions(){
        _arrayPositionsButtons.Add(new Vector3(500f,-200f, 0f));
        _arrayPositionsButtons.Add(new Vector3(0f,-200f, 0f));
        _arrayPositionsButtons.Add(new Vector3(-500f,-200f, 0f));
    }

    private void NextQuestion(){
        InitButtonPositions();
        
        _randQuestion = Random.Range(0, _questionList.Count);
        QuestionList currentQuestion = _questionList[_randQuestion] as QuestionList;
        _questionText.text = currentQuestion.Question;
        
        for(int i = 0; i < currentQuestion.answers.Length; i++){
        _answersText[i].text = currentQuestion.answers[i];
         _randPositionButton = Random.Range(0, _arrayPositionsButtons.Count);
         _answersText[i].transform.parent.gameObject.transform.localPosition = _arrayPositionsButtons[_randPositionButton];
         _arrayPositionsButtons.RemoveAt(_randPositionButton);
        }

        _questionsLeftCount--;
    }

    private void TrueAnswer(){
            if(_questionsLeftCount > 0){
            _rightAnswerCount++;
            _rightAnswerCountText.text = _rightAnswerCount + "/" + _questionsCount;
            _questionList.RemoveAt(_randQuestion);
            NextQuestion();
                }
                else if(_questionsLeftCount == 0){
                    _questionsLeftCount--;
                    _rightAnswerCount++;
                    _rightAnswerCountText.text = _rightAnswerCount + "/" + _questionsCount;
                    CheckState();
                    Debug.Log("State: " + ExamTicketData.State);
                }
    }

    private void FalseAnswer(){

        if(_questionsLeftCount > 0){
            _questionList.RemoveAt(_randQuestion);
            NextQuestion();
            }
            else if(_questionsLeftCount == 0){
                _questionsLeftCount--;
                CheckState();
                Debug.Log("State: " + ExamTicketData.State);
            }
    }

    private void CheckState(){
        if(_rightAnswerCount >= _questionsCount - 2)
            ExamTicketData.State = "Passed";
            else
                ExamTicketData.State = "Failed";

                ShowResult();
    }

    private void ShowResult(){

        ExamCanvas.SetActive(false);
        ResultCanvas.SetActive(true);
        output.text = "Your result: " + ExamTicketData.State;
        Debug.Log("Result: " + _rightAnswerCount + "/" + 7);
    }
}
