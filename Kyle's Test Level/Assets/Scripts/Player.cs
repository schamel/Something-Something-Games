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
		groundpt.x = transform.position.x;
		groundpt.y = transform.position.y - 0.66f;
		grounded = Physics2D.Linecast (transform.position, groundpt, myMask);

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
			transform.position = new Vector2 (0, 0.5f);
			_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, 0);
			break;
		}
	}
}
