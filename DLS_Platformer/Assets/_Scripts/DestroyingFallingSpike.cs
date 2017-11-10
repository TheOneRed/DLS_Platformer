using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingFallingSpike : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D otherCollider){

        // ** Destroy the spike **

        if (otherCollider.gameObject.CompareTag("MovingSpikes")){
			Destroy (gameObject);
		}

	}
}
