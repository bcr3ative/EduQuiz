using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class QuestionSetManager {

	private const string DATABASE_NAME = "pitanja.txt";
	private StreamWriter file;

	private List<Question> questionList;
	private List<Answer> answerList;

	public QuestionSetManager() {
	}

	public void exportQuestions(QuestionSet questions) {
		if (File.Exists(DATABASE_NAME)) {
			File.Delete(DATABASE_NAME);
		}
		file = new StreamWriter(DATABASE_NAME);

		questionList = questions.getQuestionList();
		foreach (Question question in questionList) {
			string line = question.getQuestionMode().ToString() + "|" + question.getQuestionText();
			answerList = question.getAnswers();
			foreach (Answer answer in answerList) {
				line += "|" + answer.getText() + "|" + answer.isCorrect().ToString();
			}
			file.WriteLine(line);
		}

		file.Close();
	}
}
