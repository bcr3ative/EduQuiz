using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class SettingsManager : MonoBehaviour {

	private Toggle sound;
	private InputField font_size;
	private InputField time;
	private const string DATABASE_NAME = "postavke.txt";
	// Use this for initialization
	void Start () {
		sound = GameObject.Find("sound_toggle").GetComponent<Toggle>();
		font_size = GameObject.Find("fontsize_input").GetComponent<InputField>();
		time = GameObject.Find("time_input").GetComponent<InputField>();
		string[] line = readSettings ();
		sound.isOn = bool.Parse (line[0]);
		font_size.text = line [1];
		time.text = line [2];
				
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void saveSettings() {
		if (File.Exists(DATABASE_NAME)) {
			File.Delete(DATABASE_NAME);
		}
		StreamWriter file = new StreamWriter(DATABASE_NAME);

		string line = sound.isOn.ToString () + "|" + font_size.text + "|" + time.text;
			
		file.WriteLine(line);
		file.Close();
		SceneManager.LoadScene("game_menu");
	}

	public string [] readSettings() {
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
}
