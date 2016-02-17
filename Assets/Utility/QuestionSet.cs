using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionSet {

	private List<Question> questionList = new List<Question>();

	public QuestionSet() {}

	public void addQuestion(Question question) {
		questionList.Add(question);
	}

	public List<Question> getQuestionList () {
		return questionList;
	}
}
