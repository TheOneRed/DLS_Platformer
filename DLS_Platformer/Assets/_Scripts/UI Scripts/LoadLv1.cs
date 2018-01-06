using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLv1 : MonoBehaviour {

	private AudioSource[] sounds;
	//private AudioSource hitSounds;
	private AudioSource backgroundSounds;

	public GameObject playerSprite;
	public GameObject playSprite;

	// Use this for initialization
	void Start () {
		GameObject audioControllerObject = GameObject.FindWithTag("SoundManager");
		sounds = audioControllerObject.GetComponents<AudioSource> ();
		//hitSounds = sounds[0];
		backgroundSounds = sounds[1];
		playerSprite = GameObject.FindGameObjectWithTag ("PlayerSprite");
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

	public void PlayerSpriteLv1()
	{
		Debug.Log ("SPRITE APPEAR WHERE?");
		playerSprite = GameObject.FindGameObjectWithTag ("PlayerSprite");
		playSprite = Instantiate (playerSprite) as GameObject;
		playSprite.transform.localPosition = new Vector3 (-3f, -1, 0);

	}

	public void PlayerSpriteLv2()
	{
		Debug.Log ("SPRITE APPEAR WHERE?");
		playerSprite = GameObject.FindGameObjectWithTag ("PlayerSprite");
		playSprite = Instantiate (playerSprite) as GameObject;
		playSprite.transform.localPosition = new Vector3 (-3f, 1, 0);

	}

	public void PlayerSpriteDestroy()
	{
		Destroy (playSprite);
	}
}
