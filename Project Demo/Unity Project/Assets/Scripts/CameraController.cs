using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 _startOffset;

	void Start ()
	{
		_startOffset = transform.position;
	}
	
	void Update ()
	{
	}

	void LateUpdate ()
	{
		Vector3 targetPos = new Vector3 (player.transform.position.x, player.transform.position.y, _startOffset.z);
	
		transform.position = targetPos;
	}
}
