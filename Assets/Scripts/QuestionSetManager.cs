using UnityEngine;
using System.Collections;
using System.IO;

public class QuestionSetManager {

	private const string DATABASE_NAME = "pitanja.txt";
	private StreamWriter file;

	public QuestionSetManager() {
//		file = new StreamWriter(DATABASE_NAME);
//		file.WriteLine("hello there");
//		file.Close();
	}

	public void exportQuestion(QuestionSet questions) {
		if (File.Exists(DATABASE_NAME)) {
			File.Delete(DATABASE_NAME);
		}


	}
}
