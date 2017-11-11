using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    // ** Public variables **

    public GameObject boss;
	public GameObject negativeFire;
	public GameObject positiveFire;
	public GameObject laserFire;
	//public GameObject fireSprite;
	//GameObject fireSprite;

	public float moveSpeed;
	public Transform current;
	public Transform newPoint;
	public Transform Platform1FireEndPoint;
	bool changeLocations = true;

	public bool singleFire = true;
	public bool negative = true;
	public bool positive = false;
	public bool phase2 = false;

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


	}


	void OnTriggerEnter2D(Collider2D coll)
	{
        // ** Boss firing weapon **

        Debug.Log ("Boss colliding");
		if (singleFire == true && coll.gameObject.tag != "EnvironmentDamager" && phase2 == false) 
		{
			if (negative == true) 
			{
				GameObject negFire = Instantiate (negativeFire) as GameObject;
				negFire.transform.localPosition = new Vector3 (11f, 4, 385);
				singleFire = false;
				negative = false;
				positive = true;
			}
			else if (positive == true) 
			{
				GameObject negFire = Instantiate (positiveFire) as GameObject;
				negFire.transform.localPosition = new Vector3 (11f, 4, 385);
				singleFire = false;
				positive = false;
				negative = true;
			}
		}

		if (singleFire == true && coll.gameObject.tag != "EnvironmentDamager" && phase2 == true) 
		{
			GameObject laseFire = Instantiate (laserFire) as GameObject;
			laseFire.transform.localPosition = new Vector3 (11f, 4, 385);
		}

        // ** Boss damage **

        if (coll.gameObject.tag == "EnvironmentDamager") 
		{
			phase2 = true;
			Destroy (coll.gameObject);
			moveSpeed = 10;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		singleFire = true;
	}

}
