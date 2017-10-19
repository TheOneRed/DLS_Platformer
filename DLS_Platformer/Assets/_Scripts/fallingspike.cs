using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingspike : MonoBehaviour {

	public GameObject spikes;

	public float moveSpeed;
	public Transform current;

	public Transform[] location;

	public int selection;

	// Use this for initialization
	void Start () {
		current = location [selection];
	}
	
	// Update is called once per frame
	void Update () {		
	}

	void OnTriggerEnter2D(Collider2D otherCollider){

		if (otherCollider.gameObject.CompareTag("Player")){
			spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, current.position, Time.deltaTime * moveSpeed);
			if (spikes.transform.position == current.position) 
			{
				selection++;
			}
		}

	}

}
