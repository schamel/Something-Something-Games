using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour
{
	public float force;
	public bool angled;

	void Start ()
	{
	}
	
	void Update ()
	{	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			// Find the direction of the ring
			float rotation = (transform.rotation.eulerAngles.z + (angled ? 45 : 90)) * Mathf.PI / 180;
			Vector2 direction = new Vector2 (Mathf.Cos (rotation), Mathf.Sin (rotation));

			// Update the player's location
			other.transform.position = transform.position;
			
			// Set the player's new velocity
			Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D> ();

			if (direction.y == 0) {
				rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
			} else {
				rigidBody.velocity = new Vector2 (0, 0);
			}
			
			rigidBody.AddForce (direction * force);
		}
	}
}
