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
	public Text kitchenText;
	public Button kitchenWorldButton;
	public bool kitchenButtonClicked = false;
	public GameObject kitchenBackGround;
	bool kitchenBackCreated = false;

	public GameObject canvas;
	public Text lv1Text;
	public Button lv1Button;

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
			Invoke ("InstanKitchenBack", 5.4f);
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
		kitchenText.gameObject.SetActive (false);
		kitchenButtonClicked = true;
	}

	void InstanKitchenBack()
	{
		if (!kitchenBackCreated) 
		{
			kitchenWorldButton.gameObject.SetActive (false);
			GameObject KitchenBackGround = Instantiate (kitchenBackGround) as GameObject;
			kitchenBackCreated = true;
			Text Lv1Text = Instantiate (lv1Text) as Text;
			Lv1Text.transform.SetParent (canvas.transform);
			Lv1Text.transform.localPosition = new Vector3 (-421f, -150, 385);

			Button Lv1Button = Instantiate (lv1Button) as Button;
			Lv1Button.transform.SetParent (canvas.transform);
			Lv1Button.transform.localPosition = new Vector3 (-435f, -216, 385);
			//Lv1Text.rectTransform = new Vector3 (-435f, 12, 385);
			//lv1Text.transform = new Vector3 (-435f, 12, 385);
			//Lv1Text.transform.SetParent (canvas.transform);
		}
	}
}
