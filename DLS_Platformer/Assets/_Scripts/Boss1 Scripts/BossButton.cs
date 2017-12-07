using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour {
	
	private Animator animator;
	private ButtonController buttonController;

	// Use this for initialization
	void Start () {

		this.animator = GetComponent<Animator> ();

		GameObject buttonControllerObject = GameObject.FindWithTag("ButtonController");
		if (buttonControllerObject != null)
		{
			buttonController = buttonControllerObject.GetComponent<ButtonController>();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			
			this.animator.SetInteger ("State", 1);
			Invoke ("Delay", 5);
		}


	}

	void Delay(){
		buttonController.ButtonDespawn ();
	}


}
