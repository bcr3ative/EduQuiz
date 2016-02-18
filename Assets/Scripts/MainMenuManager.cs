using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame() {
		SceneManager.LoadScene("new_game");
	}

	public void addQuestions() {
		SceneManager.LoadScene("add_questions");
	}

	public void help() {
		SceneManager.LoadScene ("help");
	}

	public void settings() {
		SceneManager.LoadScene ("settings");
	}
}
