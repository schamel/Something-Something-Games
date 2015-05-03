using UnityEngine;
using System.Collections;

public class DashRing : MonoBehaviour
{
	public float force;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			// Find the direction of the ring
			float rotation = transform.rotation.eulerAngles.z * Mathf.PI / 180;
			Vector2 direction = new Vector2 (Mathf.Cos (rotation), Mathf.Sin (rotation));
			
			// Update the player's location
			other.transform.position = transform.position;
			
			// Set the player's new velocity			
			Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D> ();
			
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce (direction * force);
		}
	}
}
