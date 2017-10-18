using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenWorldManager : MonoBehaviour {

	public GameObject canvas;
	public Text lv1Text;
	public Button lv1Button;

	public GameObject lv2Text;
	public GameObject lv2Button;
	//public GameObject lv2Location;

	// Use this for initialization
	void Start () {
		Text Lv1Text = Instantiate (lv1Text) as Text;
		Lv1Text.transform.SetParent (canvas.transform);
		Lv1Text.transform.localPosition = new Vector3 (-421f, 101, 385);

		Button Lv1Button = Instantiate (lv1Button) as Button;
		Lv1Button.transform.SetParent (canvas.transform);
		Lv1Button.transform.localPosition = new Vector3 (-435f, 16, 385);
	}

	void Awake() 
	{
		Lv2 ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Lv2()
	{
		int Lv1Done = PlayerPrefs.GetInt("Lv1Done");
		if (Lv1Done == 1)
		{
			GameObject Lv2Text = Instantiate (lv2Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv2Text.transform.SetParent (canvas.transform);

			GameObject Lv2Button = Instantiate (lv2Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv2Button.transform.SetParent (canvas.transform);

			//GameObject Lv2Location = Instantiate (lv2Location) as GameObject;
			//Lv2Location.transform.position = new Vector2 (7f, -3f);

			Debug.Log (Lv1Done);
		}
	}
}
