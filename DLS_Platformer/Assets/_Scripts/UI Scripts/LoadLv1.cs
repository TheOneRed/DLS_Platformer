using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLv1 : MonoBehaviour {

	private AudioSource[] sounds;
	//private AudioSource hitSounds;
	private AudioSource backgroundSounds;

	// Use this for initialization
	void Start () {
		GameObject audioControllerObject = GameObject.FindWithTag("SoundManager");
		sounds = audioControllerObject.GetComponents<AudioSource> ();
		//hitSounds = sounds[0];
		backgroundSounds = sounds[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadByIndex(int sceneIndex)
	{
	    SceneManager.LoadScene(sceneIndex);
		if (sceneIndex == 2) 
		{
			
			backgroundSounds.Play();
		}
	}
}
