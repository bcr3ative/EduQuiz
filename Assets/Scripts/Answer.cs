using UnityEngine;
using System.Collections;

public class Answer {

	private string text;
	private bool correct;

	public Answer(string text, bool correct) {
		this.text = text;
		this.correct = correct;
	}

	public string getText() {
		return text;
	}

	public bool isCorrect() {
		return correct;
	}
}
