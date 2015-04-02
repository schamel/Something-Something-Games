using UnityEngine;
using System.Collections;

public class DefyGrav : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider2D other){
		if (other.CompareTag ("Player")) {
			other.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}

	void OnTriggerExit (Collider2D other){
		other.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}
}
