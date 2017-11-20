using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenWorldManager : MonoBehaviour {

    // ** Public Variables **

    public GameObject canvas;
	public Text lv1Text;
	public Button lv1Button;

	public GameObject lv2Text;
	public GameObject lv2Button;

	public GameObject lv3Text;
	public GameObject lv3Button;

	public GameObject lv4Text;
	public GameObject lv4Button;

	public GameObject lv5Text;
	public GameObject lv5Button;

	public GameObject lv6Text;
	public GameObject lv6Button;

	public Text lives;
	public int currentLives;


	// Use this for initialization
	void Start () {

        // ** Level 1 button **

        Text Lv1Text = Instantiate (lv1Text) as Text;
		Lv1Text.transform.SetParent (canvas.transform);
		Lv1Text.transform.localPosition = new Vector3 (-421f, -229, 385);

		Button Lv1Button = Instantiate (lv1Button) as Button;
		Lv1Button.transform.SetParent (canvas.transform);
		Lv1Button.transform.localPosition = new Vector3 (-435f, -291, 385);
	}

	void Awake() 
	{
		Lv2 ();
		Lv3 ();
		Lv4 ();
		Lv5 ();
		Lv6 ();
	}

	// Update is called once per frame
	void Update () {
		currentLives = PlayerPrefs.GetInt ("currentLives");
		lives.text = currentLives.ToString ();
	}

    // ** Activate each level if previous level is completed **

    public void Lv2()
	{
		int Lv1Done = PlayerPrefs.GetInt("LvDone");
		if (Lv1Done == 1 || Lv1Done == 2 || Lv1Done == 3 || Lv1Done == 4 || Lv1Done == 5)
		{
			GameObject Lv2Text = Instantiate (lv2Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv2Text.transform.SetParent (canvas.transform);
			Lv2Text.transform.localPosition = new Vector3 (-384f, 78, 385);

			GameObject Lv2Button = Instantiate (lv2Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv2Button.transform.SetParent (canvas.transform);
			Lv2Button.transform.localPosition = new Vector3 (-409f, 18, 385);
		}
	}

	public void Lv3()
	{
		int Lv2Done = PlayerPrefs.GetInt ("LvDone");
		if (Lv2Done == 2 || Lv2Done == 3 || Lv2Done == 4 || Lv2Done == 5)
		{
			GameObject Lv3Text = Instantiate (lv3Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv3Text.transform.SetParent (canvas.transform);
			Lv3Text.transform.localPosition = new Vector3 (-220f, 206, 385);

			GameObject Lv3Button = Instantiate (lv3Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv3Button.transform.SetParent (canvas.transform);
			Lv3Button.transform.localPosition = new Vector3 (-219f, 149, 385);
		}
	}

	public void Lv4()
	{
		int Lv3Done = PlayerPrefs.GetInt ("LvDone");
		if (Lv3Done == 3 || Lv3Done == 4 || Lv3Done == 5) 
		{
			GameObject Lv4Text = Instantiate (lv4Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv4Text.transform.SetParent (canvas.transform);
			Lv4Text.transform.localPosition = new Vector3 (201f, 88, 385);

			GameObject Lv4Button = Instantiate (lv4Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv4Button.transform.SetParent (canvas.transform);
			Lv4Button.transform.localPosition = new Vector3 (204f, 27, 385);
		}
	}

	public void Lv5()
	{
		int Lv4Done = PlayerPrefs.GetInt ("LvDone");
		if (Lv4Done == 4 || Lv4Done == 5) 
		{
			GameObject Lv5Text = Instantiate (lv5Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv5Text.transform.SetParent (canvas.transform);
			Lv5Text.transform.localPosition = new Vector3 (435f, -57, 385);

			GameObject Lv5Button = Instantiate (lv5Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv5Button.transform.SetParent (canvas.transform);
			Lv5Button.transform.localPosition = new Vector3 (438f, -155, 385);
		}
	}

	public void Lv6()
	{
		int Lv5Done = PlayerPrefs.GetInt ("LvDone");
		if (Lv5Done == 5 || Lv5Done == 6) 
		{
			GameObject Lv6Text = Instantiate (lv6Text) as GameObject;
			canvas.transform.position = new Vector2 (-65f, -210f);
			Lv6Text.transform.SetParent (canvas.transform);
			Lv6Text.transform.localPosition = new Vector3 (214f, -316, 385);

			GameObject Lv6Button = Instantiate (lv6Button) as GameObject;
			canvas.transform.position = new Vector2 (-220f, -292f);
			Lv6Button.transform.SetParent (canvas.transform);
			Lv6Button.transform.localPosition = new Vector3 (212f, -251, 385);
		}
	}
}
