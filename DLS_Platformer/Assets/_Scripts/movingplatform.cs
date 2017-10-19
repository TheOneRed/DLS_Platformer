using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;
	public Transform current;

	public Transform[] locations;

	public int selection;


	// Use this for initialization
	void Start () {
		current = locations [selection];
	}
	
	// Update is called once per frame
	void Update () {

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
}
