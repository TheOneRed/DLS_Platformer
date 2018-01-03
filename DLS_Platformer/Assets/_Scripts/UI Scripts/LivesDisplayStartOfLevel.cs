using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesDisplayStartOfLevel : MonoBehaviour {

	//PUBLIC VARIABLES
	public GameObject LivesUI;
	public GameObject LivesLvStartUI;
	public bool isScene = true;
	public Text electrifyText; 

	// Use this for initialization
	void Start () {
		//if (SceneManager.GetActiveScene ().name == "BossBattle1") 
		if (isScene == true)
		{
			LivesUI.SetActive (false);
			LivesLvStartUI.SetActive (true);
			Time.timeScale = 0f;
			Invoke ("DeactivateLivesLvStartUI", 5.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (LivesLvStartUI.activeInHierarchy == true) 
			if(isScene == true)
		{
			
			Time.timeScale = 0f;
		} 
		//if(LivesLvStartUI.activeInHierarchy == false)
			if(isScene == false)
		{
			Time.timeScale = 0f;
		}
	}

	void DeactivateLivesLvStartUI()
	{
		LivesLvStartUI.SetActive (false);
		LivesUI.SetActive (true);
		Time.timeScale = 0f;
		isScene = false;
		Invoke ("DeactivateElectrifyText", 2.5f);
	}

	void DeactivateElectrifyText()
	{
		electrifyText.enabled = false;
	}
}
