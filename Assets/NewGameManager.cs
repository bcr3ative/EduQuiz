using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewGameManager : MonoBehaviour {

	private Button answ;
	private Button answer2;
	private Button answer3;
	private Button answer4;
	private Text questionText;

	QuestionSetManager questionSetManager;
	// Use this for initialization
	void Start () {
		questionSetManager = new QuestionSetManager ();
		questionText = GameObject.Find ("question_text").GetComponent<Text> ();
		/*answer1 = GameObject.Find ("answer1_button").GetComponent<Button> ();
		answer2 = GameObject.Find ("answer2_button").GetComponent<Button> ();
		answer3 = GameObject.Find ("answer3_button").GetComponent<Button> ();
		answer4 = GameObject.Find ("answer4_button").GetComponent<Button> ();*/
		string mode = "";
		string question_text = "";
		string answer1_text = "";

		List<Question> questionList = questionSetManager.importQuestions ().getQuestionList ();
		foreach (Question question in questionList) {
			List<Answer> answerList = question.getAnswers ();
			mode = question.getQuestionMode ().ToString();
			question_text = question.getQuestionText ();
			int i = 1;
			foreach (Answer answer in answerList) {
				string name = "answer" + i.ToString () + "_button"; 
				answ = GameObject.Find (name).GetComponent<Button> ();
				answ.GetComponentInChildren<Text>().text = answer.getText ();
				Debug.Log (name);
				i++;
			}
			Debug.Log (question_text);
			break;
		}

		questionText.text = question_text;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
