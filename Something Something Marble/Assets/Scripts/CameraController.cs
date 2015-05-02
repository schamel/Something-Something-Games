using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 _startOffset;

	private void Start ()
	{
		_startOffset = transform.position;
	}

	private void LateUpdate ()
	{	
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, _startOffset.z);
	}
}
