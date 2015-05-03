using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class CheckPoint : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{		
		// Check that this game object has the correct object value
		if (!props.ContainsKey ("object") || props ["object"] != "sign") {
			return;
		}
		
		// Check that the other expected keys are present
		if (!props.ContainsKey ("facing")) {
			return;
		}
		
		// Load the prefab asset
		UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Check Point.prefab", typeof(GameObject));
		
		if (asset == null) {
			return;
		}
		
		// Instantiate the asset
		GameObject instance = (GameObject)GameObject.Instantiate (asset);
		instance.name = asset.name;
		
		// Rotate the asset if needed
		if (props ["facing"] == "left") {
			instance.transform.Rotate (new Vector3 (0, 180, 0));
		}
		
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