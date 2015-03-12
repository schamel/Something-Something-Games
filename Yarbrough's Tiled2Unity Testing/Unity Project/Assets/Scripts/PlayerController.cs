using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
	public float speed;
	private Rigidbody2D _rigidBody;

	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
	}

	void FixedUpdate ()
	{
		// Move the player based on input recieved
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		_rigidBody.AddForce (new Vector2 (moveHorizontal, moveVertical) * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log (other.gameObject.tag);
		switch (other.gameObject.tag) {
		case "ItemBlock":
				// Remove the object from the scene
			GameObject.Destroy (other.gameObject);
			
			break;
		}
	}
}
