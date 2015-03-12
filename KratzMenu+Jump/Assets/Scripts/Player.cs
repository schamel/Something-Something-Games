using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private KeyCode FwdButton1;
	private KeyCode FwdButton2;
	private KeyCode BwdButton1;
	private KeyCode BwdButton2;
	private KeyCode JumpButton1;
	private KeyCode JumpButton2;
	private KeyCode JumpButton3;
	public bool    JumpB, grounded;
	public float   JumpF;


	private Rigidbody2D _rigidBody;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();

		//Initialize Controls
		JumpButton1 = KeyCode.Space;
		JumpButton2 = KeyCode.W;
		JumpButton3 = KeyCode.UpArrow;
		grounded = true;
	}
	
	// Update is called once per frame
	void Update (){
	
		JumpB = Input.GetKeyDown (JumpButton1) || Input.GetKeyDown (JumpButton2) || Input.GetKeyDown(JumpButton3);
	}

	// FixedUpdate is called once per fixed frame, and should be used for physics calculations
	void FixedUpdate ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		_rigidBody.AddForce (new Vector2 (hInput * speed * Time.deltaTime, 0));


		if (JumpB && grounded){
			_rigidBody.AddForce (Vector2.up * JumpF);
			grounded = false;
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

	void OnCollisionEnter2D(Collision2D coll){
		grounded = true;
	}
}
