using UnityEngine;
using System.Collections;

public class PseudoOneWayFloor : MonoBehaviour 
{
	private Collider2D platform;

	// Use this for initialization
	void Start () 
	{
		platform = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			platform.enabled = !(platform.enabled);
		}
		
	}
}

