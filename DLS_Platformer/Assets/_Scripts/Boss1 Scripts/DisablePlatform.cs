using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlatform : MonoBehaviour {

	//public GameObject negativeFire;

	private GameObject[] platforms;
	private GameObject closePlatform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject.tag == "NegativeShot") {
			closePlatform = FindClosestPlatform ();
			closePlatform.SetActive (false);
			Destroy (coll);
			Invoke ("ReactivateDisabledPlatform", 2.5f);
		}
	}

	public GameObject FindClosestPlatform()
	{
		//GameObject[] platforms;
		platforms = GameObject.FindGameObjectsWithTag ("Ground");
		GameObject closestPlatform = null;

		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		//Vector3 negShotPosition = negativeFire.transform.position;

		foreach (GameObject plat in platforms) 
		{
			Vector3 distanceDifference = plat.transform.position - position;

			float currentDistance = distanceDifference.sqrMagnitude;


			if (currentDistance < distance) 
			{
				closestPlatform = plat;
				distance = currentDistance;
			}
		}
		return closestPlatform;
	}
		

	public void ReactivateDisabledPlatform()
	{
		closePlatform.SetActive (true);
	}
		
}
