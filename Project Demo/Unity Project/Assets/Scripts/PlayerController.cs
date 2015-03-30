using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{ 
	public float speed;
	public float jumpHeight;

	private Rigidbody2D _rigidBody;
	public Vector3 respawnLocation;
	public bool grounded = true;

	void Start ()
	{
		// Cache the rigidbody componenet
		_rigidBody = GetComponent<Rigidbody2D> ();
		
		// Save the respawn location
		respawnLocation = transform.localPosition;
	}

	void Update ()
	{
	}

	void FixedUpdate ()
	{
		// Move the player based on input recieved
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = 0;
		
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {
			moveVertical = jumpHeight;
			grounded = false;
		}
		
		_rigidBody.AddForce (new Vector2 (moveHorizontal, moveVertical) * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		// This needs to be changed to make sure the object is below the player
		grounded = true;

		switch (other.gameObject.tag) {
		case "Deadly":
			transform.localPosition = respawnLocation;
			_rigidBody.velocity = new Vector2 (0, 0);			
			break;
		}
	}
}
