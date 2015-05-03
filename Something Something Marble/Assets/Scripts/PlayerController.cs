using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	// Extra Character Sprites
	public Sprite crazyEightSprite;

	// Movement modifiers
	public float speed;
	public float jumpHeight;	
	
	// Control Options	
	private KeyCode _fowardButton1;
	private KeyCode _fowardButton2;
	private KeyCode _backwardButton1;	
	private KeyCode _backwardButton2;	
	private KeyCode _jumpButton1;
	private KeyCode _jumpButton2;
	private KeyCode _jumpButton3;
	
	private bool _crazyControls;
	
	// Other Member Variables
	private Rigidbody2D _rigidbody;
	private Collider2D _collider;
	
	private Vector3 _respawnLocation;
	private Vector2 _storedVelocity;
	
	private void Start ()
	{
		// Make sure we have a character set
		if (!PlayerPrefs.HasKey ("Character")) {
			PlayerPrefs.SetString ("Character", "Default");
		}
		
		// Check if the user is playing as Crazy Eight
		if (PlayerPrefs.GetString ("Character") == "Crazy Eight") {
			GetComponent<SpriteRenderer> ().sprite = crazyEightSprite;
			_crazyControls = true;
		} else {
			_crazyControls = false;
		}
		
		// Set the default buttons
		_fowardButton1 = KeyCode.D;
		_fowardButton2 = KeyCode.RightArrow;
		_backwardButton1 = KeyCode.A;
		_backwardButton2 = KeyCode.LeftArrow;
		_jumpButton1 = KeyCode.Space;
		_jumpButton2 = KeyCode.W;
		_jumpButton3 = KeyCode.UpArrow;
		
		// Randomize the buttons if needed
		if (_crazyControls) {
			RandomizeControls ();
		}
		
		// Cache the rigidbody componenet
		_rigidbody = GetComponent<Rigidbody2D> ();
		
		// Cache the collider componenet
		_collider = GetComponent<Collider2D> ();
		
		// Save the respawn location
		_respawnLocation = transform.localPosition;
	}

	private void FixedUpdate ()
	{
		// Check to make sure the game is not paused
		if (Pause.Instance.IsPaused ()) {
			if (!_rigidbody.isKinematic) {
				_storedVelocity = _rigidbody.velocity;
				_rigidbody.isKinematic = true;
			}
			
			return;
		}
		
		// Check if we just came out of being paused
		if (_rigidbody.isKinematic) {
			_rigidbody.isKinematic = false;
			_rigidbody.velocity = _storedVelocity;
		}
		
		// Check if we should randomize the controls
		if (_crazyControls && Random.Range (1, 1000) == 1) {
			RandomizeControls ();
		}
		
		// Check if the player is jumping	
		float moveVertical = 0;	
		
		if ((Input.GetKeyDown (_jumpButton1) || Input.GetKeyDown (_jumpButton2) || Input.GetKeyDown (_jumpButton3)) && IsGrounded ()) {
			moveVertical = jumpHeight;
		}

		float moveHorizontal = 0.0f;
		
		// Check for horizontal movement
		if (Input.GetKey (_fowardButton1) || Input.GetKey (_fowardButton2)) {
			if (!Input.GetKey (_backwardButton1) && !Input.GetKey (_backwardButton2)) {
				moveHorizontal = speed;
			}
		} else if (Input.GetKey (_backwardButton1) || Input.GetKey (_backwardButton2)) {
			moveHorizontal = -speed;
		}
		
		// Add the force to the player
		_rigidbody.AddForce (new Vector2 (moveHorizontal, moveVertical) * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		switch (other.gameObject.tag) {
		case "Check Point":
			_respawnLocation = other.gameObject.transform.position;
			break;
		}
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		switch (other.gameObject.tag) {
		case "Deadly":
			transform.localPosition = _respawnLocation;
			_rigidbody.velocity = new Vector2 (0, 0);			
			break;
		}
	}

	public bool IsGrounded ()
	{
		Vector3 position = _collider.bounds.min;
		position.y = position.y - 0.1f;
		
		return Physics2D.Raycast (position, Vector3.down, 0.1f);
	}
	
	private void RandomizeControls ()
	{
		List<KeyCode> buttons = new List<KeyCode> (new KeyCode[] {
			_fowardButton1, _fowardButton2,
			_backwardButton1, _backwardButton2,
			_jumpButton1, _jumpButton2, _jumpButton3
		});
		
		int i = Random.Range (0, buttons.Count - 1);
		_fowardButton1 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_fowardButton2 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_backwardButton1 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_backwardButton2 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_jumpButton1 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_jumpButton2 = buttons [i];
		buttons.RemoveAt (i);
		
		i = Random.Range (0, buttons.Count - 1);
		_jumpButton3 = buttons [i];
		buttons.RemoveAt (i);
	}
}
