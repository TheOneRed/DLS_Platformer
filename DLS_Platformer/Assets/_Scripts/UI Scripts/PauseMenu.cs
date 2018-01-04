using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	//PUBLIC VARIABLES
	
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenu;
	public GameObject LivesUI;
	public GameObject LivesLvStartUI;
	public GameObject player;
	public GameObject enemy;
	public GameObject panCamera;
	public bool isScene = true;

	void Start () {
		 
		if (isScene == true)
		{
			LivesUI.SetActive (false);
			LivesLvStartUI.SetActive (true);
			player.SetActive (false);
			enemy.SetActive (false);
			Invoke ("DeactivateLivesLvStartUI", 5.0f);
		}
	}

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

		if (LivesLvStartUI.activeInHierarchy == true) 
		//if(isScene == true)
		{
			//Debug.Log ("TimeScale should be 0");
			//Time.timeScale = 0f;

		} 
		else if(LivesLvStartUI.activeInHierarchy == false)
		//if(isScene == false)
		{
			//Time.timeScale = 1f;
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

	void DeactivateLivesLvStartUI()
	{
		LivesLvStartUI.SetActive (false);
		panCamera.SetActive (true);
		isScene = false;
	}
		

	IEnumerator Example()
	{
		yield return new WaitForSeconds (5.0f);
		LivesLvStartUI.SetActive (false);
		Invoke ("DeactivateElectrifyText", 2.5f);
	}
}
