using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour {

    // ** Public Variables **

    public GameObject platform;

	public float moveSpeed;
	public Transform current;

	public Transform[] locations;

	public int selection;

	private GameObject target = null;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		current = locations [selection];
		target = null;
	}
	
	// Update is called once per frame
	void Update () {

        // ** Move the platform **

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, current.position, Time.deltaTime * moveSpeed);
		if (platform.transform.position == current.position) 
		{
			selection++;
			if (selection == locations.Length)
			{
				selection = 0;
			}
			current = locations [selection];
		}
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
