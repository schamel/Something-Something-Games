using UnityEngine;
using System.Collections;

public class DashRing : MonoBehaviour
{
	public float force;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			dashPlayer (other.gameObject);
		}
	}

	/// <summary>
	/// Accelerates the player in the direction of the dash ring.  All momentum before entering the ring is lost.
	/// </summary>
	/// <param name="player">The player.</param>
	void dashPlayer (GameObject player)
	{
		// TODO This works in groups of rings, but only if the rings are PERFECTLY aligned.
		//      It probably needs some code to prevent the player from flying out the side of a group
		//      of rings (maybe reset the player's position to the middle of the ring before adding the force?

		Rigidbody2D rigidBody = player.GetComponent<Rigidbody2D> ();
		
		// The angle of the ring, in radians.
		float rotationInRadians = transform.rotation.eulerAngles.z * Mathf.PI / 180;
		// A unit vector representing the direction of the ring.
		Vector2 ringDirection = new Vector2 (Mathf.Cos (rotationInRadians), Mathf.Sin (rotationInRadians));

		// Reset the player's current velocity.
		rigidBody.velocity = new Vector2 (0, 0);
		
		// Add the extra ring force.
		Vector2 extraForce = ringDirection * force;
		rigidBody.AddForce (extraForce);
	}
}
