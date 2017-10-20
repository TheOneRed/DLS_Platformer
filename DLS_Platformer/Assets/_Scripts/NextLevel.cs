using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	public AudioSource winSound;

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
		PlayerPrefs.SetInt ("Lv1Done", 1);
		Application.LoadLevel ("KitchenOverWorld");

		int Lv1Done = PlayerPrefs.GetInt("Lv1Done");

		Debug.Log (Lv1Done);

		if (Lv1Done == 1) 
		{
			PlayerPrefs.SetInt ("Lv2Done", 2);
			Application.LoadLevel ("KitchenOverWorld");

			int LvTest1 = PlayerPrefs.GetInt("Lv1Done");
			Debug.Log (LvTest1);
			int LvTest2 = PlayerPrefs.GetInt ("Lv2Done");
			Debug.Log (LvTest2);
		}
	}
}
