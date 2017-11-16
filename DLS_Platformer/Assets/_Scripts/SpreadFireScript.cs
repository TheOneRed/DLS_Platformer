using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadFireScript : MonoBehaviour {

	public GameObject positiveFire;
	public bool singleFire = false;
	public bool activateSpread = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (activateSpread == true) 
		{
			GameObject posFire = Instantiate (positiveFire) as GameObject;
			posFire.transform.position = transform.position;
			singleFire = true;
			activateSpread = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("ENDER HITTING");
		
		if (coll.gameObject.tag == "PositiveShot" && singleFire == false) 
		{
			Debug.Log ("ender colliding with pos");
			CreateSpread (-30f);
			CreateSpread (-15f);
			CreateSpread (0f);
			//CreateSpread (15f);
			//CreateSpread (30f);
			activateSpread = true;
		}

		// ** Destroy the beam **

		if (coll.gameObject.tag == "Beam") 
		{
			Destroy (coll.gameObject);

		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "PositiveShot") 
		{
			singleFire = false;
		}
	}

	void CreateSpread(float angle)
	{
		GameObject posFire = Instantiate (positiveFire) as GameObject;
		posFire.transform.position = transform.position;
		singleFire = true;
		activateSpread = false;
		Rigidbody2D rb = posFire.GetComponent<Rigidbody2D> ();
		Debug.Log ("LITTLE GUYS MOVE!!!!");
		rb.AddForce (Quaternion.AngleAxis (angle, Vector3.forward) * transform.right * 500.0f);
	}
}
