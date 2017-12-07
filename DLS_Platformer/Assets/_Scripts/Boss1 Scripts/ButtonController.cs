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
		current.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // ** Spawn buttons **

    void ButtonSpawn() {

		int index = Random.Range (0, buttons.Length);
		current = buttons [index];
		current.SetActive (true);

		Invoke ("ReactivateDamagerBool", 0.5f);

	}

    // ** Despawn buttons **

    public void ButtonDespawn() {
		current.SetActive (false);
		ButtonSpawn ();

	}

	void ReactivateDamagerBool()
	{
		if (GameObject.Find ("Player").GetComponent<PlayerController2> ().singleDamager) 
		{
			GameObject.Find ("Player").GetComponent<PlayerController2> ().singleDamager = false;
		}
	}
}
