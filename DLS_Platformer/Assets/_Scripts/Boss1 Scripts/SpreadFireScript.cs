using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadFireScript : MonoBehaviour {

	public GameObject positiveFire;
	public GameObject negativeFire;
	public bool singleFire = false;
	public bool activateSpread = false;


	private GameObject[] platforms;
	private Transform posFireTransform;
	private GameObject closePlatform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (activateSpread == true) 
		{
			//GameObject posFire = Instantiate (positiveFire) as GameObject;
			//posFire.transform.position = transform.position;
			singleFire = true;
			activateSpread = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "PositiveShot" && singleFire == false) 
		{
			posFireTransform = coll.transform;
			CreateSpread (-30f);
			CreateSpread (-15f);
			CreateSpread (0f);
			//CreateSpread (15f);
			//CreateSpread (30f);
			activateSpread = true;
		}

//		if (coll.gameObject.tag == "NegativeShot")
//		{
//			closePlatform = FindClosestPlatform ();
//			closePlatform.SetActive (false);
//			Invoke ("ReactivateDisabledPlatform", 2.5f);
//		}

		// ** Destroy the beam **

		//if (coll.gameObject.tag == "Beam" || coll.gameObject.tag == "NegativeShot" || coll.gameObject.tag == "PositiveSmallShot") 
		//{
		//	Destroy (coll.gameObject);

		//}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "PositiveShot") 
		{
			singleFire = false;
			//Destroy (coll.gameObject);

		}

		Destroy (coll.gameObject);
	}

	void CreateSpread(float angle)
	{
		GameObject posFire = Instantiate (positiveFire) as GameObject;
		//posFire.transform.position = transform.position;
		posFire.transform.position = posFireTransform.position;
		singleFire = true;
		activateSpread = false;
		Rigidbody2D rb = posFire.GetComponent<Rigidbody2D> ();
		rb.AddForce (Quaternion.AngleAxis (angle, Vector3.forward) * transform.right * 500.0f);
	}

	public GameObject FindClosestPlatform()
	{
		//GameObject[] platforms;
		platforms = GameObject.FindGameObjectsWithTag ("Ground");
		GameObject closestPlatform = null;

		float distance = Mathf.Infinity;
		//Vector3 position = transform.position;
		Vector3 negShotPosition = negativeFire.transform.position;

		foreach (GameObject plat in platforms) 
		{
			Vector3 distanceDifference = plat.transform.position - negShotPosition;

			float currentDistance = distanceDifference.sqrMagnitude;

			Debug.Log (closestPlatform);

			if (currentDistance < distance) 
			{
				closestPlatform = plat;
				distance = currentDistance;
				Debug.Log ("in if: " + closestPlatform);
			}
		}
		return closestPlatform;
	}

	public void ReactivateDisabledPlatform()
	{
		closePlatform.SetActive (true);
	}
}
