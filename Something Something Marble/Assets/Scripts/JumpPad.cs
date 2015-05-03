﻿using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour
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
		Vector2 extraForce;
		if (other.CompareTag ("Player")) {
			Rigidbody2D rigidBody = other.gameObject.GetComponent<Rigidbody2D> ();
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 0);
			//Vector2 extraForce = new Vector2 (0, force);
			if(rigidBody.velocity.x < 0)
				extraForce = new Vector2 ((force * -1), force);
			else
				extraForce = new Vector2 (force, force);
			rigidBody.AddForce (extraForce);
		}
	}
}