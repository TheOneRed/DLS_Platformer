using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	//public void LoadByIndex(int sceneIndex)
    //{
    //    SceneManager.LoadScene(sceneIndex);
	//	PlayerPrefs.SetInt ("Lv1Done", 0);
    //}


	public Camera mainCamera;
	public Button kitchenWorldButton;
	public bool kitchenButtonClicked = false;
	public GameObject kitchenBackGround;


	void Start()
	{
		kitchenWorldButton = kitchenWorldButton.GetComponent<Button>();
		kitchenWorldButton.onClick.AddListener(TaskOnClick);
	}

	void Update()
	{
		if (mainCamera.orthographicSize > 2.80f && kitchenButtonClicked == true) 
		{
			mainCamera.orthographicSize = Mathf.MoveTowards (mainCamera.orthographicSize, -150.0f, Time.deltaTime * 0.5f);
			Invoke ("InstanKitchenBack", 5.8f);
		}
	}

	public void LoadByIndex(int sceneIndex)
	{
		if (sceneIndex == 2)
		{
			
		}
	}

	void TaskOnClick()
	{
		kitchenButtonClicked = true;
	}

	void InstanKitchenBack()
	{
		GameObject KitchenBackGround = Instantiate (kitchenBackGround) as GameObject;
	}
}
