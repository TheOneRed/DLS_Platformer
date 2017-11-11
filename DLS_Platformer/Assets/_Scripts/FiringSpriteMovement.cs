using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSpriteMovement : MonoBehaviour {

    // ** Public Variables **

    public Transform Platform1FireEndPoint;
	public int moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position = Vector3.MoveTowards (this.transform.position, Platform1FireEndPoint.position, Time.deltaTime * moveSpeed);
		this.transform.Translate (-0.1f,0,0, Space.World);

	}
}
