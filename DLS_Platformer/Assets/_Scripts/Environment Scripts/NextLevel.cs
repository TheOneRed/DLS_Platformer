using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Application.LoadLevel ("KitchenOverWorld");
		int LvDone = PlayerPrefs.GetInt ("LvDone");
        string scene = SceneManager.GetActiveScene().name;
		switch (LvDone) {
		case 0:
			PlayerPrefs.SetInt ("LvDone", 1);
			break;
		case 1:
            if(scene == "level 2")
                {
                    PlayerPrefs.SetInt ("LvDone", 2);
                }
			
			break;
		case 2:
            if(scene == "level 3 flying")
                {
                    PlayerPrefs.SetInt ("LvDone", 3);
                }
			
			break;
		case 3:
			if (scene == "Level 4 moving") 
			{
				PlayerPrefs.SetInt ("LvDone", 4);
			}
			break;
		case 4:
			if (scene == "Level 5") 
			{
				PlayerPrefs.SetInt ("LvDone", 5);
			}
			break;
		}
	}
}

