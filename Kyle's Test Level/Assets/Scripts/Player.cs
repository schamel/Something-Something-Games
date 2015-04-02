using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rigidBody;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	// FixedUpdate is called once per fixed frame, and should be used for physics calculations
	void FixedUpdate ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		_rigidBody.AddForce (new Vector2 (hInput * speed * Time.deltaTime, 0));
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		switch (trigger.gameObject.tag) {
		case "Respawn":
			transform.position = new Vector2 (0, 0.5f);
			_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, 0);
			break;
		}
	}
}
