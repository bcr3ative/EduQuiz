using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class QuestionSetManager {

	private const string DATABASE_NAME = "pitanja.txt";

	private List<Question> questionList;
	private List<Answer> answerList;

	public QuestionSetManager() {
	}

	public void exportQuestions(QuestionSet questions) {
		if (File.Exists(DATABASE_NAME)) {
			File.Delete(DATABASE_NAME);
		}
		StreamWriter file = new StreamWriter(DATABASE_NAME);

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

	public QuestionSet importQuestions() {
		StreamReader file = new StreamReader(DATABASE_NAME);
		QuestionSet importedQuestionSet = new QuestionSet();
		string line;

		while((line = file.ReadLine()) != null) {
			string[] split = line.Split('|');
			Question question = new Question(split[1], (Question.QuestionType) System.Enum.Parse(typeof(Question.QuestionType), split[0], false));

			for (int i = 2; i < split.Length; i += 2) {
				question.addAnswer(split[i], System.Convert.ToBoolean(split[i+1]));
			}

			importedQuestionSet.addQuestion(question);
		}

		file.Close();

		return importedQuestionSet;
	}
}
