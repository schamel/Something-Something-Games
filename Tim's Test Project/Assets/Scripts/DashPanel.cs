using UnityEngine;
using System.Collections;

public class DashPanel : MonoBehaviour
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

	void OnTriggerStay2D (Collider2D other)
	{
		float rotationInRadians = transform.rotation.eulerAngles.z * Mathf.PI / 180;
		Vector2 extraForce = new Vector2 (Mathf.Cos (rotationInRadians), Mathf.Sin (rotationInRadians)) * force;
		if (other.CompareTag ("Player")) {
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (extraForce);
		}
	}
}
