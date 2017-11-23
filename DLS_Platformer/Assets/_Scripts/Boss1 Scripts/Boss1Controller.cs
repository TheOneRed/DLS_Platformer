using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    // ** Public variables **

    public GameObject boss;
	public GameObject negativeFire;
	public GameObject positiveFire;
	public GameObject laserFire;
	public GameObject environmentDamager;
	//public GameObject fireSprite;
	//GameObject fireSprite;

	public float moveSpeed;
	public Transform current;
	public Transform newPoint;
	public Transform visionStart;
	public Transform visionEnd;
	public Transform Platform1FireEndPoint;
	public Transform FirePosition;
	public float delay = 1.0f;
	bool changeLocations = true;


	public bool singleFire = true;
	public bool negative = true;
	public bool positive = false;
	public bool phase2 = false;

	private bool iSeeYou = false;
	private float fire= 0.0f;

	//public Transform[] locations;

	//public int selection;

	// Use this for initialization
	void Start () {

		//current = locations [selection];
		
	}
	
	// Update is called once per frame
	void Update () {

        // ** Boss movement **

        if (changeLocations == true)
		{
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, newPoint.position, Time.deltaTime * moveSpeed);
		}
		if (boss.transform.position == newPoint.position) 
		{
			changeLocations = false;
		}
		if (changeLocations == false)
		{
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, current.position, Time.deltaTime * moveSpeed);

		}
		if (boss.transform.position == current.position) 
		{
			changeLocations = true;
		}

		this.iSeeYou = Physics2D.Linecast(this.visionStart.position, this.visionEnd.position, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawLine(this.visionStart.position, this.visionEnd.position);

		if (iSeeYou = true) {

			if (singleFire == true && phase2 == true && Time.time > fire) {
				fire = Time.time + delay;
				GameObject laseFire = Instantiate (laserFire, FirePosition.transform.position, FirePosition.rotation);
				//laserFire.transform = new Vector3 (this.FirePosition);
			}

			else if (negative == true && Time.time > fire) {
				fire = Time.time + delay;
				GameObject negFire = Instantiate (negativeFire, FirePosition.position, FirePosition.rotation);
				//laserFire.transform = new Vector3 (this.FirePosition);
				singleFire = false;
				negative = false;
				positive = true;
			} else if (positive == true && Time.time > fire) {
				fire = Time.time + delay;
				GameObject negFire = Instantiate (positiveFire, FirePosition.position, FirePosition.rotation);
				//laserFire.transform = new Vector3 (this.FirePosition);
				singleFire = false;
				positive = false;
				negative = true;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
        // ** Boss damage **

        if (coll.gameObject.tag == "EnvironmentDamager") 
		{
			phase2 = true;
			Destroy (coll.gameObject);
			moveSpeed = 10;
			//Instantiate (environmentDamager);
			//if (GameObject.Find ("Player").GetComponent<PlayerController2> ().singleDamager) 
			//{
			GameObject.Find ("Player").GetComponent<PlayerController2> ().environDamager.SetActive(true);
			//}
			//Invoke("ReactivateDamagerBool", 0.5f);
			GameObject.Find ("ButtonController").GetComponent<ButtonController> ().current.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		singleFire = true;
	}

	//void ReactivateDamagerBool()
	//{
	//	if (GameObject.Find ("Player").GetComponent<PlayerController2> ().singleDamager) 
	//	{
	//		GameObject.Find ("Player").GetComponent<PlayerController2> ().singleDamager = false;
	//	}
	//}

}
