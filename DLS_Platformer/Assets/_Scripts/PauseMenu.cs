using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	
	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenu;

	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenu.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}
		
	public void Resume(){
		isPaused = false;
	}

	public void Restart(){
		Debug.Log ("work pls");
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Quit(){
		Application.LoadLevel (mainMenu);
	}
}
