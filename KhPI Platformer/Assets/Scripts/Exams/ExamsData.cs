using UnityEngine;
using UnityEngine.UI;


public class ExamsData : MonoBehaviour {
    private static readonly int _examsCount = 5;
	private string[] _exams = new string[_examsCount];
    private Text ExamTableText;

    

    private void Start() {
        ExamTableText = this.GetComponent<Text>();
        LoadData();
    }

    private void LoadData(){
        //_exams[0] = ExamTicketData.State;              x x x
        //instead of 0 -> PlayerPrefs.GetString("Math"); !!!!!!!!!!!!1

        //Debug.Log(PlayerPrefs.GetString("Math"));
        
        _exams[0] = "Math: " + 0 + "\n";
        _exams[1] = "Physics: " + 0 + "\n";
        _exams[2] = "Сomputer engineering: " + 0 + "\n";
        _exams[3] = "Ukrainian language: " + 0 + "\n";
        _exams[4] ="Programming: " + 0 + "\n";

        ExamTableText.text = "Exams: \n" + _exams[0] + _exams[1] + _exams[2] + _exams[3] + _exams[4];

        // --/--
    }
}
