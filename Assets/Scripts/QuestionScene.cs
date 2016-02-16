using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionScene : MonoBehaviour {

	private InputField inputQuestion;
	private InputField inputField1;
	private InputField inputField2;
	private InputField inputField3;
	private InputField inputField4;

	private Toggle toggle1;
	private Toggle toggle2;
	private Toggle toggle3;
	private Toggle toggle4;

	private QuestionSetManager questionSetManager;
	private QuestionSet questionSet;

	private Question.QuestionType mode;

	// Use this for initialization
	void Start () {
		inputQuestion = GameObject.Find("question_input").GetComponent<InputField>();

		inputField1 = GameObject.Find("answer1_input").GetComponent<InputField>();
		inputField2 = GameObject.Find("answer2_input").GetComponent<InputField>();
		inputField3 = GameObject.Find("answer3_input").GetComponent<InputField>();
		inputField4 = GameObject.Find("answer4_input").GetComponent<InputField>();

		toggle1 = GameObject.Find("answer1_toggle").GetComponent<Toggle>();
		toggle2 = GameObject.Find("answer2_toggle").GetComponent<Toggle>();
		toggle3 = GameObject.Find("answer3_toggle").GetComponent<Toggle>();
		toggle4 = GameObject.Find("answer4_toggle").GetComponent<Toggle>();

		questionSetManager = new QuestionSetManager();
		questionSet = new QuestionSet();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onModeChanged(int m) {
		switch(m) {
			default:
				inputField1.interactable = toggle1.interactable = false;
				inputField2.interactable = toggle2.interactable = false;
				inputField3.interactable = toggle3.interactable = false;
				inputField4.interactable = toggle4.interactable = false;
				break;
			case 1:
				mode = Question.QuestionType.MODE2_V;
				inputField1.interactable = toggle1.interactable = true;
				inputField2.interactable = toggle2.interactable = true;
				inputField3.interactable = toggle3.interactable = false;
				inputField4.interactable = toggle4.interactable = false;
				break;
			case 2:
				mode = Question.QuestionType.MODE2_H;
				inputField1.interactable = toggle1.interactable = true;
				inputField2.interactable = toggle2.interactable = false;
				inputField3.interactable = toggle3.interactable = true;
				inputField4.interactable = toggle4.interactable = false;
				break;
			case 3:
				mode = Question.QuestionType.MODE4;
				inputField1.interactable = toggle1.interactable = true;
				inputField2.interactable = toggle2.interactable = true;
				inputField3.interactable = toggle3.interactable = true;
				inputField4.interactable = toggle4.interactable = true;
				break;
		}
	}

	public void onQuestionSave() {
		Question question = new Question(inputQuestion.text, mode);

		switch(mode) {
			case Question.QuestionType.MODE2_V:
				question.addAnswer(inputField1.text, toggle1.isOn);
				question.addAnswer(inputField2.text, toggle2.isOn);
				break;
			case Question.QuestionType.MODE2_H:
				question.addAnswer(inputField1.text, toggle1.isOn);
				question.addAnswer(inputField3.text, toggle3.isOn);
				break;
			case Question.QuestionType.MODE4:
				question.addAnswer(inputField1.text, toggle1.isOn);
				question.addAnswer(inputField2.text, toggle2.isOn);
				question.addAnswer(inputField3.text, toggle3.isOn);
				question.addAnswer(inputField4.text, toggle4.isOn);
				break;
		}

		questionSet.addQuestion(question);
		inputQuestion.text = inputField1.text = inputField2.text = inputField3.text = inputField4.text = "";
		toggle1.isOn = toggle2.isOn = toggle3.isOn = toggle4.isOn = false;
	}

	public void onQuestionsEntryFinished() {
		questionSetManager.exportQuestions(questionSet);
	}
}
