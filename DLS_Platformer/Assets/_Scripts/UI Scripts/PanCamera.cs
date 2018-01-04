using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanCamera : MonoBehaviour {

	public GameObject player;
	public float speed;
	public GameObject panCheckpoint1;
	public GameObject panCheckpoint2;
	private bool check1Reached = false;
	private bool check2Reached = false;
	private int checkpoints = 0;
	private const float minDistance = 1.2f;
	public Text electrifyText;
	public GameObject LivesUI;

	//private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		//player.SetActive (false);
		//enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	// Update is called once per frame
	void Update () {
		//GameObject closeEnemy = FindClosestEnemy ();
		//if (check1Reached == false || this.transform.position != panCheckpoint1.transform.position) 
		//{
		//	this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint1.transform.position, speed * Time.deltaTime);
		//	check1Reached = true;
		//}
		//if (check1Reached == true || this.transform.position == panCheckpoint2.transform.position) 
		//{
		//	this.transform.position = Vector2.MoveTowards (this.transform.position, panCheckpoint2.transform.position, speed * Time.deltaTime);
		//	check2Reached = true;
		//}
		//if (check2Reached == true)
		//{
		//	this.transform.position = Vector2.MoveTowards (this.transform.position, player.transform.position, speed * Time.deltaTime);
		//}
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

//	public GameObject FindClosestEnemy()
//	{
//		//GameObject[] platforms;
//		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
//		GameObject closestEnemy = null;
//
//		float distance = Mathf.Infinity;
//		Vector3 position = transform.position;
//		//Vector3 negShotPosition = negativeFire.transform.position;
//
//		foreach (GameObject plat in enemies) 
//		{
//			Vector3 distanceDifference = plat.transform.position - position;
//
//			float currentDistance = distanceDifference.sqrMagnitude;
//
//
//			if (currentDistance < distance) 
//			{
//				closestEnemy = plat;
//				distance = currentDistance;
//			}
//		}
//		return closestEnemy;
//	}
//}
