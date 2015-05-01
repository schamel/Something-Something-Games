using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rigidBody;
	public float speed;

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
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			_rigidBody.AddForce(new Vector2(0, jumpForce));
		}
	}

	// FixedUpdate is called once per fixed frame, and should be used for physics calculations
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		float hInput = Input.GetAxis ("Horizontal");
		_rigidBody.AddForce (new Vector2 (hInput * speed * Time.deltaTime, 0));
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
