using UnityEngine;
using System.Collections;

public class DashRing : MonoBehaviour
{
	public float force;
	public Transform RingCenter;

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
		Rigidbody2D rigidBody = player.GetComponent<Rigidbody2D> ();
		
		// The angle of the ring, in radians.
		float rotationInRadians = transform.rotation.eulerAngles.z * Mathf.PI / 180;
		// A unit vector representing the direction of the ring.
		Vector2 ringDirection = new Vector2 (Mathf.Cos (rotationInRadians), Mathf.Sin (rotationInRadians));

		// Reset the player's current velocity.
		rigidBody.velocity = new Vector2 (0, 0);

		//Reset the player's position to the center of the ring
		player.transform.position = RingCenter.position;
		
		// Add the extra ring force.
		Vector2 extraForce = ringDirection * force;
		rigidBody.AddForce (extraForce);		
	}
}
