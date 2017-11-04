using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

	public GameObject boss;
	public GameObject fireSprite;
	//GameObject fireSprite;

	public float moveSpeed;
	public Transform current;
	public Transform newPoint;
	public Transform Platform1FireEndPoint;
	bool changeLocations = true;

	//public Transform[] locations;

	//public int selection;

	// Use this for initialization
	void Start () {

		//current = locations [selection];
		
	}
	
	// Update is called once per frame
	void Update () {


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

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("Boss colliding");
		GameObject firingSprite = Instantiate (fireSprite) as GameObject;
		firingSprite.transform.localPosition = new Vector3 (11f, 4, 385);

		if (coll.gameObject.tag == "EnvironmentDamager") 
		{
			Destroy (coll.gameObject);
			moveSpeed = 10;
		}
	}
}
