﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float health=40;
	private Vector3 _startOffset;
	//private float temp;
	private float dist;
	private float offset;
	private float cero;
	private int direction;
	public bool chasing;
	// Use this for initialization
	void Start () {
		//temp = transform.position.y;
		dist = 0;
		offset = .01f;
		cero = 0;
		direction = 1;
		chasing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (gameObject);
		if (!chasing) {
			if (dist > 100 || dist < 0) {
				offset = offset * (-1);
				direction = direction * (-1); 
				dist = dist + direction;
			} else {
				//temp = temp + offset;
				dist = dist + direction;
			}
			transform.position = new Vector3 (transform.position.x, transform.position.y + offset, cero);
		}
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Rigidbody2D rigidBody = other.gameObject.GetComponent<Rigidbody2D> ();
			health -= Mathf.Abs(rigidBody.velocity.x);
			
		}
	}
}