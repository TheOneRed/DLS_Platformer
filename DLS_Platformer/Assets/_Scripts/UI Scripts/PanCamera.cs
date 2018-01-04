using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanCamera : MonoBehaviour {

	//PUBLIC VARIABLES

	public GameObject player;
	public float speed;
	public GameObject panCheckpoint1;
	public GameObject panCheckpoint2;
	public Text electrifyText;
	public GameObject LivesUI;

	//PRIVATE VARIABLES

	private int checkpoints = 0;
	private const float minDistance = 1.2f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		switch (checkpoints) 
		{
		case 0:
			this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint1.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - panCheckpoint1.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 1;
			}
			break;
		case 1:
			this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint2.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - panCheckpoint2.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 2;
			}
			break;
		case 2:
			this.transform.position = Vector2.MoveTowards (this.transform.position, player.transform.position, speed * Time.deltaTime);
			if ((this.transform.position - player.transform.position).sqrMagnitude <= minDistance * minDistance) 
			{
				checkpoints = 3;
			}
			break;
		case 3:
			this.gameObject.SetActive (false);
			player.gameObject.SetActive (true);
			LivesUI.SetActive (true);
			Invoke ("DeactivateElectrifyText", 2.5f);
			break;
		}
	}

	void DeactivateElectrifyText()
	{
		electrifyText.enabled = false;
	}
}