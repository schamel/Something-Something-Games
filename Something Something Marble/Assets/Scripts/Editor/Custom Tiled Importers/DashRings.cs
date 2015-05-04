using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class DashRings : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{
		// Check that this game object has the correct object value
		if (!props.ContainsKey ("object") || props ["object"] != "dash_ring") {
			return;
		}
		
		// Check that the other expected keys are present
		if (!props.ContainsKey ("facing")) {
			return;
		}

		// Load the prefab asset
		UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Game Objects/DashRing.prefab", typeof(GameObject));
		
		if (asset == null) {
			return;
		}
		
		// Instantiate the asset
		GameObject instance = (GameObject)GameObject.Instantiate (asset);
		instance.name = asset.name;
		
		// Rotate the asset if needed
		float rotation;

		switch (props ["facing"]) {
		case "up-right":
			rotation = 45;
			break;
		case "up":
			rotation = 90;
			break;
		case "up-left":
			rotation = 135;
			break;
		case "left":
			rotation = 180;
			break;
		case "down-left":
			rotation = -135;
			break;
		case "down":
			rotation = -90;
			break;
		case "down-right":
			rotation = -45;
			break;
		default:
			rotation = 0;
			break;
		}

		instance.transform.Rotate (new Vector3 (0, 0, rotation));

		// Position the asset
		instance.transform.parent = gameObject.transform.parent;
		
		Vector3 position = gameObject.transform.localPosition;
		position.x += 0.35f;
		position.y += 0.35f;
		instance.transform.localPosition = position;
		
		// Remove the old object
		GameObject.DestroyImmediate (gameObject);
	}
	
	public void CustomizePrefab (UnityEngine.GameObject prefab)
	{
		// Do nothing
	}
}

