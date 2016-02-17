using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame() {
		SceneManager.LoadScene("start_game");
	}

	public void addQuestions() {
		SceneManager.LoadScene("add_questions");
	}

	public void Questions() {
		//GameObject inputFieldGo = GameObject.Find("question_num_input");
		//InputField question_num_input = inputFieldGo.GetComponent<InputField>();
		SceneManager.LoadScene("questions");
	}
}
