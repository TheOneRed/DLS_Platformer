using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	//public instances
	public float speed = 1f;
	public Transform visionStart;
	public Transform visionEnd;
	public int lifeValue;

	//private instances
	private Rigidbody2D rb2d;
	private Transform _transform;
	private Animator anim;

	private bool grounded = false;
	private bool NOPE = false;


	// Use this for initialization
	void Start () {

		this.rb2d = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform>();
		this.anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if(this.grounded)
		{
			this.anim.SetInteger("State", 1); //waling state
			this.rb2d.velocity = new Vector2(this._transform.localScale.x, 0) * this.speed;

			this.NOPE = Physics2D.Linecast(this.visionStart.position, this.visionEnd.position, 1 << LayerMask.NameToLayer("Solid"));
			Debug.DrawLine(this.visionStart.position, this.visionEnd.position);

			if (NOPE == false)
			{
				this._flip();
			}
		}

		else
		{
			this.anim.SetInteger("State", 0); // idle state
		}
	}

	void OnCollisionStay2D(Collision2D otherCollider)
	{
		if (otherCollider.gameObject.CompareTag("Ground"))
		{
			this.grounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D otherCollider)
	{
		if (otherCollider.gameObject.CompareTag("Ground"))
		{
			this.grounded = true;
		}
	}


	private void _flip()
	{
		if (this._transform.localScale.x == -25)
		{
			this._transform.localScale = new Vector3(25f, 25f, 1f);
		}
		else
		{
			this._transform.localScale = new Vector3(-25f, 25f, 1f); 
		}
	}

}
