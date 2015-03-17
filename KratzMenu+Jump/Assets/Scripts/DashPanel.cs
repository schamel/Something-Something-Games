using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DashPanel : MonoBehaviour
{
	public float force;
	//public Text tooltip;
	//public Image tipbackground;

	// Use this for initialization
	void Start ()
	{
		//tooltip.enabled = false;
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

	/*void OnMouseOver(){
		tooltip.transform.position = new Vector2(Input.mousePosition.x + 30, Input.mousePosition.y+10);
		tipbackground.transform.position = tooltip.transform.position;
		tooltip.text = "Dash Panels apply speed \n in the implied direction";
		tooltip.enabled = true;
		tipbackground.enabled = true;
	}

	void OnMouseExit(){
		tooltip.enabled = false;
		tipbackground.enabled = false;
	}*/
}
