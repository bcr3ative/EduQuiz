using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewGameManager : MonoBehaviour {

	private Button answ;
	private Button answer1;
	private Button answer2;
	private Button answer3;
	private Button answer4;
	private Text questionText;

	QuestionSetManager questionSetManager;
	// Use this for initialization
	void Start () {
		questionSetManager = new QuestionSetManager ();

		questionText = GameObject.Find ("question_text").GetComponent<Text> ();
		answer1 = GameObject.Find ("answer1_button").GetComponent<Button> ();
		answer2 = GameObject.Find ("answer2_button").GetComponent<Button> ();
		answer3 = GameObject.Find ("answer3_button").GetComponent<Button> ();
		answer4 = GameObject.Find ("answer4_button").GetComponent<Button> ();

		string mode = "";
		string question_text = "";

		List<Question> questionList = questionSetManager.importQuestions ().getQuestionList ();
		Question firstQuestion = questionList [0];
		List<Answer> answerList = firstQuestion.getAnswers ();
		mode = firstQuestion.getQuestionMode ().ToString();
		question_text = firstQuestion.getQuestionText ();

		questionText.text = question_text;

		int i = 1;
		foreach (Answer answer in answerList) {
			if (mode == "MODE2_H") {
				if (i == 1) {
					answer1.GetComponentInChildren<Text> ().text = answer.getText ();
				} else {
					answer3.GetComponentInChildren<Text> ().text = answer.getText ();
				}
			} else {
				string name = "answer" + i.ToString () + "_button"; 
				answ = GameObject.Find (name).GetComponent<Button> ();
				answ.GetComponentInChildren<Text>().text = answer.getText ();
			}
			i++;
		}

		if (mode == "MODE2_V") {
			answer3.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);
		} else if (mode == "MODE2_H") {
			answer2.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
