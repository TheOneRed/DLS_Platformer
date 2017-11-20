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
	public GameObject platforms;
	public Text lives;
	//public Rigidbody2D environmentalDamager;
	public GameObject environmentDamager;
    public AudioClip dmgSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;
	public Canvas healthCanvas;
	public int currentLives;

    // ** Private variables **

    private ButtonController buttonController;
	private Rigidbody2D rgb;
	private Animator animator;
	private Transform transform;
	private float _movingValue = 0;
	private bool facingRight = true;
	private GameObject environDamager;

	void awake()
	{
		//DontDestroyOnLoad(healthCanvas);
	}
	// Use this for initialization
	void Start () {
		environDamager = Instantiate (environmentDamager) as GameObject;
		//PlayerPrefs.SetInt ("currentLives", 3);
		currentLives = PlayerPrefs.GetInt ("currentLives");
		Debug.Log ("THIS IS CURRENTLIVES: " + currentLives);
		lives.text = currentLives.ToString ();
        // **Getting components **

        this.rgb = gameObject.GetComponent<Rigidbody2D>();
		this.animator = gameObject.GetComponent<Animator> ();
		this.transform = gameObject.GetComponent<Transform>();


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
// Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow
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
			Debug.Log (grounded);
			grounded = true;
		}

        // ** Lets the player stay on the platform and move with it **

        if (coll.transform.tag == "MovingPlatform" || coll.gameObject.tag == "RotatingPlatform") 
		{
			transform.parent = coll.transform;
		}

        // ** Taking damage from enemies and hazards **

		if (coll.gameObject.tag == "Spike" && currentLives == 3 || coll.gameObject.tag == "Enemy" && currentLives == 3) 
		{
			Debug.Log ("HEALTH SHOULD BECOME 2");
			//Application.LoadLevel(Application.loadedLevel);
			//PlayerPrefs.SetInt ("currentLives", 2);
			PlayerPrefs.SetInt ("currentLives", 2);
			//currentLives = int.Parse(lives.text);
			//int currentLives = PlayerPrefs.GetInt ("currentLives");
			//currentLives--;
			//lives.text = currentLives.ToString ();
			SoundManager.instance.PlaySingle (dmgSound);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 2 || coll.gameObject.tag == "Enemy" && currentLives == 2) 
		{
			Debug.Log ("CHANGING CURRENTLIVES TO 1");
			PlayerPrefs.SetInt ("currentLives", 1);
			//currentLives = int.Parse(lives.text);
			currentLives = PlayerPrefs.GetInt ("currentLives");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 1 || coll.gameObject.tag == "Enemy" && currentLives == 1) 
		{
			PlayerPrefs.SetInt ("currentLives", 0);
			//currentLives = int.Parse(lives.text);
			currentLives = PlayerPrefs.GetInt ("currentLives");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 
		else if (coll.gameObject.tag == "Spike" && currentLives == 0 || coll.gameObject.tag == "Enemy" && currentLives == 0) 
		{
			PlayerPrefs.SetInt ("currentLives", 3);
			Application.LoadLevel ("KitchenOverWorld");
		}

            // ** Death and resurrection **

        //if (currentLives == 0) 
		//	{
        //        SoundManager.instance.PlaySingle(deathSound);
				//Application.LoadLevel(Application.loadedLevel);
		//		Application.LoadLevel ("KitchenOverWorld");
		//	}
		//}

        // ** Boss 1 button damage **

        if (coll.gameObject.tag == "Button") 
		{
			
			//environmentalDamager.gravityScale = 1;
			//environmentDamager.GetComponent<Rigidbody2D>().gravityScale = 1;
			environDamager.GetComponent<Rigidbody2D>().gravityScale = 1;
			environDamager = Instantiate (environmentDamager) as GameObject;
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

