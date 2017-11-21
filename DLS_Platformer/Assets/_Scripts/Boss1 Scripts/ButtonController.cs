using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    // ** Public variables **

    public GameObject[] buttons;
	public GameObject current;


	// Use this for initialization
	void Start () {

        // ** Activate buttons **

        foreach (GameObject go in buttons) {
			go.SetActive (false);
			Debug.Log ("works");
		}
		ButtonSpawn ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // ** Spawn buttons **

    void ButtonSpawn() {

		int index = Random.Range (0, buttons.Length);
		current = buttons [index];
		current.SetActive (true);
	}

    // ** Despawn buttons **

    public void ButtonDespawn() {
		current.SetActive (false);
		ButtonSpawn ();
	}
}
