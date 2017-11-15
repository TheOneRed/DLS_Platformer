using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // ** Public variables **

    public float speed = 1f;
	public Transform visionStart;
	public Transform visionEnd;
	public int lifeValue;
	public BoxCollider2D box;


    // ** Private variables **

    private Rigidbody2D rb2d;
	private Transform _transform;
	private Animator anim;

	private bool grounded = false;
	private bool NOPE = false;


	// Use this for initialization
	void Start () {

        // ** Getting components **

        this.rb2d = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform>();
		this.anim = gameObject.GetComponent<Animator> ();
		this.box = gameObject.GetComponent<BoxCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

        // ** Enemy movement **

        if (this.grounded)
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

	void OnCollisionEnter2D(Collision2D otherCollider){

        // ** Enemy collision logic **

        if (otherCollider.gameObject.CompareTag("Enemy"))
		{
			this._flip ();
		}

		if (otherCollider.gameObject.CompareTag("Spike"))
		{
			this._flip ();
		}

		if (otherCollider.gameObject.CompareTag("Wall"))
		{
			this._flip ();
		}
		if (otherCollider.gameObject.CompareTag("WallCollider"))
		{
			this._flip ();
		}
	}

	void OnCollisionStay2D(Collision2D otherCollider)
	{
        // ** Verify if enemy is grounded  **

        if (otherCollider.gameObject.CompareTag("Ground"))
		{
			this.grounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D otherCollider)
	{
        // ** Verify if enemy is grounded  **

        if (otherCollider.gameObject.CompareTag("Ground"))
		{
			this.grounded = true;
		}
	}

    // ** Flip the enemy  **

    private void _flip()
	{
		if (this._transform.localScale.x == -1)
		{
			this._transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else
		{
			this._transform.localScale = new Vector3(-1f, 1f, 1f); 
		}
	}

}
