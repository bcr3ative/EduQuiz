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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onModeChanged(int mode) {
		switch(mode) {
		default:
			inputField1.interactable = toggle1.interactable = false;
			inputField2.interactable = toggle2.interactable = false;
			inputField3.interactable = toggle3.interactable = false;
			inputField4.interactable = toggle4.interactable = false;
			break;
		case 1:
			inputField1.interactable = toggle1.interactable = true;
			inputField2.interactable = toggle2.interactable = true;
			inputField3.interactable = toggle3.interactable = false;
			inputField4.interactable = toggle4.interactable = false;
			break;
		case 2:
			inputField1.interactable = toggle1.interactable = true;
			inputField2.interactable = toggle2.interactable = false;
			inputField3.interactable = toggle3.interactable = true;
			inputField4.interactable = toggle4.interactable = false;
			break;
		case 3:
			inputField1.interactable = toggle1.interactable = true;
			inputField2.interactable = toggle2.interactable = true;
			inputField3.interactable = toggle3.interactable = true;
			inputField4.interactable = toggle4.interactable = true;
			break;
		}
	}

	public void onQuestionSave() {
		
	}
}
