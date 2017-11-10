using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    // ** Public variables **

    public GameObject boss;
	public GameObject fireSprite;
	//GameObject fireSprite;

	public float moveSpeed;
	public Transform current;
	public Transform newPoint;
	public Transform Platform1FireEndPoint;
	bool changeLocations = true;

	public bool singleFire = true;

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
		if (singleFire == true && coll.gameObject.tag != "EnvironmentDamager") 
		{
			GameObject firingSprite = Instantiate (fireSprite) as GameObject;
			firingSprite.transform.localPosition = new Vector3 (11f, 4, 385);
			singleFire = false;
		}

        // ** Boss damage **

        if (coll.gameObject.tag == "EnvironmentDamager") 
		{
			Destroy (coll.gameObject);
			moveSpeed = 10;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		singleFire = true;
	}

}
