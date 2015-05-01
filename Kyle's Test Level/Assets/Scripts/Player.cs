using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rigidBody;
	public float speed;
	public float jumpf = 350f;
	public LayerMask myMask;
	bool grounded;
	Vector2 groundpt;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 350;
	public Transform respawnPoint;
	// Use this for initialization
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
<<<<<<< HEAD
	
=======
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			_rigidBody.AddForce(new Vector2(0, jumpForce));
		}
>>>>>>> origin/master
	}

	// FixedUpdate is called once per fixed frame, and should be used for physics calculations
	void FixedUpdate ()
	{
<<<<<<< HEAD
		groundpt.x = transform.position.x;
		groundpt.y = transform.position.y - 0.66f;
		grounded = Physics2D.Linecast (transform.position, groundpt, myMask);
=======
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
>>>>>>> origin/master

		float hInput = Input.GetAxis ("Horizontal");
		_rigidBody.AddForce (new Vector2 (hInput * speed * Time.deltaTime, 0));

		if(Input.GetButtonDown ("Jump") && grounded){
			_rigidBody.AddForce(Vector2.up * jumpf);
		}
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		switch (trigger.gameObject.tag) {
		case "Respawn":
			transform.position = respawnPoint.position;
			_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, 0);
			break;
		}
	}
}
