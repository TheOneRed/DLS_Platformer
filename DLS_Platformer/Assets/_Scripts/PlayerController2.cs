using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerController2 : MonoBehaviour {

    // ** Public variables **

    public float speed = 50f;
	public float runSpeed = 65f;
	public float normalSpeed;
	public float jump = 200f;
	public bool isRunning = false;
	public bool grounded = true;
	public GameObject platforms;
	public Text lives;
	public Rigidbody2D environmentalDamager;
    public AudioClip dmgSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;

    // ** Private variables **

    private ButtonController buttonController;
	private Rigidbody2D rgb;
	private Animator animator;
	private float _movingValue = 0;

	// Use this for initialization
	void Start () {

        // **Getting components **

        this.rgb = gameObject.GetComponent<Rigidbody2D>();
		this.animator = gameObject.GetComponent<Animator> ();


		GameObject buttonControllerObject = GameObject.FindWithTag("ButtonController");
		if (buttonControllerObject != null)
		{
			buttonController = buttonControllerObject.GetComponent<ButtonController>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

        // ** Movement **

        var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		this._movingValue = Input.GetAxis ("Horizontal"); 
		float y = 0;

		transform.Translate (x, 0, 0);
		if (this._movingValue != 0) {

			if (this.grounded) {

				this.animator.SetInteger ("State", 1);

                // ** Running **

                if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.LeftShift)
				   || Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.LeftShift)) {

					isRunning = true;
					speed = runSpeed;
				} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
					isRunning = false;
				} else {
					this.animator.SetInteger ("State", 0);
					isRunning = false;
					speed = normalSpeed;
				}
			}
		}
		//&& grounded == true

        // ** Player jump when space is pressed **

		if (Input.GetKey (KeyCode.Space)) {
			
			if (grounded == true) {
				grounded = false;
				y = this.jump;
				SoundManager.instance.PlaySingle (jumpSound);
				this.animator.SetInteger ("State", 2);
			} else {
				this.animator.SetInteger ("State", 0);
			}

		}

        // ** Boss level 1 - Player jump when space is pressed **

        if (SceneManager.GetActiveScene().name == "BossBattle1")
        {
            // ** Player drop through platforms **

            //if ((Input.GetKey(KeyCode.S)) && grounded == true)
            //{
            //    this.GetComponent<BoxCollider2D>().enabled = false;

            //}

            // ** Player can jump through platforms **
            if (grounded == false && this.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                //Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), platforms.GetComponent<BoxCollider2D>());
                //Physics2D.IgnoreLayerCollision(8, 0);
                //Debug.Log (this.GetComponent<Rigidbody2D> ().velocity.y);
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
            }
        }


        this.rgb.AddForce(new Vector2(0, y));
		}

	void OnCollisionEnter2D(Collision2D coll)
	{
        // ** Boss battle button **

        if (coll.gameObject.tag == "Button")
		{
			buttonController.ButtonDespawn ();
		}

        // ** Find out if the player is on the ground **
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform")
		{
			Debug.Log (grounded);
			grounded = true;
		}

        // ** Lets the player stay on the platform and move with it **

        if (coll.transform.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform") 
		{
			transform.parent = coll.transform;
		}

        // ** Taking damage from enemies and hazards **

        if (coll.gameObject.tag == "Spike" || coll.gameObject.tag == "Enemy") 
		{
			int currentLives = int.Parse(lives.text);
			currentLives--;
			lives.text = currentLives.ToString ();
            SoundManager.instance.PlaySingle(dmgSound);

            // ** Death and resurrection **

            if (currentLives == 0) 
			{
                SoundManager.instance.PlaySingle(deathSound);
				Application.LoadLevel(Application.loadedLevel);
			}
		}

        // ** Boss 1 button damage **

        if (coll.gameObject.tag == "Button") 
		{
			environmentalDamager.gravityScale = 1;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
        // ** Player on ground verification **

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

