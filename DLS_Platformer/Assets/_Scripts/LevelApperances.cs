using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelApperances : MonoBehaviour {

	public GameObject canvas;
	public GameObject lv2Text;
	public GameObject lv2Button;
	public GameObject lv2Location;

	void Awake () 
	{
		//Lv2 ();
	}

	void Start()
	{
		PlayerPrefs.SetInt ("Lv1Done", 0);
		PlayerPrefs.SetInt ("Lv2Done", 0);
		PlayerPrefs.SetInt ("Lv3Done", 0);
		int Lv1Done1 = PlayerPrefs.GetInt("Lv1Done");
		int Lv1Done2 = PlayerPrefs.GetInt("Lv2Done");
		Debug.Log("Lv1 save should be 0, " + Lv1Done1);
		Debug.Log("Lv2 save should be 0, " + Lv1Done2);
	}

	public void Lv2()
	{
		int Lv1Done = PlayerPrefs.GetInt("Lv1Done");
		if (Lv1Done == 1)
		{
			GameObject Lv2Text = Instantiate (lv2Text) as GameObject;
			canvas.transform.position = new Vector2 (85f, -3f);
			Lv2Text.transform.SetParent (canvas.transform);

			GameObject Lv2Button = Instantiate (lv2Button) as GameObject;
			canvas.transform.position = new Vector2 (85f, -23f);
			Lv2Button.transform.SetParent (canvas.transform);

			GameObject Lv2Location = Instantiate (lv2Location) as GameObject;
			//Lv2Location.transform.position = new Vector2 (7f, -3f);

			Debug.Log (Lv1Done);
		}
	}
}
