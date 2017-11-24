using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerController2 : MonoBehaviour {

    // ** Public variables **

    public float speed = 50f;
	public float jump = 200f;
	public bool grounded = true;

	public Text lives;
	public GameObject environmentDamager;
    public AudioClip dmgSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;
	public Canvas healthCanvas;
	public int currentLives;
	public bool singleDamager = false;
	public GameObject environDamager;

    // ** Private variables **

    private ButtonController buttonController;
	private Rigidbody2D rgb;
	private Animator animator;
	private float _movingValue = 0;
	private bool facingRight = true;
	private Vector3 offset;

	void awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "BossBattle1") {
			environDamager = Instantiate (environmentDamager) as GameObject;
		}

		currentLives = PlayerPrefs.GetInt ("currentLives");
		lives.text = currentLives.ToString ();

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
				this.animator.SetInteger ("State", 1);
			} else {
				this.animator.SetInteger ("State", 0);
			}

		if (this._movingValue > 0) {
			
			facingRight = true;
			this._flip ();
		} 

		if (this._movingValue < 0) {

			facingRight = false;
			this._flip ();
		}
			

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
                this.GetComponent<PolygonCollider2D>().enabled = false;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
				this.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }


        this.rgb.AddForce(new Vector2(0, y));
		}

	private void _flip()
	{
		if (this.facingRight)
		{
			this.transform.localScale = new Vector3(3f, 3f, 1f);
		}
		else
		{
			this.transform.localScale = new Vector3(-3f, 3f, 1f); 
		}
	}
		

	void OnCollisionEnter2D(Collision2D coll)
	{
        // ** Boss battle button **

        if (coll.gameObject.tag == "Button")
		{
			buttonController.ButtonDespawn ();
		}

        // ** Find out if the player is on the ground **
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform" || coll.gameObject.tag == "WallCollider")
		{
			grounded = true;
		}

        // ** Taking damage from enemies and hazards **

		if (coll.gameObject.tag == "Spike" && currentLives == 3 || coll.gameObject.tag == "Enemy" && currentLives == 3) 
		{
			PlayerPrefs.SetInt ("currentLives", 2);

			SoundManager.instance.PlaySingle (dmgSound);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 2 || coll.gameObject.tag == "Enemy" && currentLives == 2) 
		{
			PlayerPrefs.SetInt ("currentLives", 1);
			currentLives = PlayerPrefs.GetInt ("currentLives");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 1 || coll.gameObject.tag == "Enemy" && currentLives == 1) 
		{
			PlayerPrefs.SetInt ("currentLives", 0);
			currentLives = PlayerPrefs.GetInt ("currentLives");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 0 || coll.gameObject.tag == "Enemy" && currentLives == 0) 
		{
			PlayerPrefs.SetInt ("currentLives", 3);
			SceneManager.LoadScene ("KitchenOverWorld");
		}
			

        // ** Boss 1 button damage **

		if (coll.gameObject.tag == "Button" && singleDamager == false) 
		{
			if (SceneManager.GetActiveScene ().name == "BossBattle1") {
				environDamager.GetComponent<Rigidbody2D> ().gravityScale = 1;
				environDamager = Instantiate (environmentDamager) as GameObject;
				environDamager.SetActive (false);
				singleDamager = true;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
        // ** Player on ground verification **

        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform")
		{
			grounded = false;
		} 
	}

	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.tag == "Beam" && currentLives == 3) {
			PlayerPrefs.SetInt ("currentLives", 2);
			SoundManager.instance.PlaySingle (dmgSound);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		else if (coll.gameObject.tag == "Beam" && currentLives == 2) {
			PlayerPrefs.SetInt ("currentLives", 1);
			SoundManager.instance.PlaySingle (dmgSound);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		else if (coll.gameObject.tag == "Beam" && currentLives == 1) {
			PlayerPrefs.SetInt ("currentLives", 0);
			currentLives = PlayerPrefs.GetInt ("currentLives");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		// ** Death and resurrection **
		else if (coll.gameObject.tag == "Beam" && currentLives == 0) {
			PlayerPrefs.SetInt ("currentLives", 3);
			SceneManager.LoadScene ("KitchenOverWorld");
		}

	}
}

