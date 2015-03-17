using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spring : MonoBehaviour
{
	public float force;
	public Transform SpringCenter;

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
			springPlayer (other.gameObject);
		}
	}

	/// <summary>
	/// Accelerates the player in the direction of the spring.  Momentum orthogonal to the direction of the spring is conserved.
	/// </summary>
	/// <param name="player">The player.</param>
	void springPlayer (GameObject player)
	{
		Rigidbody2D rigidBody = player.GetComponent<Rigidbody2D> ();

		// The angle of the spring, in radians.
		float rotationInRadians = (transform.rotation.eulerAngles.z + 90) * Mathf.PI / 180;
		// A unit vector representing the direction of the spring.
		Vector2 springDirection = new Vector2 (Mathf.Cos (rotationInRadians), Mathf.Sin (rotationInRadians));

		// The angle of the player's current velocity, in radians.
		float velocityRotRadians = Mathf.Atan (rigidBody.velocity.y / rigidBody.velocity.x);
		// If the velocity is in the second or third quadrant, add pi (because the range of arctan is -pi/2 to pi/2).
		if (rigidBody.velocity.x < 0) {
			velocityRotRadians += Mathf.PI;
		}
		// The angle of the velocity with respect to the "baseline" of the spring.
		float velRotRelativeToSpringBase = Mathf.PI / 2 - rotationInRadians + velocityRotRadians;
		// The angle of the base of the spring.
		float baseRotInRadians = rotationInRadians - Mathf.PI / 2;
		// A unit vector representing the direction of the spring's baseline.
		Vector2 springOrthoDirection = new Vector2 (Mathf.Cos (baseRotInRadians), Mathf.Sin (baseRotInRadians));

		//If the spring is facing straight up, straight down, straight left, or straight right
		if (rotationInRadians == 0 || rotationInRadians == (Mathf.PI / 2) || rotationInRadians == Mathf.PI || rotationInRadians == ((3 * Mathf.PI) / 2)) {
		
			// Remove the component of velocity parallel to the direction of the spring.
			// This is done by setting the velocity to the projection of the velocity vector onto the spring's baseline vector.
			rigidBody.velocity = springOrthoDirection.normalized * rigidBody.velocity.magnitude * Mathf.Cos (velRotRelativeToSpringBase);
		} else
			//Remove ALL the velocity from the player.
			rigidBody.velocity = new Vector2 (0, 0);

		//Move the player character to the spring's center (determined by an empty object)
		player.transform.position = SpringCenter.position;

		// Now that the player is only moving orthogonal to the spring, add the extra spring force.
		Vector2 extraForce = springDirection * force;
		rigidBody.AddForce (extraForce);
	}


}
