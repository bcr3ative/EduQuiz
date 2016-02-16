using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionSet {

	private List<Question> questionList = new List<Question>();

	public QuestionSet() {}

	public void addQuestion(string questionText, Question.QuestionType mode) {
		questionList.Add(new Question(questionText, mode));
	}
}
