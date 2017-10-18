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
	}
}
