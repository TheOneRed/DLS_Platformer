using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

	Text electrifyText;

	// Use this for initialization
	void Start () {
		electrifyText = GetComponent<Text> ();
		//StartBlink ();
	}
	
	// Update is called once per frame
	void Update () {
		StartBlink ();
	}

	IEnumerator Blink()
	{
		while (true) 
		{
			switch (electrifyText.color.g.ToString ())
			{
			case "0.92":
				electrifyText.color = new Color (1f, 1f, 1f, 1f);
				yield return new WaitForSeconds (0.5f);
				break;
			case "1":
				electrifyText.color = new Color (1f, 0.92f, 0.016f, 1f);
				yield return new WaitForSeconds (0.5f);
				break;
			}
		}
	}

	void StartBlink()
	{
		StopCoroutine ("Blink");
		StartCoroutine ("Blink");
	}

	void StopBlink()
	{
		StopCoroutine ("Blink");
	}
}
