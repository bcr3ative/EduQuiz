using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HelpSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goBack() {
		SceneManager.LoadScene("game_menu");
	}
}
