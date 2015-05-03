using UnityEngine;
using System.Collections;

public class PsuedoLoop : MonoBehaviour {

	private Collider2D firstCollision;
	public Collider2D secondCollision;

	// Use this for initialization
	void Start () 
	{
		firstCollision = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			firstCollision.enabled = !(firstCollision.enabled);
			secondCollision.enabled = !(secondCollision.enabled);
		}
				
	}
}
