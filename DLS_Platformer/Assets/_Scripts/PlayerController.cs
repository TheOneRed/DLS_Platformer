using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VelocityRange {

	// PUBLIC INSTANCE VARIABLES
	public float vMin, vMax;


	// CONSTRUCTOR ++++++++++++++++++++++++++++++++
	public VelocityRange(float vMin, float vMax) {
		this.vMin = vMin;
		this.vMax = vMax;
	}
}

public class PlayerController : MonoBehaviour {

	public float speed = 50f;
	//public float runSpeed = 100f;
	public float jump = 500f;
	public VelocityRange velocityRange = new VelocityRange(10f, 10f);
	//public VelocityRange velocityRangeRun = new VelocityRange (10f, 30f);

	public bool grounded = true;

	private Rigidbody2D rgb;
	private float _movingValue = 0;

	// Use this for initialization
	void Start () {
		//rgb = this.GetComponent<Rigidbody2D> ();
		this.rgb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float forceX = 0f;
		float forceY = 0f;

		float absVelX = Mathf.Abs(this.rgb.velocity.x);
		float absVelY = Mathf.Abs(this.rgb.velocity.y);
		//float absVelZ = Mathf.Abs(this.rgb.velocity.x);
		//float absVelW = Mathf.Abs(this.rgb.velocity.y);

		this._movingValue = Input.GetAxis("Horizontal"); // gives moving variable a value of -1 to 1
		// Update is called once per frame
		if (this._movingValue != 0)
		{ // player is moving
				// move right
			Debug.Log (rgb.velocity);
				if (absVelX < this.velocityRange.vMax)
					{
						forceX = this.speed;
				if(Input.GetKey(KeyCode.LeftShift)){
					Debug.Log("Shift is clicked boi");
					VelocityRange velocityRange = new VelocityRange (30f, 30f);
					forceX = this.speed;
						}
					}
				}
				if (this._movingValue < 0)
				{
					// move left
					if (absVelX < this.velocityRange.vMax)
					{
						forceX = -this.speed;
					}
				}
		// check if player is jumping
		if ((Input.GetKey("space")) && grounded == true)
		{
				
				if (absVelY < this.velocityRange.vMax)
				{
				Debug.Log (grounded);
					forceY = this.jump;
					grounded = false;
				Debug.Log (forceY);
				//this.rgb.AddRelativeForce (new Vector2(forceX, forceY));
				}
			}
		// add force to the player to push him
		//Vector2 nw = new Vector2(forceX,forceY);
		this.rgb.AddForce(new Vector2(forceX, forceY));
		//rgb.velocity(nw.normalized * speed);
		//rgb.velocity = speed * (nw.normalized);
		//Debug.Log (this.rgb.velocity);

	}
		
	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground")
		{
			Debug.Log (grounded);
			grounded = true;
		} 
	}

	void OnCollisionExit2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground")
		{
			Debug.Log (grounded);
			grounded = false;
		} 
	}

	}
			
		


