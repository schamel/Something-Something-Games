using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{ 
	public float speed;
	public float jumpHeight;

	private Rigidbody2D _rigidBody;
	public Vector3 respawnLocation;
	public bool grounded;

	Transform groundCheck;

	void Start ()
	{
		//Get The GroundCheck
		groundCheck = transform.Find("GroundCheck");

		// Cache the rigidbody componenet
		_rigidBody = GetComponent<Rigidbody2D> ();
		
		// Save the respawn location
		respawnLocation = transform.localPosition;
	}

	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position);
	}

	void FixedUpdate ()
	{
		// Move the player based on input recieved
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = 0;
		
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {
			moveVertical = jumpHeight;
		}
		
		_rigidBody.AddForce (new Vector2 (moveHorizontal, moveVertical) * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		switch (other.gameObject.tag) {
		case "Deadly":
			transform.localPosition = respawnLocation;
			_rigidBody.velocity = new Vector2 (0, 0);			
			break;
		}
	}
}
