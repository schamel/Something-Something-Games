using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class LevelExit : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{		
		// Check that this game object has the correct object value
		if (!props.ContainsKey ("object") || props ["object"] != "goal") {
			return;
		}
		
		// Load the prefab asset
		UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Game Objects/Level Exit.prefab", typeof(GameObject));
		
		if (asset == null) {
			return;
		}
		
		// Instantiate the asset
		GameObject instance = (GameObject)GameObject.Instantiate (asset);
		instance.name = asset.name;
		
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