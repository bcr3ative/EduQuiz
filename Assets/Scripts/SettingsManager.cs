using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class SettingsManager : MonoBehaviour {

	private Toggle sound;
	private InputField font_size;
	private InputField time;

	private SettingsManager settings;

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
		PreferencesManager.save(sound.isOn.ToString(), font_size.text, time.text);
		SceneManager.LoadScene("game_menu");
	}

	public string[] readSettings() {
		return PreferencesManager.read();
	}

	public void goBack() {
		SceneManager.LoadScene("game_menu");
	}
}
