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

	int lastSceneIndex = 0;

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
		if (lastSceneIndex != SceneManager.GetActiveScene ().buildIndex) 
		{
				panCamera.SetActive (true);
		}
		//panCamera.SetActive (true);
		if (lastSceneIndex == SceneManager.GetActiveScene ().buildIndex) 
		{
			panCamera.SetActive (false);
		}
		isScene = false;
	}

	// we can use the SceneUnloaded delegate of scenemanager to listen for scenes that have been unloaded
	void OnEnable()        {    SceneManager.sceneUnloaded += SceneUnloadedMethod;        }
	void OnDisable()        {    SceneManager.sceneUnloaded -= SceneUnloadedMethod;        }

	//int lastSceneIndex = 0;

	// looks a bit funky but the method signature must match the scenemanager delegate signature
	void SceneUnloadedMethod (Scene sceneNumber)
	{
		//int sceneIndex = sceneNumber.buildIndex;
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		// only want to update last scene unloaded if were not just reloading the current scene
		if(lastSceneIndex != sceneIndex)
		{
			lastSceneIndex = sceneIndex;
			Debug.Log("unloaded scene is : " + lastSceneIndex);
		}
		if (lastSceneIndex == sceneIndex) 
		{
			panCamera.SetActive (false);
		}
	}
	public int GetLastSceneNumber()
	{
		return lastSceneIndex;
	}
		

	IEnumerator Example()
	{
		yield return new WaitForSeconds (5.0f);
		LivesLvStartUI.SetActive (false);
		Invoke ("DeactivateElectrifyText", 2.5f);
	}
}
