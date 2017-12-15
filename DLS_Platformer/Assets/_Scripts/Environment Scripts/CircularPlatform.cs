using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatform : MonoBehaviour {

    // ** Public variables **

	public GameObject platform;

	public float moveSpeed;
	//public Transform current;

	public Transform[] locations;

	public int selection;

	private GameObject target = null;
	private Vector3 offset;

    public GameObject centerOrbit;
	public float speed = 10;
	float lockPlatform = 0;

	//Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		//current = locations [selection];
		target = null;
	}

	void Awake(){
		
	}

	// Update is called once per frame
	void Update () {

        // ** Rotate platforms **

		this.transform.RotateAround (centerOrbit.transform.position, Vector3.forward * Time.deltaTime, speed);
		transform.rotation = Quaternion.Euler(lockPlatform, lockPlatform, lockPlatform);
//		if (platform.transform.position == current.position) 
//		{
//			selection++;
//			if (selection == locations.Length)
//			{
//				selection = 0;
//			}
//			current = locations [selection];
//		}
	}

	void LateUpdate()
	{
		if (target != null) 
		{
			target.transform.position = transform.position + offset;
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		target = col.gameObject;
		offset = target.transform.position - transform.position;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		target = null;
	}
}
