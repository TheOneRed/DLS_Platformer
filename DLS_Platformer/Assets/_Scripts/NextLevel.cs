using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

    // ** Public Variables **

    public AudioSource winSound;
	bool Lv2Bool = false;

	public string sceneToLoad;
	public Color loadToColour = Color.black;

	// Use this for initialization
	void Start () {
		winSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D Man)
	{
		if (Man.gameObject.tag == "Player") 
		{
			
			Invoke ("GoToNextLevel", 0.5f);
			winSound.Play ();
		}
	}

	public void GoToNextLevel()
	{
        // ** Change levels  **

        //ChangeLevel ();
        //PlayerPrefs.SetInt ("Lv1Done", 1);
        Application.LoadLevel ("KitchenOverWorld");
		//int Lv1Done = PlayerPrefs.GetInt("Lv1Done");
		int LvDone = PlayerPrefs.GetInt ("LvDone");

		switch (LvDone) {
		case 0:
			//PlayerPrefs.SetInt ("Lv1Done", 1);
			PlayerPrefs.SetInt ("LvDone", 1);
			break;
		case 1:
			//PlayerPrefs.SetInt ("Lv2Done", 2);
			PlayerPrefs.SetInt ("LvDone", 2);
			int Lv2Done = PlayerPrefs.GetInt ("Lv2Done");
			Debug.Log ("SWITCH STATEMENT LV2DONE = " + Lv2Done);
			break;
		case 2:
			//PlayerPrefs.SetInt ("Lv3Done", 3);
			PlayerPrefs.SetInt ("LvDone", 3);
			int Lv3Done = PlayerPrefs.GetInt ("Lv3Done");
			Debug.Log ("SWITCH STATEMENT LV3DONE = " + Lv3Done);
			break;
		case 3:
			PlayerPrefs.SetInt ("LvDone", 4);
			//PlayerPrefs.SetInt ("Lv4Done", 4);
			break;
		case 4:
			PlayerPrefs.SetInt ("LvDone", 5);
			break;
		}
		//GameObject.Find ("GameController").GetComponent<SceneTransitionFade>().BeginFade (1);

	}


		//IEnumerator ChangeLevel ()
		//{
		//Debug.Log ("SCENE CHANGING ENUMERATOR!");
		//float fadeTime = GameObject.Find ("GameController").GetComponent<SceneTransitionFade>().BeginFade (1);
		//yield return new WaitForSeconds (fadeTime);
		//Application.LoadLevel (4);
		//}
		//Debug.Log (Lv1Done);

		//if (Lv1Done == 1 && Lv2Bool == false) 
		//{
		//	Lv2Bool = true;
			//PlayerPrefs.SetInt ("Lv2Done", 2);
		//	Application.LoadLevel ("KitchenOverWorld");
			//PlayerPrefs.SetInt ("Lv2Done", 2);
			//int LvTest1 = PlayerPrefs.GetInt("Lv1Done");
			//Debug.Log (LvTest1);
			//int LvTest2 = PlayerPrefs.GetInt ("Lv2Done");
			//Debug.Log ("Next Level Early " + LvTest2);
		//}
		//if (Lv1Done == 2 && Lv2Bool == true) 
		//{
			//PlayerPrefs.SetInt ("Lv2Done", 2);
		//}
	}

