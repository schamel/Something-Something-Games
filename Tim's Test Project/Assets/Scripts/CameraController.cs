using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject target;
	public float leashRange;
	//public float followTightness;

	private Vector3 _startOffset;

	// Use this for initialization
	void Start ()
	{
		_startOffset = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	// LateUpdate is called after all other update functions
	void LateUpdate ()
	{
		moveCam ();
	}

	/// <summary>
	/// Moves the camera.  This version acts as if the camera is "leashed" to the player, only moving when the player gets too far away.
	/// The class member <paramref name="leashRange"/> determines how far the player can go before the camera is moved.
	/// </summary>
	private void moveCam ()
	{
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 targetPos = new Vector2 (target.transform.position.x, target.transform.position.y);
		Vector2 offset = targetPos - currentPos;

		if (offset.magnitude > leashRange) {
			offset = offset.normalized * (offset.magnitude - leashRange);

			transform.position = new Vector3 (currentPos.x + offset.x, currentPos.y + offset.y, _startOffset.z);
		}
	}

	/// <summary>
	/// Moves the camera.  This version keeps the camera constantly moving towards the player at a rate that is proportional to the value of
	/// the class member <paramref name="followTightness"/>.
	/// </summary>
	/*
	private void moveCam() {
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 targetPos = new Vector2 (target.transform.position.x, target.transform.position.y);
		Vector2 offset = targetPos - currentPos;

		offset *= followTightness;

		transform.position = new Vector3(currentPos.x + offset.x, currentPos.y + offset.y, _startOffset.z);
	}
	*/
}
