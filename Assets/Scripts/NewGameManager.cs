using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewGameManager : MonoBehaviour {

	private Button answer1;
	private Button answer2;
	private Button answer3;
	private Button answer4;

	private Text questionText;

	private QuestionSetManager questionSetManager;
	private QuestionSet questionSet;

	private int questionIndex;

	// Use this for initialization
	void Start () {

		answer1 = GameObject.Find("answer1_button").GetComponent<Button>();
		answer2 = GameObject.Find("answer2_button").GetComponent<Button>();
		answer3 = GameObject.Find("answer3_button").GetComponent<Button>();
		answer4 = GameObject.Find("answer4_button").GetComponent<Button>();

		questionText = GameObject.Find("question_text").GetComponent<Text>();

		questionSetManager = new QuestionSetManager ();
		questionSet = questionSetManager.importQuestions();

		questionIndex = -1;

		loadNewQuestion();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool hasNextQuestion() {
		if (questionIndex + 1 <= questionSet.getQuestionList().Count - 1) {
			return true;
		}
		return false;
	}

	private Question getNextQuestion() {
		if (hasNextQuestion) {
			questionIndex++;
			return questionSet.getQuestionList()[questionIndex];
		}

		return null;
	}

	public void loadNewQuestion() {

		Question question = getNextQuestion();
		if (question == null) return;

		List<Answer> answers = question.getAnswers();

		Question.QuestionType mode = question.getQuestionMode();
		questionText.text = question.getQuestionText();

		// button resizing and positioning based on the question mode
		if (mode == Question.QuestionType.MODE2_V) {
			// set size of first button
			answer1.image.rectTransform.sizeDelta = new Vector2 (478, 350);
			//set position of first button
			Vector3 temp = answer1.transform.position;
			temp.x = 250;
			temp.y = 220;
			temp.z = 0;
			answer1.transform.position = temp;

			// set size of second button
			answer2.image.rectTransform.sizeDelta = new Vector2 (478, 350);
			// set position of second button
			temp = answer2.transform.position;
			temp.x = 820;
			temp.y = 220;
			temp.z = 0;
			answer2.transform.position = temp;

			// hide third and fourth button 
			answer3.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);

			// set answers text
			answer1.GetComponentInChildren<Text>().text = answers[0].getText();
			answer2.GetComponentInChildren<Text>().text = answers[1].getText();
		} else if (mode == Question.QuestionType.MODE2_H) {
			// set size of first button
			answer1.image.rectTransform.sizeDelta = new Vector2 (956, 175);
			//set position of first button
			Vector3 temp = answer1.transform.position;
			temp.x = 500;
			temp.y = 350;
			temp.z = 0;
			answer1.transform.position = temp;

			// set size of third button
			answer3.image.rectTransform.sizeDelta = new Vector2 (956, 175);
			// set position of second button
			temp = answer2.transform.position;
			temp.x = 500;
			temp.y = 100;
			temp.z = 0;
			answer3.transform.position = temp;

			// hide second and fourth button 
			answer2.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);

			// set answers text
			answer1.GetComponentInChildren<Text>().text = answers[0].getText();
			answer3.GetComponentInChildren<Text>().text = answers[1].getText();
		} else if (mode == Question.QuestionType.MODE4) {

			// set answers text
			answer1.GetComponentInChildren<Text>().text = answers[0].getText();
			answer2.GetComponentInChildren<Text>().text = answers[1].getText();
			answer3.GetComponentInChildren<Text>().text = answers[2].getText();
			answer4.GetComponentInChildren<Text>().text = answers[3].getText();
		}
	}
}
