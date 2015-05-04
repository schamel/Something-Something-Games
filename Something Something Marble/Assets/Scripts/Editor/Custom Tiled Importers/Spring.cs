using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class Spring : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{
		// Check that this game object has the correct object value
		if (!props.ContainsKey ("object") || props ["object"] != "spring") {
			return;
		}
		
		// Check that the other expected keys are present
		if (!props.ContainsKey ("type") || !props.ContainsKey ("facing")) {
			return;
		}
		
		// Find the rotation of the spring
		float rotation;
		bool angled = false;
		
		switch (props ["facing"]) {
		case "up-right":
			rotation = -45;
			angled = true;
			break;
		case "right":
			rotation = -90;
			break;
		case "down-right":
			rotation = -135;
			angled = true;
			break;
		case "down":
			rotation = 180;
			break;
		case "down-left":
			rotation = 135;
			angled = true;
			break;
		case "left":
			rotation = 90;
			break;			
		case "up-left":
			rotation = 45;
			angled = true;
			break;
		default:
			rotation = 0;
			break;
		}
		
		// Load the prefab asset
		UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Game Objects/Spring - " + props ["type"] + (angled ? " Angled" : "") + ".prefab", typeof(GameObject));
		
		if (asset == null) {
			return;
		}
		
		// Instantiate the asset
		GameObject instance = (GameObject)GameObject.Instantiate (asset);
		instance.name = asset.name;
		
		// Rotate the asset if needed
		if (angled) {
			rotation += 45;
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

