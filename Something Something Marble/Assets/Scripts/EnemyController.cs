using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float health = 1.0f;
	public float leash = 1.0f;
	public float speed = 0.01f;
	private Vector3 _startOffset;
	private Vector3 _direction;

	// Use this for initialization
	void Start ()
	{
		_startOffset = transform.position;
		_direction = new Vector3 (0, 0, _startOffset.z);
		ChangeDirection ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Check to make sure the enemy is not going outside it's leash in the x direction
		float distance = Mathf.Abs (transform.position.x - _startOffset.x);
		
		if (distance > leash) {
			_direction.x = -_direction.x;
		}
		
		// Check to make sure the enemy is not going outside it's leash in the y direction
		distance = Mathf.Abs (transform.position.y - _startOffset.y);
		
		if (distance > leash) {
			_direction.y = -_direction.y;
		}
		
		// Randomly change the direction of the enemy
		if (Random.Range (1, 100) <= 1) {
			ChangeDirection ();
		}
		
		transform.position = transform.position + _direction;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Rigidbody2D rigidBody = other.gameObject.GetComponent<Rigidbody2D> ();
			health -= Mathf.Abs (rigidBody.velocity.x) + Mathf.Abs (rigidBody.velocity.y);
			
			if (health <= 0) {
				Destroy (gameObject);
			}
		} else {
			// Reverse the movement of the enemy			
			_direction.x = -_direction.x;
			_direction.y = -_direction.y;
		}
	}
	
	private void ChangeDirection ()
	{
		_direction.x = Random.Range (-1f, 1f);
		_direction.y = Random.Range (-1f, 1f);
		
		float speedFactor = speed / Mathf.Sqrt (Mathf.Pow (_direction.x, 2) + Mathf.Pow (_direction.y, 2) + 0.00001f);
		
		_direction.x = _direction.x * speedFactor;
		_direction.y = _direction.y * speedFactor;
	}
}
