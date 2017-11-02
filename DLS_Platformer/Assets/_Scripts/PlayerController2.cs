using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour {
	
	public float speed = 50f;
	public float runSpeed = 65f;
	public float normalSpeed;
	public float jump = 200f;
	public bool isRunning = false;
	public bool grounded = true;
	public GameObject platforms;
	public Text lives;

	private Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
		this.rgb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		float y = 0;

		transform.Translate (x, 0, 0);

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.LeftShift)
			|| Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.LeftShift)) {

			isRunning = true;
			speed = runSpeed;
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
			isRunning = false;
		}
		else {
			isRunning = false;
			speed = normalSpeed;
		}

		if ((Input.GetKey(KeyCode.Space)) && grounded == true)
		    {
				grounded = false;
				y = this.jump;
				
			}
		if ((Input.GetKey(KeyCode.S)) && grounded == true)
		{
			this.GetComponent<BoxCollider2D>().enabled = false;

		}

		if (grounded == false && this.GetComponent<Rigidbody2D> ().velocity.y > 0)
		{
			//Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), platforms.GetComponent<BoxCollider2D>());
			//Physics2D.IgnoreLayerCollision(8, 0);
			//Debug.Log (this.GetComponent<Rigidbody2D> ().velocity.y);
			this.GetComponent<BoxCollider2D>().enabled = false;
		}
		if (this.GetComponent<Rigidbody2D> ().velocity.y < 0) 
		{
			this.GetComponent<BoxCollider2D>().enabled = true;
		}

		this.rgb.AddForce(new Vector2(0, y));
		}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform")
		{
			Debug.Log (grounded);
			grounded = true;
		} 
		if (coll.transform.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform") 
		{
			transform.parent = coll.transform;
		}
		if (coll.gameObject.tag == "Spike" || coll.gameObject.tag == "Enemy") 
		{
			int currentLives = int.Parse(lives.text);
			currentLives--;
			lives.text = currentLives.ToString ();
			if (currentLives == 0) 
			{
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform")
		{
			Debug.Log (grounded);
			grounded = false;
		} 
		if(coll.transform.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform")
		{
			transform.parent = null;
		}
	}

	}

