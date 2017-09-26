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
	public float jump = 500f;
	public VelocityRange velocityRange = new VelocityRange(300f, 1000f);

	private Rigidbody2D rgb;
	private float _movingValue = 0;

	// Use this for initialization
	void Start () {
		this.rgb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float forceX = 0f;
		float forceY = 0f;

		float absVelX = Mathf.Abs(this.rgb.velocity.x);
		float absVelY = Mathf.Abs(this.rgb.velocity.y);

		this._movingValue = Input.GetAxis("Horizontal"); // gives moving variable a value of -1 to 1
		// Update is called once per frame
		if (this._movingValue != 0)
		{ // player is moving
				// move right
				if (absVelX < this.velocityRange.vMax)
					{
						forceX = this.speed;
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
		if ((Input.GetKey("space")))
		{
			
				if (absVelY < this.velocityRange.vMax)
				{
					forceY = this.jump;
				}
			}
		// add force to the player to push him
		this.rgb.AddForce(new Vector2(forceX, forceY));
		}


	}
			
		


