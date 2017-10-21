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

	public GameObject lv3Text;
	public GameObject lv3Button;

	public GameObject lv4Text;
	public GameObject lv4Button;
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
		Lv3 ();
		Lv4 ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Lv2()
	{
		int Lv1Done = PlayerPrefs.GetInt("Lv1Done");
		int Lv2Done = PlayerPrefs.GetInt("Lv2Done");
		if (Lv1Done == 1)
		{
			GameObject Lv2Text = Instantiate (lv2Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv2Text.transform.SetParent (canvas.transform);

			GameObject Lv2Button = Instantiate (lv2Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv2Button.transform.SetParent (canvas.transform);
		}
	}

	public void Lv3()
	{
		int Lv2Done = PlayerPrefs.GetInt("Lv2Done");
		if (Lv2Done == 2)
		{
			GameObject Lv3Text = Instantiate (lv3Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv3Text.transform.SetParent (canvas.transform);
			Lv3Text.transform.localPosition = new Vector3 (-160f, 109, 385);

			GameObject Lv3Button = Instantiate (lv3Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv3Button.transform.SetParent (canvas.transform);
			Lv3Button.transform.localPosition = new Vector3 (-31f, 109, 385);
		}
	}

	public void Lv4()
	{
		int Lv3Done = PlayerPrefs.GetInt ("Lv3Done");
		if (Lv3Done == 3) {
			GameObject Lv4Text = Instantiate (lv4Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv4Text.transform.SetParent (canvas.transform);
			Lv4Text.transform.localPosition = new Vector3 (-181f, -231, 385);

			GameObject Lv4Button = Instantiate (lv4Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv4Button.transform.SetParent (canvas.transform);
			Lv4Button.transform.localPosition = new Vector3 (-54f, -231, 385);
		}
	}
}
