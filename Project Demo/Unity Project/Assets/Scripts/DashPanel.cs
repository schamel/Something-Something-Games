using UnityEngine;

public class DashPanel : MonoBehaviour
{
	public float force;

	void Start ()
	{
	}
	
	void Update ()
	{	
	}

	void OnTriggerStay2D (Collider2D other)
	{		
		if (other.CompareTag ("Player")) {			
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (
				new Vector2 (Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.PI / 180) * force, 0)
			);
		}
	}
}
