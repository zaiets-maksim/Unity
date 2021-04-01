using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ExamTicketData", menuName = "ExamTicketData", order = 0)]
public class ExamTicketData : ScriptableObject {
	[SerializeField] private QuestionList[] _questions;
	public QuestionList[] Questions { get { return _questions; } set { _questions = value; }}
    private static string _state;
    public static string State { get { return _state; } set { _state = value; }}
}	

    [System.Serializable]
    public class QuestionList {
		[SerializeField] private string _question;
        public string Question { get { return _question; } set { _question = value; }}
		private static readonly int _answerCount = 3;
		public string[] answers = new string[_answerCount];
	}


