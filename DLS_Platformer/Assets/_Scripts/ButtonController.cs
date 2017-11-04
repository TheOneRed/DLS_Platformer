using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject[] buttons;
	public GameObject current;


	// Use this for initialization
	void Start () {
		foreach (GameObject go in buttons) {
			go.SetActive (false);
			Debug.Log ("works");
		}
		ButtonSpawn ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ButtonSpawn() {

		int index = Random.Range (0, buttons.Length);
		current = buttons [index];
		current.SetActive (true);
	}

	public void ButtonDespawn() {
		current.SetActive (false);
		ButtonSpawn ();
	}
}
