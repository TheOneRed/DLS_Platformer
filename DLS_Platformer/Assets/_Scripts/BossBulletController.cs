using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
        // ** Destroy the bullet **

        if (coll.gameObject.tag == "Player") 
		{
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}
}
