using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatform : MonoBehaviour {

    // ** Public variables **

    public GameObject centerOrbit;
	public float speed = 10;
	float lockPlatform = 0;

	//Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		
	}

	// Update is called once per frame
	void Update () {

        // ** Rotate platforms **

        this.transform.RotateAround (centerOrbit.transform.position, Vector3.forward, speed);
		transform.rotation = Quaternion.Euler(lockPlatform, lockPlatform, lockPlatform);
	}
}
