using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingspike : MonoBehaviour {

    // ** Public Variables  **

    public GameObject spikes;

	public float moveSpeed;
	public Transform current;
	public Rigidbody2D rig;
	//public Transform ground;
	//public Transform[] location;

	//public int selection;

	// Use this for initialization
	void Start () {
		//current = location [selection];
		//rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {		


		
	}

	void OnTriggerEnter2D(Collider2D otherCollider){

        // ** Collide with player logic  **

        if (otherCollider.gameObject.CompareTag("Player")){
			rig.gravityScale = 1;
			//spikes.transform.position = Vector2.MoveTowards(spikes.transform.position, current.transform.position, Time.deltaTime * moveSpeed);
			//spikes.transform.Translate(current.transform.position, Space.World);
			//if (spikes.transform.position == current.position)
			//{
			//	selection++;
			//}
		}

	}

}
