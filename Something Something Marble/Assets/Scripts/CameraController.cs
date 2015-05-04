using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	public GameObject terrainMesh; // This works nicely when you only have one layer of terrain, but could break if you had more!

	private Vector3 _startOffset;
	private Bounds _terrainBounds;

	private void Start ()
	{
		// Store the starting offset
		_startOffset = transform.position;
		
		// Find the borders of the map
		_terrainBounds = terrainMesh.GetComponent<MeshRenderer> ().bounds;
	}

	private void LateUpdate ()
	{
		// Find where the camera should be positioned to be centered on the player
		Vector3 position = new Vector3 (player.transform.position.x, player.transform.position.y, _startOffset.z);
		
		// Find the size of the Camera (we calculate this here becuase the aspect ratio could change during play)
		Camera camera = Camera.main;
		
		float height = 2f * camera.orthographicSize;
		float width = height * camera.aspect;
		
		// Calculate the min and max x locations for the camera
		float minX = _terrainBounds.min.x;
		float maxX = _terrainBounds.max.x;
		
		if (maxX - minX < width) {
			maxX = minX + width;
		}
		
		// Calculate the min and max x locations for the camera
		float minY = _terrainBounds.min.y;
		float maxY = _terrainBounds.max.y;
		
		if (maxY - minY < height) {
			maxY = minY + height;
		}
		
		// Check if the camera is escaping the map border on the x axis
		if ((position.x - (width / 2)) < minX) {
			position.x = minX + (width / 2);
		} else if ((position.x + (width / 2)) > maxX) {
			position.x = maxX - (width / 2);
		}

		// Check if the camera is escaping the map border on the y axis
		if ((position.y - (height / 2)) < minY) {
			position.y = minY + (height / 2);
		} else if ((position.y + (height / 2)) > maxY) {
			position.y = maxY - (height / 2);
		}
		
		// Update the camera with the newly found position
		transform.position = position;		
	}
}
