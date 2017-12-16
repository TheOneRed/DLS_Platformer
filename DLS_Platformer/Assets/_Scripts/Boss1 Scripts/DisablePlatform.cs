using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlatform : MonoBehaviour {

	//public GameObject negativeFire;

	private GameObject[] platforms;
	private GameObject closePlatform;
	public GameObject brokenPlatform;
	public GameObject brokePlatform;

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
			brokePlatform = Instantiate (brokenPlatform) as GameObject;
			brokePlatform.transform.localPosition = closePlatform.transform.position;
			Invoke ("DestroyBrokenPlatform", 1.5f);
			//Destroy (coll);
			Invoke ("ReactivateDisabledPlatform", 3.0f);
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

	public void DestroyBrokenPlatform()
	{
		Destroy (brokePlatform);
	}
		
}
