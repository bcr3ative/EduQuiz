using UnityEngine;
using System.IO;
using System.Collections;

public class PreferencesManager {

	private const string DATABASE_NAME = "postavke.txt";

	public PreferencesManager() {

	}

	public static string[] read() {
		StreamReader file;
		string[] line;

		if (File.Exists (DATABASE_NAME)) {
			file = new StreamReader(DATABASE_NAME);
			line = file.ReadLine().Split('|');
			file.Close();
		} else {
			line = new string[3];
			line[0] = "False";
			line[1] = "20";
			line[2] = "5";
		}

		return line;
	}

	public static void save(string sound, string fontSize, string timeDelay) {
		if (File.Exists(DATABASE_NAME)) {
			File.Delete(DATABASE_NAME);
		}
		StreamWriter file = new StreamWriter(DATABASE_NAME);

		string line = sound + "|" + fontSize + "|" + timeDelay;

		file.WriteLine(line);
		file.Close();
	}
}
