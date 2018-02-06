using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanCamera : MonoBehaviour {

	//PUBLIC VARIABLES

	public GameObject player;
	public float speed;
	public GameObject panCheckpoint1;
	public GameObject panCheckpoint2;
	public Text electrifyText;
	public GameObject LivesUI;
	public GameObject enemy;
	public bool alreadyPanned = false;

	int lastSceneIndex;

	//PRIVATE VARIABLES

	private int checkpoints = 0;
	private const float minDistance = 1.2f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//SceneUnloadedMethod (SceneManager.GetActiveScene ());
		if (lastSceneIndex != SceneManager.GetActiveScene ().buildIndex) 
		{
			this.gameObject.SetActive (true);
			if (SceneManager.GetActiveScene ().name == "BossBattle1") 
			{
				this.gameObject.SetActive (false);
			}
		}
		//panCamera.SetActive (true);
		if (lastSceneIndex == SceneManager.GetActiveScene ().buildIndex) 
		{
			this.gameObject.SetActive (false);
		}
		
		switch (checkpoints) 
		{
		case 0:
			if (SceneManager.GetActiveScene ().name == "BossBattle1") 
			{
				this.gameObject.SetActive (false);
				this.gameObject.SetActive (false);
				player.gameObject.SetActive (true);
				LivesUI.SetActive (true);
				enemy.SetActive (true);
				Invoke ("DeactivateElectrifyText", 2.5f);
			}
			this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint1.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - panCheckpoint1.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 1;
			}
			break;
		case 1:
			this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint2.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - panCheckpoint2.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 2;
			}
			break;
		case 2:
			this.transform.position = Vector2.MoveTowards (this.transform.position, player.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - player.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 3;
			}
			break;
		case 3:
			this.gameObject.SetActive (false);
			player.gameObject.SetActive (true);
			LivesUI.SetActive (true);
			Invoke ("DeactivateElectrifyText", 2.5f);
			break;
		}
	}

	void DeactivateElectrifyText()
	{
		electrifyText.enabled = false;
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
			//this.gameObject.SetActive (false);
		}
		if (lastSceneIndex == sceneIndex) 
		{
			this.gameObject.SetActive (false);
			//player.SetActive (true);
		}
	}
	public int GetLastSceneNumber()
	{
		return lastSceneIndex;
	}
}