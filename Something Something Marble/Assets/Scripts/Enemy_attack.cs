using UnityEngine;
using System.Collections;

public class Enemy_attack : MonoBehaviour {
	private float temp;
	private int above;
	private int left;

	// Use this for initialization
	void Start () {
		above = 1;
		left = 1;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			var go = GameObject.Find("Enemy");
			go.GetComponentInParent<Enemy>().chasing = true;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		var go = GameObject.Find("Enemy");
		if (go.transform.position.y < other.transform.position.y)
			above = 1;
		else if (go.transform.position.y == other.transform.position.y)
			above = 0;
		else
			above = -1;

		if (go.transform.position.x < other.transform.position.x)
			left = 1;
		else if (go.transform.position.x == other.transform.position.x)
			left = 0;
		else
			left = -1;

		if(other.CompareTag ("Player")) {

			go.transform.position = new Vector3((go.transform.position.x + (left * 0.1f)), go.transform.position.y + (above * 0.1f) , 0f);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			var go = GameObject.Find("Enemy");
			go.GetComponentInParent<Enemy>().chasing = false;
		}
	}
}
